using NUnit.Framework;
using Moq;

using System.Collections.Generic;
using NUnit.Framework.Internal;
using Banking.Domain;
using Banking.Application;
using Banking.Infrastructure;
namespace BankingApp.Tests
{
    [TestFixture]
    public class BankAccount_Tests
    {
        [Test]
        public void DepositIncreases_AccountBalance()
        {
            ITransactionLogger logger = new ConsoleTransactionLogger();
            BankAccount b1 = new BankAccount(0.00m, logger);
            b1.Deposit(100.00m);
            Assert.That(b1.getBalance(), Is.EqualTo(100.00m));
        }

        [Test]
        public void NegativeInitialBalance_ReturnsErrorMessage()
        {
            ITransactionLogger logger = new ConsoleTransactionLogger();
            var exception = Assert.Throws<ArgumentException>(() => new BankAccount(-50.00m, logger));
            Assert.That(exception.Message, Is.EqualTo("Invalid input. Balance can not be negative."));
        }

        [Test]
        public void NegativeDeposit_ReturnsErrorMessage()
        {
            ITransactionLogger logger = new ConsoleTransactionLogger();
            BankAccount b1 = new BankAccount(0.00m, logger);
            var exception = Assert.Throws<ArgumentException>(() => b1.Deposit(-50.00m));
            Assert.That(exception.Message, Is.EqualTo("Invalid input. Deposit amount can not be negative or 0."));
        }

        [Test]
        public void ExcessWithdrawal_ReturnsErrorMessage()
        {
            ITransactionLogger logger = new ConsoleTransactionLogger();
            BankAccount b1 = new BankAccount(0.00m, logger);
            OperationResult result = b1.Withdraw(10.00m);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Message, Is.EqualTo("Withdrawal amount can not be more than the Balance."));
        }

        [Test]
        public void NegativeWithdrawal_ReturnsErrorMessage()
        {
            ITransactionLogger logger = new ConsoleTransactionLogger();
            BankAccount b1 = new BankAccount(0.00m, logger);
            OperationResult result = b1.Withdraw(-5.00m);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Message, Is.EqualTo("The amount must be positive."));
        }
    }

}
