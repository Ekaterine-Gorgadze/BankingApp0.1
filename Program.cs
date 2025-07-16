// See https://aka.ms/new-console-template for more information
namespace BankingAppV01
{
     class Program
     {
          static void Main(string[] args)
          {
               BankAccount b1 = new BankAccount(100.00m);
               Console.WriteLine(b1.Withdraw(120.00m).Message);
              Console.WriteLine(b1.Deposit(90.00m));
          }
     }
}
