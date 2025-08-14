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

               if (amount < 0) throw new ArgumentException("Amount must be positive, Try again");

               Amount = amount;
          }
     }
}