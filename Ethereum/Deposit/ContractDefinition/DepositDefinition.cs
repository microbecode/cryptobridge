using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Ethereum.Contracts.Deposit.ContractDefinition
{


    public partial class DepositDeployment : DepositDeploymentBase
    {
        public DepositDeployment() : base(BYTECODE) { }
        public DepositDeployment(string byteCode) : base(byteCode) { }
    }

    public class DepositDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b506040516101ec3803806101ec8339818101604052602081101561003357600080fd5b5051600080546001600160a01b039092166001600160a01b0319909216919091179055610187806100656000396000f3fe608060405234801561001057600080fd5b50600436106100365760003560e01c8063b6b55f251461003b578063fc0c546a1461005a575b600080fd5b6100586004803603602081101561005157600080fd5b503561007e565b005b610062610143565b604080516001600160a01b039092168252519081900360200190f35b60008054604080516323b872dd60e01b81523360048201523060248201526044810185905290516001600160a01b03909216926323b872dd926064808401936020939083900390910190829087803b1580156100d957600080fd5b505af11580156100ed573d6000803e3d6000fd5b505050506040513d602081101561010357600080fd5b5050604080513381526020810183905281517f2da466a7b24304f47e87fa2e1e5a81b9831ce54fec19055ce277ca2f39ba42c4929181900390910190a150565b6000546001600160a01b03168156fea265627a7a72315820847df51b9fec7deef0eeb1bd70df8354783e9272cfdc63ae619091074f47615364736f6c63430005110032";
        public DepositDeploymentBase() : base(BYTECODE) { }
        public DepositDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_token", 1)]
        public virtual string Token { get; set; }
    }

    public partial class DepositFunction : DepositFunctionBase { }

    [Function("deposit")]
    public class DepositFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class TokenFunction : TokenFunctionBase { }

    [Function("token", "address")]
    public class TokenFunctionBase : FunctionMessage
    {

    }

    public partial class DepositedEventDTO : DepositedEventDTOBase { }

    [Event("Deposited")]
    public class DepositedEventDTOBase : IEventDTO
    {
        [Parameter("address", "", 1, false )]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("uint256", "", 2, false )]
        public virtual BigInteger ReturnValue2 { get; set; }
    }



    public partial class TokenOutputDTO : TokenOutputDTOBase { }

    [FunctionOutput]
    public class TokenOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
