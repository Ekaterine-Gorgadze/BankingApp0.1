// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using Banking.Domain;
using Banking.Infrastructure;
using Banking.Application;
namespace Banking.ConsoleUI
{
     class Program
     {
          static void Main(string[] args)
          {
            string message = " ";
            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            List<Customer> customers = new List<Customer>();
            string answer = "";

            ITransactionLogger logger = new ConsoleTransactionLogger();
            ICustomerValidator validator = new Customervalidator();
            ICustomerOnboardingService onBoarder = new CustomerOnboardingService(logger, validator, emails);

           
            Customer newCustomer;
            bool success;
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

                
                do
               {
                    Console.Write("Enter your full name: ");
                    string name = Console.ReadLine()?.Trim();

                    Console.Write("Enter your email: ");
                    string email = Console.ReadLine()?.Trim();

                    newCustomer = new Customer(name, email);
                    success = onBoarder.createAccount(newCustomer, out message);

                if (!success)
                {
                         Console.WriteLine("Please try again.");
                }

               } while (!success);
               
                decimal withdrawalAmount = 0.00m;
                string answer2 = "";
                decimal newDeposit = 0.00m;

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

                        newCustomer.PrimaryAccount().Deposit(newDeposit);
                        Console.WriteLine("Deposit Successful.");
                    }
                    else if (answer2.Equals("withdraw", StringComparison.OrdinalIgnoreCase))
                    {
                        do
                        {
                            Console.Write("Enter the amount you want to withdraw: ");
                            withdrawalAmount = decimal.Parse(Console.ReadLine().Trim());
                            if (withdrawalAmount > newCustomer.PrimaryAccount().getBalance()) Console.WriteLine("Not enough balance. Try again.");
                        } while (withdrawalAmount > newCustomer.PrimaryAccount().getBalance());

                        newCustomer.PrimaryAccount().Withdraw(withdrawalAmount);
                        Console.WriteLine("Withdrawal Successful.");
                    }
                    else
                    {
                        Console.WriteLine("Goodbye! Press any key to exit.");
                        Console.ReadKey();
                        continue;
                    }

                } while (!string.Equals(answer2, "exit", StringComparison.OrdinalIgnoreCase));

            } while (string.Equals("yes", answer, StringComparison.OrdinalIgnoreCase)); 
          } 
     }
}
