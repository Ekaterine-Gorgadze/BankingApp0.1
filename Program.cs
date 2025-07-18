// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

namespace BankingAppV01
{
     class Program
     {
          static void Main(string[] args)
          {
               //BankAccount b1 = new BankAccount(100.00m);
               //Console.WriteLine(b1.Withdraw(120.00m).Message);
               //Console.WriteLine(b1.Deposit(90.00m));
               Customer c1 = new Customer("Kato Gorgadze", "kato@zencode.one");
               //c1.OpenNewAccount(10000.00m);
               //c1.OpenNewAccount(900.99m);
               //c1.OpenNewAccount(789.99m);
               //Console.WriteLine(c1.ListAccounts());
               HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
               List<Customer> customers = new List<Customer>();
               customers.Add(c1);
               string answer = "";
               ITransactionLogger logger = new ConsoleTransactionLogger();
               do
               {
                    Console.WriteLine("Welcome to BankingApp0.1");
                    Console.WriteLine("------------------------");
                    Console.Write("Would you like to open a bank account? (yes/no) ");
                    answer = Console.ReadLine().Trim();
                    if (string.Equals("no", answer, StringComparison.OrdinalIgnoreCase))
                    {
                         Console.WriteLine("Goodbye! Press any key to exit.");
                         Console.ReadKey();
                         return;
                    }
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine().Trim();
                    string email = "";
                    decimal deposit = 0.00m;
                    bool isEmailAvailable = false;
                    do
                    {
                         Console.Write("Enter your email: ");
                         email = Console.ReadLine().Trim();
                         isEmailAvailable = emails.Add(email);
                         if (!isEmailAvailable) Console.WriteLine("Email unavailable try again.");

                    } while (!isEmailAvailable);
                    Customer newC = new Customer(name, email);
                    customers.Add(newC);
                    do
                    {
                         Console.Write("Registration successful! Enter your initial deposit: ");
                         deposit = decimal.Parse(Console.ReadLine().Trim());
                         if (deposit <= 0) Console.WriteLine("Deposit has to be a positive number. Try again.");
                    } while (deposit <= 0);
                    newC.OpenNewAccount(deposit,logger);
                    BankAccount newB = new BankAccount(deposit,logger);
                    Console.WriteLine("Account created!");
                    string answer2 = "";
                    decimal newDeposit = 0.00m;
                    decimal withdrawalAmount = 0.00m;

                    do
                    {
                         Console.Write("What would you like to do next? (deposit/withdraw/exit) ");
                         answer2 = Console.ReadLine().Trim();
                         if (answer2.Equals("deposit", StringComparison.OrdinalIgnoreCase))
                         {
                              do
                              {
                                   Console.Write("Enter the amount you want to deposit: ");
                                   newDeposit = decimal.Parse(Console.ReadLine().Trim());
                                   if (newDeposit <= 0) Console.WriteLine("Deposit has to be a positive number. Try again.");
                              } while (newDeposit <= 0);
                              newB.Deposit(newDeposit);
                              Console.WriteLine("Deposit Successful.");
                         }
                         else if (answer2.Equals("withdraw", StringComparison.OrdinalIgnoreCase))
                         {
                              do
                              {
                                   Console.Write("Enter the amount you want to withdraw: ");
                                   withdrawalAmount = decimal.Parse(Console.ReadLine().Trim());
                                   if (withdrawalAmount > newB.getBalance()) Console.WriteLine("Not enough balance. Try again.");
                              } while (withdrawalAmount > newB.getBalance());
                              newB.Withdraw(withdrawalAmount);
                              Console.WriteLine("Withdrawal Successful.");
                         }
                         else
                         {
                              Console.WriteLine("Goodbye! Press any key to exit.");
                              Console.ReadKey();
                              continue;
                         }

                    } while (!string.Equals(answer2, "exit", StringComparison.OrdinalIgnoreCase));

               }
               while (string.Equals("yes", answer, StringComparison.OrdinalIgnoreCase));
               

          }
     }
}
