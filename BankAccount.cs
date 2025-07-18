namespace BankingAppV01 {
     public class BankAccount
     {
          private decimal Balance { get; set; }
          private Guid AccountNumber { get; set; }

          private readonly ITransactionLogger Logger;
          public BankAccount(decimal initial_balance, ITransactionLogger logger)
          {
               if (initial_balance < 0.00m)
               {
                    throw new ArgumentException("Invalid input. Balance can not be negative.");
               }
               Balance = initial_balance;
               AccountNumber = Guid.NewGuid();
               Logger = logger;
               Logger.Log($"Bank account successfully created, balance : {Balance}");
          }

          public void Deposit(decimal amount)
          {
               if (amount <= 0.00m) throw new ArgumentException("Invalid input. Deposit amount can not be negative or 0.");
               Balance += amount;
               Logger.Log($"Deposited amount : {amount}, new balance : {Balance}");
          }

          public OperationResult Withdraw(decimal amount)
          {
               if (amount <= 0)
               {
                    Logger.Log("Withdrawal Unsuccessful.");
                    return OperationResult.Fail("The amount must be positive.");
               }


               if (amount > Balance)
               {
                    Logger.Log("Withdrawal Unsuccessful.");
                    return OperationResult.Fail("Withdrawal amount can not be more than the Balance.");
               }

               Balance -= amount;
               Logger.Log($"Withdrew {amount}, new balance: {Balance}.");
               return OperationResult.Successful("Withdrawal Successful");
          }

          public decimal getBalance()
          {
               return Balance;
          }

          public Guid getAccountNumber()
          {
               return AccountNumber;
          }
     }
}