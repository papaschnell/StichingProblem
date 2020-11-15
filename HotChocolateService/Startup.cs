using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace TestHotChocolate
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddQueryType<Query>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapGraphQL($"/graphql"));
        }
    }
}