using Banking.Domain;
using Banking.Application;
namespace Banking.Infrastructure
{
     public class Customervalidator : ICustomerValidator
     {
          public bool validateCustomer(Customer customer, IEnumerable<string> usedEmails, out string ValidationMessage)
          {
               if (string.IsNullOrWhiteSpace(customer.FullName))
               {
                    ValidationMessage = "Full name is required.";
                    return false;
               }
               if (string.IsNullOrWhiteSpace(customer.EmailAddress) || !customer.EmailAddress.Contains("@"))
               {
                    ValidationMessage = "A valid email address is required.";
                    return false;
               }

               if (usedEmails.Contains(customer.EmailAddress, StringComparer.OrdinalIgnoreCase))
               {
                    ValidationMessage = "Unique email adress is required.";
                    return false;
               }

               ValidationMessage = "";
               return true;
          }
     }
}