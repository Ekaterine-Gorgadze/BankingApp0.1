namespace Banking.Domain.ValueObjects
{
     public readonly struct EmailAddress
     {
          public string Email { get; }

          public EmailAddress(string email)
          {
               if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(email) ||
               !email.Contains("@"))
               {
                    throw new ArgumentException("Invalid Email Address, Try again.");
               }

               Email = email;
          }
     }
}