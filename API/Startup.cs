using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Restaurants.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services

                // add Swagger information
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(
                        name: "v1", 
                        info: new Info 
                        {
                            Title = "Restaurants", 
                            Version = "v1",
                            Description = "This is a simple REST API for the MongoDB 'Restaurants' sample dataset.",
                            Contact = new Contact{ Name = "Eric Brand", Email = "eric.d.brand@gmail.com" },
                            TermsOfService = "There are no terms of service for this API either express or implied."
                        }
                    ); 
                })

                // dependency injection interfaces and associated concrete types
                .AddTransient<IRestaurantRepository, RestaurantRepository_MongoDb>()

                // add MVS services
                .AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder appBuilder, IHostingEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
                appBuilder.UseDeveloperExceptionPage();

            // add Swagger
            appBuilder.UseSwagger();
            appBuilder.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 - Restaurants"); });

            // add MVC to the request execution pipeline
            appBuilder.UseMvc();
        }
    }
}