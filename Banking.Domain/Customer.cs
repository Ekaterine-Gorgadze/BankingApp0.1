using System;
using System.Collections.Generic;
using System.Linq;
namespace Banking.Domain
{
     public class Customer
     {
          private Guid AccountId;
          public string FullName { get; }
          public string EmailAddress { get; }
          private List<BankAccount> Accounts = new List<BankAccount>();

          public Customer(string name, string email)
          {
               FullName = name;
               EmailAddress = email;
               AccountId = Guid.NewGuid();

          }

          public void OpenNewAccount(decimal initialDeposit, ITransactionLogger logger)
          {
               // first i'll check if the deposit is positive

               if (initialDeposit <= 0.00m) throw new ArgumentException("Deposit has to be positive");
               // now that we've made sure the deposit is positive we can open a new account
               // meaning that we can add a new account to the list of accounts of the customer class

               BankAccount newAccount = new BankAccount(initialDeposit, logger);
               Accounts.Add(newAccount);
          }

          public string Summary(BankAccount b)
          {
               return $"Account Number: {b.getAccountNumber()}\n" + $"Balance: {b.getBalance()}";
          }

          public String ListAccounts()
          {
               if (Accounts.Count == 0) return "No accounts were found.";
               return string.Join("\n\n", Accounts.Select(Summary));
          }

          public BankAccount PrimaryAccount(){
               return Accounts.FirstOrDefault();
          }
     }
}