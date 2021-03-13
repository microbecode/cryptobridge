using EthTrigger.Extension;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: WebJobsStartup(typeof(EthTrigger.Startup))]
namespace EthTrigger
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var wbBuilder = builder.Services.AddWebJobs(x => { return; });
            wbBuilder.AddExtension<EtheremEventConfigProvider>();

        }
    }
}
