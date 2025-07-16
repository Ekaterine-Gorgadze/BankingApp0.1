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

          
     }
}