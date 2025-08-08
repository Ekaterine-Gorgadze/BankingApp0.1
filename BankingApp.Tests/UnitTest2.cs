using NUnit.Framework;
using Moq;
using BankingAppV01;
using System.Collections.Generic;
using NUnit.Framework.Internal;
namespace BankingApp.Tests
{
     [TestFixture]
     public class OnBoardingSevice_Tests
     {
          [Test]
          public void CreateAccountMethod_IsSuccessful()
          {
               ITransactionLogger logger = new ConsoleTransactionLogger();
               ICustomerValidator validator = new Customervalidator();
               HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
               ICustomerOnboardingService onboarder = new CustomerOnboardingService(logger, validator, emails);
               Customer c1 = new Customer("Ekaterine Gorgadze", "ekaterinegorgadze@gmail.com");
               string message = "";
               bool success = onboarder.createAccount(c1, out message);
               Assert.That(success, Is.True);
               Assert.That(message, Is.EqualTo("Customer onboarded successfully!"));

          }

          [Test]
          public void DuplicateEmails_PreventOnBoarding()
          {
               ITransactionLogger logger = new ConsoleTransactionLogger();
               ICustomerValidator validator = new Customervalidator();
               HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
               ICustomerOnboardingService onboarder = new CustomerOnboardingService(logger, validator, emails);
               Customer c1 = new Customer("Ekaterine Gorgadze", "ekaterinegorgadze@gmail.com");
               Customer c2 = new Customer("John Match", "ekaterinegorgadze@gmail.com");
               string message = "";
               onboarder.createAccount(c1, out message);
               bool success = onboarder.createAccount(c2, out message);
               Assert.That(success, Is.False);
               Assert.That(message, Is.EqualTo("Unique email adress is required."));

          }

          [Test]
          public void InvalidEmails_PreventOnBoarding()
          {
               ITransactionLogger logger = new ConsoleTransactionLogger();
               ICustomerValidator validator = new Customervalidator();
               HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
               ICustomerOnboardingService onboarder = new CustomerOnboardingService(logger, validator, emails);
               Customer c1 = new Customer("Ekaterine Gorgadze", "cnaincebacubcieagmail.com");
               string message;
               bool success = onboarder.createAccount(c1, out message);
               Assert.That(success, Is.False);
               Assert.That(message, Is.EqualTo("A valid email address is required."));
          }

          [Test]
          public void InvalidName_PreventsOnBoarding()
          {
               ITransactionLogger logger = new ConsoleTransactionLogger();
               ICustomerValidator validator = new Customervalidator();
               HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
               ICustomerOnboardingService onboarder = new CustomerOnboardingService(logger, validator, emails);
               Customer c1 = new Customer(" ", "cnaincebacubciea@gmail.com");
               string message;
               bool success = onboarder.createAccount(c1, out message);
               Assert.That(success, Is.False);
               Assert.That(message, Is.EqualTo("Full name is required."));
          }
     }
}