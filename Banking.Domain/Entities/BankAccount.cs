using Banking.Domain.Events;
using Banking.Domain.ValueObjects;
namespace Banking.Domain.Entites
{
     public class BankAccount
     {
          public Guid AccountId { get; }
          private Money Balance;
          public Money _Balance => Balance;
          public CustomerId customerId { get; }

          private readonly List<object> DomainEvents = new List<object>();
          public IReadOnlyCollection<object> _DomainEvents => DomainEvents;

          public BankAccount(Money InitialBalance, CustomerId Id)
          {
               if (InitialBalance.Amount <= 0) throw new ArgumentException("Initial Balance Must Be Positive.");
               Balance = InitialBalance;
               AccountId = Guid.NewGuid();
               if (Id.Equals(null)) throw new ArgumentNullException("Customer Id Is Null, Try Again.");
               customerId = Id;

          }

          public void Deposit(Money amount)
          {
               if (amount.Amount <= 0) throw new ArgumentException("The Deposit Must be Positive.");
               Balance.Add(amount);
          }

          public void Withdraw(Money amount)
          {
               if (amount.Amount <= 0) throw new ArgumentException("The Amount Must be Positive.");
               if (amount.Amount > Balance.Amount) throw new ArgumentException("Not Enough Balance, Try again.");
               Balance.Subtract(amount);
               if (Balance.Amount < 10) DomainEvents.Add(new AccountOverdrawnEvent(AccountId));
          }

          public Money getBalance()
          {
               return Balance;
          }

     }
}