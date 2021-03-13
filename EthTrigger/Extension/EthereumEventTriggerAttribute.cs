using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.Text;

namespace EthTrigger.Extension
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class EthereumEventTriggerAttribute : Attribute 
    {
        private const string DefaultUrl = "http://localhost:8545/";

        public EthereumEventTriggerAttribute(string abi, string contractAddress, string eventName, string url = DefaultUrl)
        {
            Url = url;  
            Abi = abi;
            ContractAddress = contractAddress;
            EventName = eventName;
        }

        public string Url { get; private set; }
        public string Abi { get; private set; }
        public string ContractAddress { get; private set; }
        public string EventName { get; set; }
    }
}
