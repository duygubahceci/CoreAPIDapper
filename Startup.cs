using AutoMapper;
using CoreAPIDapper.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace CoreAPIDapper
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
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IDealerService, DealerService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("CoreAPIDapper", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = ".net Core WebAPI with Dapper",
                    Version = "1.0.0",
                    Description = "a basic .net Core Api with Dapper for only learning",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = ".net core api development with duygu",
                        Url = new System.Uri("http://localhost:5000"),
                        Email = "duygubahceci@gmail.com"
                    },
                    TermsOfService = new System.Uri("http://swagger.io/terms")
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //   app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/CoreAPIDapper/swagger.json", "Core Web API with Dapper");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
