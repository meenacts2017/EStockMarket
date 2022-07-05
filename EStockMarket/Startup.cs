using AutoMapper;
using EStockMarket.Business.Implementation;
using EStockMarket.Business.Interface;
using EStockMarket.Business.Mapper;
using EStockMarket.DataAccess.Implementation;
using EStockMarket.DataAccess.Interface;
using EStockMarket.DataAccess.Model;
using EStockMarket.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStockMarket
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.Configure<DatabaseSettings>(Configuration.GetSection("EStockMarket"));
            services.AddSingleton<ICompany, CompanyData>()
                    .AddTransient<IStocks, StocksData>()
                    .AddTransient<ICompanyProcessor, CompanyProcessor>()
                    .AddTransient<IStocksProcessor, StocksProcessor>();


            //services.AddControllersWithViews().AddNewtonsoftJson(options =>
            //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
            //= new DefaultContractResolver());
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
