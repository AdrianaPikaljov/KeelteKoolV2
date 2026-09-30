using KeelteKoolV2.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KeelteKoolV2;
using System.Web.Mvc;
using KeelteKoolV2.xUnitTesting.Mock;
using KeelteKoolV2.xUnitTesting.Macros;
using KeelteKoolV2.Data;
using KeelteKoolV2.Core;
using KeelteKoolV2.Core.ServiceInterface;
using KeelteKoolV2.ApplicationServices.Services;






namespace KeelteKoolV2.xUnitTesting
{
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider { get; set; }

        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);

            serviceProvider = services.BuildServiceProvider();
        }
        //seame üles testide läbiviimiseks vajalikud kontrollerid mujalt projektist
        //see meetod annab ka mäluspleva andmebaasi misa testideks kasutada 
        //Viper tüüpi projektides toimib kui "program.cs" analoog, end lühidat kujul
        //param name sevises kollektor kuhu aseme kontroll´ri instantsid
        public void Dispose()
        {

        }

        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();
        }

        /// <summary>
        /// Leia üles kindel teenus, teenusepakkujalt.
        /// serviceProvider omab kontrollerite instantse, ning GetService hangib selle
        /// X tüüpi kontrolleri
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>

        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<ILanguageCoursesServices, LanguageCoursesServices>();
            //services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<IHostEnvironment, MockIHostEnvironment>();

            services.AddDbContext<KeelteKoolV2Context>
            (x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            RegisterMacros(services);
        }

        //Leia üles kindel teenus teenusepakkujakt
        //serviceProvider omab kontrollireti instantse ning GetService hangib selle X tüüpi kontrolleri
        private static void RegisterMacros(IServiceCollection services)
        {

            var macroBaseType = typeof(IMacros);

            var macros = macroBaseType
            .Assembly
            .GetTypes()
            .Where(t =>
            macroBaseType.IsAssignableFrom(t) &&
            !t.IsInterface &&
            !t.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddSingleton(macro);
            }
        }
    }
}