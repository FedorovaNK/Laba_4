using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorgObject.ApplicationServices.GetPechatProductListUseCase;
using TorgObject.ApplicationServices.Repositories;
using TorgObject.DomainObjects.Ports;
using TorgObject.DomainObjects;
using System.Collections.Generic;

namespace TorgObject.WebService
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
            services.AddScoped<InMemoryPechatProductRepository>(x => new InMemoryPechatProductRepository(
                new List<PechatProduct> {
                    new PechatProduct() 
                    { 
                        Id = 1, 
                        Name = "НТО ул. Авиационная, вл.68", 
                        Area = "Щукино",
                        Address = "город Москва, Авиационная улица, дом 68",
                        Period = "с 1 января по 31 декабря",
                        Number = "НТО-09-02-002652",
                        FacilityArea = "9",
                        NameOfBusinessEntity = "Компания ФРЕГАТ",
                        District = "СЗАО", 
   
                    }
            }));
            services.AddScoped<IReadOnlyPechatProductRepository>(x => x.GetRequiredService<InMemoryPechatProductRepository>());
            services.AddScoped<IPechatProductRepository>(x => x.GetRequiredService<InMemoryPechatProductRepository>());

            services.AddScoped<IGetPechatProductListUseCase, GetPechatProductListUseCase>();
                        
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
