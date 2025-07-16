namespace BankingAppV01 {
     public class BankAccount
     {
          private decimal Balance { get; set; }
          private Guid AccountNumber { get; set; }

          public BankAccount(decimal initial_balance)
          {
               if (initial_balance < 0.00m)
               {
                    throw new ArgumentException("Invalid input. Balance can not be negative.");
               }
               Balance = initial_balance;
               AccountNumber = Guid.NewGuid();
          }

          public void Deposit(decimal amount)
          {
               if (amount <= 0.00m) throw new ArgumentException("Invalid input. Deposit amount can not be negative or 0.");
               Balance += amount;
          }

          public OperationResult Withdraw(decimal amount)
          {
               if (amount <= 0)
                    return OperationResult.Fail("The amount must be positive.");

               if (amount > Balance)
                    return OperationResult.Fail("Withdrawal amount can not be more than the Balance.");

               Balance -= amount;
               return OperationResult.Successful("Withdrawal Successful");
          }


     }
}