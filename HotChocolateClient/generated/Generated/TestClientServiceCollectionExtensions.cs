﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StrawberryShake;
using StrawberryShake.Http;
using StrawberryShake.Http.Pipelines;
using StrawberryShake.Serializers;

namespace Client
{
    public static class testClientServiceCollectionExtensions
    {
        public static IServiceCollection AddDefaultScalarSerializers(
            this IServiceCollection serviceCollection)
        {
            if (serviceCollection is null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            foreach (IValueSerializer serializer in ValueSerializers.All)
            {
                serviceCollection.AddSingleton(serializer);
            }

            return serviceCollection;
        }

        public static IServiceCollection AddtestClient(
            this IServiceCollection serviceCollection)
        {
            if (serviceCollection is null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddSingleton<ITestClient, TestClient>();
            serviceCollection.AddSingleton(sp =>
                HttpOperationExecutorBuilder.New()
                    .AddServices(sp)
                    .SetClient(ClientFactory)
                    .SetPipeline(PipelineFactory)
                    .Build());

            serviceCollection.AddEnumSerializers();
            serviceCollection.AddResultParsers();
            serviceCollection.TryAddDefaultOperationSerializer();
            serviceCollection.TryAddDefaultHttpPipeline();

            return serviceCollection;
        }

        private static IServiceCollection AddEnumSerializers(
            this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }

        private static IServiceCollection AddResultParsers(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IResultParser, GetValuesResultParser>();
            return serviceCollection;
        }

        private static IServiceCollection TryAddDefaultOperationSerializer(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<IOperationSerializer, JsonOperationSerializer>();
            return serviceCollection;
        }

        private static IServiceCollection TryAddDefaultHttpPipeline(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<OperationDelegate>(
                sp => HttpPipelineBuilder.New()
                    .Use<CreateStandardRequestMiddleware>()
                    .Use<SendHttpRequestMiddleware>()
                    .Use<ParseSingleResultMiddleware>()
                    .Build(sp));
            return serviceCollection;
        }

        private static Func<HttpClient> ClientFactory(IServiceProvider services)
        {
            var clientFactory = services.GetRequiredService<IHttpClientFactory>();
            return () => clientFactory.CreateClient("TestClient");
        }

        private static OperationDelegate PipelineFactory(IServiceProvider services)
        {
            return services.GetRequiredService<OperationDelegate>();
        }
    }
}
