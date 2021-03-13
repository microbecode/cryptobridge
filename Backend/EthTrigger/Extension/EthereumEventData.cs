using Nethereum.Hex.HexTypes;
using System.Collections.Generic;

namespace EthTrigger.Extension
{
    public class EthereumEventData
    {
        public Dictionary<string, string> Values { get; internal set; }
        public HexBigInteger BlockNumber { get; internal set; }
    }
}