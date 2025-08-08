using BankingAppV01;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
using Moq;
using NUnit.Framework;

namespace BankingApp.Tests
{
     [TestFixture]
     public class Validation_Tests
     {
          [Test]
          public void InvlidName_ReturnsFalse()
          {
               var mockValidator = new Mock<ICustomerValidator>();
               mockValidator.Setup(v => v.validateCustomer(It.IsAny<Customer>(), It.IsAny<IEnumerable<string>>(), out It.Ref<string>.IsAny))
               .Returns(false)
               .Callback((Customer c, IEnumerable<string> e, out string msg) =>
               {
                    msg = "Full name is required.";
               });

               var mockLogger = new Mock<ITransactionLogger>();
               var registeredEmails = new HashSet<string>();
               var onBoarder = new CustomerOnboardingService(mockLogger.Object, mockValidator.Object, registeredEmails);
               var customer = new Customer("", "Ekaterinegorgadze@gmail.com");

               var result = onBoarder.createAccount(customer, out string message);
               Assert.That(result, Is.False);
               Assert.That(message, Is.EqualTo("Full name is required."));
          }

          [Test]
          public void InvalidEmail_ReturnsFalse()
          {
               var mockValidator = new Mock<ICustomerValidator>();
               mockValidator.Setup(v => v.validateCustomer(It.IsAny<Customer>(), It.IsAny<IEnumerable<string>>(), out It.Ref<string>.IsAny))
               .Returns(false)
               .Callback((Customer c, IEnumerable<string> e, out string msg) =>
               {
                    msg = "A valid email address is required.";
               });

               var mockLogger = new Mock<ITransactionLogger>();
               var registeredEmails = new HashSet<string>();
               var onBoarder = new CustomerOnboardingService(mockLogger.Object, mockValidator.Object, registeredEmails);
               var customer = new Customer("Ekaterine Gorgadze", "Ekaterinegorgadzegmail.com");

               var result = onBoarder.createAccount(customer, out string message);
               Assert.That(result, Is.False);
               Assert.That(message, Is.EqualTo("A valid email address is required."));
          }

          [Test]

          public void DuplicateEmail_ReturnsFalse()
          {
               var mockValidator = new Mock<ICustomerValidator>();
               mockValidator.Setup(v => v.validateCustomer(It.IsAny<Customer>(), It.IsAny<IEnumerable<string>>(), out It.Ref<string>.IsAny))
               .Returns(false)
               .Callback((Customer c, IEnumerable<string> e, out string msg) =>
               {
                    msg = "Unique email adress is required.";
               });

               var mockLogger = new Mock<ITransactionLogger>();
               var registeredEmails = new HashSet<string>();
               var onBoarder = new CustomerOnboardingService(mockLogger.Object, mockValidator.Object, registeredEmails);
               var customer1 = new Customer("Ekaterine Gorgadze", "Ekaterinegorgadze@gmail.com");
               var customer2 = new Customer("DHaicbsaibc", "Ekaterinegorgadze@gmail.com");

               onBoarder.createAccount(customer1, out string message);
               var result = onBoarder.createAccount(customer2, out message);

               Assert.That(result, Is.False);
               Assert.That(message, Is.EqualTo("Unique email adress is required."));

          }

          [Test]
          public void SuccessfulValidation_OnboardsCustomer_ReturnsTrue()
          {
               var mockValidator = new Mock<ICustomerValidator>();

               mockValidator
               .Setup(v => v.validateCustomer(
                    It.IsAny<Customer>(),
                    It.IsAny<IEnumerable<string>>(),
                    out It.Ref<string>.IsAny
               ))
               .Returns(true)
               .Callback((Customer c, IEnumerable<string> e, out string msg) => {
               msg = "";
               });
          }
     }
}