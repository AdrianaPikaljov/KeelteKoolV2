using KeelteKoolV2.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Web.Mvc;

namespace KeelteKoolV2.xUnitTesting
{
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider {  get; set; }

        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        public virtual void SetupServices(IServiceCollection services)
        {
            //services.AddScoped<ILanguageCoursesServices, LanguageCoursesServices>();
            //services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<IHostEnvironment, MockIHostEnvironment>();

            services.AddDbContext<KeelteKoolV2Context>
                (x =>
                {               
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                });
        }

        public void Dispose()
        {

        }

        protected T Svc<T>() 
        {
            return serviceProvider.GetService<T>();
        }
    }
}
