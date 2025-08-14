namespace Banking.Domain.Events;

using Banking.Domain.ValueObjects;
public class CustomerRegisteredEvent
{
    public CustomerId Id { get;}

    public CustomerRegisteredEvent(CustomerId id)
    {
        Id = id;
    }
}
