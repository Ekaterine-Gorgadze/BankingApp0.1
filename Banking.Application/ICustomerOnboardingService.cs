using Banking.Domain;

namespace Banking.Application
{
     public interface ICustomerOnboardingService
     {
          bool createAccount(Customer customer, out string message);
     }
}