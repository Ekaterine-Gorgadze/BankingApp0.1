namespace BankingAppV01
{
     public class OperationResult
     {
          public bool Success { get; }
          public string Message { get; }

          public OperationResult(bool success, string message)
          {
               Success = success;
               Message = message;
          }

          public static OperationResult Successful(string message = "Withdrawal Successful") =>
               new OperationResult(true, message);

          public static OperationResult Fail(string message) =>
               new OperationResult(false, message);
     }
}