// See https://aka.ms/new-console-template for more information
namespace BankingAppV01
{
     class Program
     {
          static void Main(string[] args)
          {
               BankAccount b1 = new BankAccount(100.00m);
               Console.WriteLine(b1.Withdraw(120.00m).Message);
               //Console.WriteLine(b1.Deposit(90.00m));
               Customer c1 = new Customer("Kato Gorgadze", "kato@zencode.one");
               c1.OpenNewAccount(10000.00m);
               c1.OpenNewAccount(900.99m);
               c1.OpenNewAccount(789.99m);
               Console.WriteLine(c1.ListAccounts());

          }
     }
}
