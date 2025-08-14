using Banking.Domain.Events;
using Banking.Domain.ValueObjects;

namespace Banking.Domain.Entites
{
     public class Customer
     {
          public CustomerId Id { get; private set; }
          public FullName fullName { get; private set; }
          public EmailAddress emailAddress { get; private set; }
          private readonly List<BankAccount> bankAccounts = new List<BankAccount>();
          public IReadOnlyCollection<BankAccount> _bankAccounts => bankAccounts;

          private readonly List<object> DomainEvents = new List<object>();
          public IReadOnlyCollection<object> _DomainEvents => DomainEvents;

          public Customer(FullName fullname, EmailAddress email)
          {
               Id = CustomerId.NewId();
               if (fullname.Equals(null))
               {
                    throw new ArgumentNullException("Full Name Is Null, Try Again.");
               }

               fullName = fullname;

               if (email.Equals(null))
               {
                    throw new ArgumentNullException("Email Address Is Null, Try Again.");
               }

               emailAddress = email;
               DomainEvents.Add(new CustomerRegisteredEvent(Id));

          }

          public void OpenAccount(Money initialDeposit)
          {
               if (initialDeposit.Amount < 0) throw new ArgumentException("Initial Deposit Must be Positive.");
               BankAccount newBankAccount = new BankAccount(initialDeposit, Id);
               bankAccounts.Add(newBankAccount);
          }

     }
}