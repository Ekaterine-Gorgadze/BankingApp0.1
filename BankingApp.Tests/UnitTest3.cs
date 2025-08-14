using NUnit.Framework;
using Moq;

using System.Collections.Generic;
using NUnit.Framework.Internal;
// Enhanced tests using Moq. 
using Banking.Domain;
using Banking.Application;
using Banking.Infrastructure;
namespace BankingApp.Tests
{
     [TestFixture]
     public class Logging_Tests
     {
          [Test]
          public void BankAccountCreation_LogsMessage()
          {
               var mockLogger = new Mock<ITransactionLogger>();
               var bankAccount1 = new BankAccount(0.00m, mockLogger.Object);
               mockLogger.Verify(m => m.Log(It.Is<string>(s => s.Contains("Bank account successfully created, balance : ")
               && s.Contains($"{bankAccount1.getBalance()}"))), Times.Once);
          }

          [Test]
          public void DepositingIntoAccount_LogsMessage()
          {
               var mockLogger = new Mock<ITransactionLogger>();
               BankAccount b1 = new BankAccount(0.00m, mockLogger.Object);
               b1.Deposit(10.00m);
               mockLogger.Verify(m => m.Log(It.IsAny<string>()), Times.Exactly(2));
          }

          [Test]
          public void Withdrawing_NegativeAmount_LogsMessage()
          {
               var mockLogger = new Mock<ITransactionLogger>();
               var bankAccount1 = new BankAccount(0.00m, mockLogger.Object);
               bankAccount1.Withdraw(-10.00m);
               mockLogger.Verify(m => m.Log(It.IsAny<string>()), Times.Exactly(2));
          }

          [Test]
          public void Withdrawing_ExcessAmount_LogsMessage()
          {
               var mockLogger = new Mock<ITransactionLogger>();
               var bankAccount1 = new BankAccount(0.00m, mockLogger.Object);
               bankAccount1.Withdraw(10.00m);
               mockLogger.Verify(m => m.Log(It.IsAny<string>()), Times.Exactly(2));
          }

          [Test]
          public void SuccessfulWithdrawal_LogsMessage()
          {
               var mockLogger = new Mock<ITransactionLogger>();
               var bankAccount1 = new BankAccount(100.00m, mockLogger.Object);
               bankAccount1.Withdraw(10.00m);
               mockLogger.Verify(m => m.Log(It.IsAny<string>()), Times.Exactly(2));
          }

          [Test]
          public void SuccessfulAccountCreation_LogsMessage()
          {
               var mockLogger = new Mock<ITransactionLogger>();
               var validator = new Customervalidator();
               var customer = new Customer("Ekaterine Gorgadze", "ekaterinegorgadze@gmail.com");
               HashSet<string> registeredEmails = new HashSet<string>();
               var onboarder = new CustomerOnboardingService(mockLogger.Object, validator, registeredEmails);
               onboarder.createAccount(customer, out string message);
               mockLogger.Verify(m => m.Log(It.IsAny<string>()), Times.Exactly(2));
          }


     }
}