namespace Banking.Domain
{
     public interface ITransactionLogger
     {
          void Log(string message);
     }
}