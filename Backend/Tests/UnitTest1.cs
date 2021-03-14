using NUnit.Framework;
using Ethereum.Contracts.Deposit.ContractDefinition;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Numerics;
using System.Threading.Tasks;
using Ethereum.Contracts.Token.ContractDefinition;

namespace Tests
{
    public class Tests
    {
        private const string url = "http://127.0.0.1:8545";
        private const string privateKey = "0x8f74caf4d4e74ee73e960fcb6f77f8a7ee80070507ffa99123559faf7066322e";
        private Web3 web3 = new Web3(new Account(privateKey), url);

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var supply = 50;
            var tokenContr = "0x39f8e9a7ba6629f81cea3ea66266c3c59351508e";// await DeployToken(supply);
            var depositContr = "0xe7772786d8c4c8082d6116b68c164feffc6f11ee";//await DeployDeposit(tokenContr);

            var transferHandler = web3.Eth.GetContractTransactionHandler<TransferFunction>();
            var transfer = new TransferFunction()
            {
                Recipient = depositContr,
                Amount = 1
            };
            var tr = await transferHandler.SendRequestAndWaitForReceiptAsync(tokenContr, transfer);
            Console.WriteLine();
        }

        private async Task<string> DeployDeposit(string token) {
            var deploymentMessage = new DepositDeployment
            {
                Token = token
            };

            var deploymentHandler = web3.Eth.GetContractDeploymentHandler<DepositDeployment>();
            var transactionReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(deploymentMessage);
            var contractAddress = transactionReceipt.ContractAddress;

            return contractAddress;
        }

        private async Task<string> DeployToken(int supply)
        {
            var deploymentMessage = new TokenDeployment
            {
                TotalSupply = supply
            };
            var deploymentHandler = web3.Eth.GetContractDeploymentHandler<TokenDeployment>();
            var transactionReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(deploymentMessage);
            var contractAddress = transactionReceipt.ContractAddress;

            return contractAddress;
        }
    }
}