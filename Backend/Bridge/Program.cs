using Bridge.Contracts;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Something();
            s.TestStuff().GetAwaiter().GetResult();
        }
    }
    public class Something { 
        public async Task TestStuff()
        {
            var url = "http://127.0.0.1:8545"; // "http://testchain.nethereum.com:8545";
            var privateKey = "0x074ad2942c838d174010191fe2becf0c5ece070381f7775cb102128814c787aa";
            var account = new Account(privateKey);
            var web3 = new Web3(account, url);

            var deploymentMessage = new StandardTokenDeployment
            {
                TotalSupply = 100000
            };

            //var deploymentHandler = web3.Eth.GetContractDeploymentHandler<StandardTokenDeployment>();
            //var transactionReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(deploymentMessage);
            var contractAddress = "0x1cb94c5c6486032a3cc4b92f97c9f8a3882405f2";// transactionReceipt.ContractAddress;

            //var balanceOfFunctionMessage = new BalanceOfFunction()
            //{
            //    Owner = account.Address,
            //};

            //var balanceHandler = web3.Eth.GetContractQueryHandler<BalanceOfFunction>();
            //var balance = await balanceHandler.QueryAsync<BigInteger>(contractAddress, balanceOfFunctionMessage);


            var receiverAddress = "0xde0B295669a9FD93d5F28D9Ec85E40f4cb697BAe";
            var transferHandler = web3.Eth.GetContractTransactionHandler<TransferFunction>();
            var transfer = new TransferFunction()
            {
                To = receiverAddress,
                TokenAmount = 100
            };
            var tr = await transferHandler.SendRequestAndWaitForReceiptAsync(contractAddress, transfer);


            Console.WriteLine();
        }
    }
}
