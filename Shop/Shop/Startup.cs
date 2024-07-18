using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using Shop.Data.Interfaces;
using Shop.Data.mocks;

namespace Shop
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //для регистрации различных модулей и плагинов
            //подключение различных сервисов

            //позволяет объединить между собой интерфейс и класс, который реализует его
            services.AddTransient<IAllCars, MockCars>();
            services.AddTransient<ICarsCategory, MockCategory>();

            //подключили поддержку мвс
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //настройки, адреса и др

            //отображать страницу с ошибками
            app.UseDeveloperExceptionPage();

            //отображение страницы с кодом
            app.UseStatusCodePages();

            //использование стат файлов
            app.UseStaticFiles();

            //позволяет отслеживать юрл адрес
            //если нет контроллера и соответсвующего представления, то будет представление по умолчанию
            app.UseMvcWithDefaultRoute();

            /*
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction())
            {
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Production!");
                }); 
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            }); 
            */

        }
    }
}
