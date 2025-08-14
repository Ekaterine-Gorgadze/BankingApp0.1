namespace Banking.Domain.ValueObjects
{
     public readonly struct Money
     {
          public string Currency { get; }
          public decimal Amount { get; }

          public Money(string currency, decimal amount)
          {
               if (string.IsNullOrEmpty(currency) || string.IsNullOrWhiteSpace(currency))
               {
                    throw new ArgumentException("Invalid Currency, Try again.");
               }

               Currency = currency;

               if (amount < 0) throw new ArgumentException("Amount Must Be Positive, Try again");

               Amount = amount;
          }

          public Money Add(Money amount)
          {
               if (amount.Amount < 0) throw new ArgumentException("Deposit Must Be Positive, Try Again.");
               if (!amount.Currency.Equals(Currency)) throw new InvalidOperationException("Currencies Must Match.");
               return new Money(Currency, Amount + amount.Amount);
          }
          
          public Money Subtract(Money amount)
          {
               if (amount.Amount < 0) throw new ArgumentException("Deposit Must Be Positive, Try Again.");
               if (!amount.Currency.Equals(Currency)) throw new InvalidOperationException("Currencies Must Match.");
               if (amount.Amount > Amount) throw new ArgumentException("Not Enough Balance, Try Again");
               return new Money(Currency, Amount - amount.Amount);
          }
     }
}