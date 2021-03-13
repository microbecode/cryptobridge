using EthTrigger.Extension;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EthTrigger
{
    public static class EthereumEventTriggeredFunction
    {
        private const string Abi = Bridge.Contracts.StandardTokenDeployment.ABI;
        private const string ContractAddress = "0x1cb94c5c6486032a3cc4b92f97c9f8a3882405f2";
        private const string EventName = "Transfer";

        [FunctionName(nameof(EthereumEventTriggeredFunction))]
        public static void Run([EthereumEventTrigger(abi: Bridge.Contracts.StandardTokenDeployment.ABI, contractAddress: ContractAddress, eventName: EventName)]EthereumEventData eventData, ILogger logger)
        {
            string logMessage = $"Event data:\nBlock number: {eventData.BlockNumber}\n{string.Join('\n', eventData.Values.Select(value => $"{value.Key}: {value.Value}"))}";

            logger.LogInformation(logMessage);
        }
    }
}
