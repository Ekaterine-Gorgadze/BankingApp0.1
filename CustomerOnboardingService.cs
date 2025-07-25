namespace BankingAppV01
{
     public class CustomerOnboardingService : ICustomerOnboardingService
     {
          private readonly ITransactionLogger logger;
          private readonly ICustomerValidator validator;
          private readonly HashSet<string> registeredEmails;

          public CustomerOnboardingService(ITransactionLogger logger, ICustomerValidator validator, HashSet<string> registeredEmails)
          {
               this.logger = logger;
               this.validator = validator;
               this.registeredEmails = registeredEmails;
          }

          public bool createAccount(Customer customer, out string message)
          {
               if(!validator.validateCustomer(customer, registeredEmails, out message)){
                    logger.Log($"Validation failed: {message}");
                    return false;
               }
               customer.OpenNewAccount(1000.00m, logger);
               registeredEmails.Add(customer.EmailAddress);
               message = "Customer onboarded successfully!";
               logger.Log(message);
               return true;
          }
     }
}