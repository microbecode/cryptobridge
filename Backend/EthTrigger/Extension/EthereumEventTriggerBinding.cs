using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EthTrigger.Extension
{
    internal class EthereumEventTriggerBinding : ITriggerBinding
    {
        private readonly EthereumEventTriggerAttribute _attribute;

        public EthereumEventTriggerBinding(EthereumEventTriggerAttribute attribute)
        {
            _attribute = attribute;
        }

        public Type TriggerValueType => typeof(TransferLogData);

        public IReadOnlyDictionary<string, Type> BindingDataContract => new Dictionary<string, Type>();

        public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            return Task.FromResult<ITriggerData>(new TriggerData(null, new Dictionary<string, object>()));
        }

        public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            return Task.FromResult<IListener>(new EthereumEventListener(context.Executor, _attribute));
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return default;
        }
    }
}
