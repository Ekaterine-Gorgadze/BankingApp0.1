using Banking.Domain;
using Banking.Application;
namespace Banking.Infrastructure
{
     public class ConsoleTransactionLogger : ITransactionLogger
     {
          public void Log(string message)
          {
               Console.WriteLine(message);
          }
     }
}