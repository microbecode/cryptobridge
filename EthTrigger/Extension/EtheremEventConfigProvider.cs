using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace EthTrigger.Extension
{
    [Extension("EthereumEventTrigger")]
    public class EtheremEventConfigProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context
                .AddBindingRule<EthereumEventTriggerAttribute>()
                .BindToTrigger<EthereumEventData>(new EthereumEventTriggerBindingProvider());
        }
    }
}
