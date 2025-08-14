namespace Banking.Domain.ValueObjects
{
     public readonly struct CustomerId
     {
          public Guid AccountId { get; }
          public CustomerId(Guid value)
          {
                AccountId = value;
          }

          public static CustomerId NewId()
          {
               return new CustomerId(Guid.NewGuid());
          }
     }
}