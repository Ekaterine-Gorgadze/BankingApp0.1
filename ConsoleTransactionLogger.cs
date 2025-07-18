namespace BankingAppV01
{
     public class ConsoleTransactionLogger : ITransactionLogger
     {
          public void Log(string message)
          {
               Console.WriteLine(message);
          }
     }
}