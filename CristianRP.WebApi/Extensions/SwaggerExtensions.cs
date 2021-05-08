﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CristianRP.WebApi.Extensions
{
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Extension method to setup the Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
                //while we have multiple versions of dto objects this is needed to not break swagger
                options.CustomSchemaIds(x => x.FullName)
            );

            return services;
        }

        /// <summary>
        /// Extension method to setup the Swagger environment
        /// </summary>
        /// <param name="app"></param>
        /// <param name="config"></param>
        /// <param name="provider"></param>
        /// <returns>IApplicationBuilder</returns>
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app, IConfiguration config)
        {

            app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint($"/swagger/v1/swagger.json", $"CristianRP API");
                    options.DocumentTitle = "CristianRP API Documentation";
                });

            return app;
        }
    }

    /// <summary>
    /// Swagger Options Class
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IConfiguration _config;

        public ConfigureSwaggerOptions(IConfiguration config)
        {
            _config = config;
        }

        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "CristianRP  V1", Version = "v1" });
                        options.EnableAnnotations();

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Acces Token",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

        }
    }
}
