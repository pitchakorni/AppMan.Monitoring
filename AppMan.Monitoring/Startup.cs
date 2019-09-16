using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace AppMan.HealthCheack
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecksUI();

            //services.AddHealthChecks()
            //    .AddCheck("self", c =>
            //    {
            //        return HealthCheckResult.Healthy();
            //    })
            //    .AddSqlServer("Server=54.255.188.220;initial catalog=uatsales-eapp;Persist Security Info=True;User Id=SA-SALES;Password=!#@$sdfasdjio3#%;");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHealthChecksUI(config => config.UIPath = "/hcui");
            //app.UseHealthChecks("/health", new HealthCheckOptions
            //{
            //    Predicate = registration => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});
        }

        public class MyHealthcheck : IHealthCheck
        {
            public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
            {
                return Task.FromResult(HealthCheckResult.Healthy());
            }
        }
    }
}