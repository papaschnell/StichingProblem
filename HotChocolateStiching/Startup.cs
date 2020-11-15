using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace StichingHotChocolate
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("test",
                (sp, c) =>
                {
                    var httpCtxAccessor = sp.GetService<IHttpContextAccessor>();
                    c.BaseAddress = new Uri("http://localhost:3000/graphql");
                });
            
            services
                .AddGraphQLServer()
                .AddRemoteSchema("test");
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapGraphQL($"/graphql"));
        }
    }
}