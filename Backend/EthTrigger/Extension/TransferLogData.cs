using Ethereum.Contracts.Token.ContractDefinition;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EthTrigger.Extension
{
    public class TransferLogData
    {   
        public FilterLog Log { get; set; }
        public TransferEventDTO Transfer { get; set; }
    }
}
