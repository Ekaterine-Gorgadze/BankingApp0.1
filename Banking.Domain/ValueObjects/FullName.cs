namespace Banking.Domain.ValueObjects
{
     public readonly struct FullName
     {
          public string ForeName { get; }
          public string LastName { get; }

          public FullName(string forename, string lastname)
          {
               if (string.IsNullOrEmpty(forename) || string.IsNullOrWhiteSpace(forename))
               {
                    throw new ArgumentException("Invalid Name, Try again.");
               }
               ForeName = forename;

               if (string.IsNullOrEmpty(lastname) || string.IsNullOrWhiteSpace(lastname))
               {
                    throw new ArgumentException("Invalid Last Name, Try Again.");
               }

               LastName = lastname;
          }
     }
}