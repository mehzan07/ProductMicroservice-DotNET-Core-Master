using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ProductMicroservice.DBContexts;
using ProductMicroservice.Repository;
using MediatR;
using AutoMapper;
using ProductMicroservice.RabbitMQMessaging.Options;
using ProductMicroservice.RabbitMQMessaging.Sendmesage;
using ProductMicroservice.CQRS.Commands;
using ProductMicroservice.CQRS.Queries;
using System.Collections.Generic;
using ProductMicroservice.Models;
using Microsoft.Extensions.Hosting; 


// comment to test pipeline after push

namespace ProductMicroservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHealthChecks();
           // for Override Appsettings in Kubernetes
            var serviceClientSettingsConfig = Configuration.GetSection("RabbitMq");
            var serviceClientSettings = serviceClientSettingsConfig.Get<RabbitMqConfig>();
            services.Configure<RabbitMqConfig>(serviceClientSettingsConfig);

            // connectionString: ProductsDBConString is defined in the appsettings.json
            services.AddDbContext<ProductContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductsDBConString")));

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Product Api",
                    Description = "A simple API to create a product",
                    Contact = new OpenApiContact
                    {
                        Name = "Mehrdad Zandi",
                        Email = "mehrdad.zandi@softsolutionsahand.com",
                        Url = new Uri("http://www.softsolutionsahand.com/")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(Startup));
            services.AddOptions();

            // register handler for CQRS but doesnn't help to solve accessing database in Release configuration. 
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<IRequestHandler<GetProductListQuery, List<Product>>, GetProductListQueryHandler>();
            services.AddTransient<IRequestHandler<GetProductByIdQuery, Product>, GetProductByIdHandler>();
            services.AddTransient<IRequestHandler<CreateProductCommand, Product>, CreateProductCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteProductByIdCommand, Product>, DeleteProductCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateProductCommand, Product>, UpdateProductCommandHandler>();

            services.Configure<RabbitMqConfig>(Configuration.GetSection("RabbitMq"));
            services.AddTransient<IProductUpdateSender, ProductUpdateSender>();

            // for Override Appsettings in Kubernetes but gives error.
            if (serviceClientSettings.Enabled)
            {
               // services.AddHostedService<ProductUpdateSender>();
            }
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Swagger should be out of Dev Environment, should be load in both production  and Dev environment
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // Configuring Health for kubernetes
                endpoints.MapHealthChecks("/health");
            });


        }
       
    }
}
