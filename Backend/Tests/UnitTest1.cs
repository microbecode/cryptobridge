using NUnit.Framework;
using Ethereum.Contracts.Deposit.ContractDefinition;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        private string url = "http://127.0.0.1:8545";
        private string privateKey = "0x8f74caf4d4e74ee73e960fcb6f77f8a7ee80070507ffa99123559faf7066322e";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            await AddDepositContract();
        }

        private async Task AddDepositContract() {
            var account = new Account(privateKey);
            var web3 = new Web3(account, url);

            var deploymentMessage = new DepositDeployment
            {
                Token = ""
            };

            var deploymentHandler = web3.Eth.GetContractDeploymentHandler<DepositDeployment>();
            var transactionReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(deploymentMessage);
            var contractAddress = transactionReceipt.ContractAddress;

            //var balanceOfFunctionMessage = new BalanceOfFunction()
            //{
            //    Owner = account.Address,
            //};

            //var balanceHandler = web3.Eth.GetContractQueryHandler<BalanceOfFunction>();
            //var balance = await balanceHandler.QueryAsync<BigInteger>(contractAddress, balanceOfFunctionMessage);


            //var receiverAddress = "0xde0B295669a9FD93d5F28D9Ec85E40f4cb697BAe";
            //var transferHandler = web3.Eth.GetContractTransactionHandler<TransferFunction>();
            //var transfer = new TransferFunction()
            //{
            //    To = receiverAddress,
            //    TokenAmount = 100
            //};
            //var tr = await transferHandler.SendRequestAndWaitForReceiptAsync(contractAddress, transfer);


            Console.WriteLine();
        }
    }
}