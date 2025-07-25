using System.Linq;
namespace BankingAppV01{
     public interface ICustomerValidator{
          bool validateCustomer(Customer customer, IEnumerable<string> usedEmails, out string ValidationMessage);
     }
}