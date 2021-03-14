using Ethereum.Contracts.Token.ContractDefinition;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Nethereum.ABI.FunctionEncoding;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EthTrigger.Extension
{
    public class EthereumEventListener : IListener
    {
        private const int EventPollingDelay = 1000;

        private readonly ITriggeredFunctionExecutor _executor;
        private readonly EthereumEventTriggerAttribute _attribute;
        private CancellationTokenSource _cts = null;
        private Event _event = null;
        private HexBigInteger _filter = null;

        public EthereumEventListener(ITriggeredFunctionExecutor executor, EthereumEventTriggerAttribute attribute)
        {
            _executor = executor;
            _attribute = attribute;
        }

        public void Cancel()
        {
            StopAsync(CancellationToken.None).Wait();
        }

        public void Dispose() { }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            await ListenAsync(_cts.Token);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cts.Cancel();

            return Task.CompletedTask;
        }

        private async Task ListenAsync(CancellationToken cancellationToken)
        {
            var web3 = new Web3(_attribute.Url);
            var transferEventHandler = web3.Eth.GetEvent<TransferEventDTO>(_attribute.ContractAddress); 
            var filterTransferEventsForContractAllReceiverAddress2 = transferEventHandler.CreateFilterInput();
            var filterIdTransferEventsForContractAllReceiverAddress2 = await transferEventHandler.CreateFilterAsync(filterTransferEventsForContractAllReceiverAddress2);

            await Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var result = await transferEventHandler.GetFilterChanges(filterIdTransferEventsForContractAllReceiverAddress2);

                    ProcessEvents(result, cancellationToken);
                    await Task.Delay(EventPollingDelay);
                }
            });
        }

        private void ProcessEvents(List<EventLog<TransferEventDTO>> eventsData, CancellationToken cancellationToken)
        {
            eventsData
                .Select(eventData => new TransferLogData() { Log = eventData.Log, Transfer = eventData.Event })
                .ToList()
                .ForEach(ethereumEventData => _executor.TryExecuteAsync(new TriggeredFunctionData { TriggerValue = ethereumEventData }, cancellationToken));
        }
    }
}
