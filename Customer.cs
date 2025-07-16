using System;
using System.Collections.Generic;
namespace BankingAppV01
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
               AccountId = new Guid.NewGuid();

          }

          public void OpenNewAccount(decimal initalDeposit)
          {
               // first i'll check if the deposit is positive

               if (initialDeposit <= 0) throw new ArgumentException("Deposit has to be positive");
               // now that we've made sure the deposit is positive we can open a new account
               // meaning that we can add a new account to the list of accounts of the customer class

               BankAccount newAccount = new BankAccount(initialDeposit);
               Accounts.add(newAccount);
          }

          
     }
}