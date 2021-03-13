using Microsoft.Azure.WebJobs.Host.Triggers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EthTrigger.Extension
{
    public class EthereumEventTriggerBindingProvider : ITriggerBindingProvider
    {
        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            var result = Task.FromResult<ITriggerBinding>(default);
            var attribute = context.Parameter.GetCustomAttribute<EthereumEventTriggerAttribute>(false);

            if (attribute != null)
            {
                result = Task.FromResult<ITriggerBinding>(new EthereumEventTriggerBinding(attribute));
            }

            return result;
        }
    }
}
