namespace Banking.Domain.Events;
public class AccountOverdrawnEvent
{
    public Guid AccountId { get; }

    public AccountOverdrawnEvent(Guid accountId)
    {
        AccountId = accountId;
    }
}