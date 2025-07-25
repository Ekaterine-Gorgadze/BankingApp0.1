namespace BankingAppV01
{
     public interface ICustomerOnboardingService
     {
          bool createAccount(Customer customer, out string message);
     }
}