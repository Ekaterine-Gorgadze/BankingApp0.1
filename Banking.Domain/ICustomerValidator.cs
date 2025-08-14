using System.Linq;
namespace Banking.Domain{
     public interface ICustomerValidator{
          bool validateCustomer(Customer customer, IEnumerable<string> usedEmails, out string ValidationMessage);
     }
}