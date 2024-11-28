using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Customers.Events;

public class CustomerCreatedEvent : DomainEventBase
{
    public Guid CustomerId { get; }
    public string Name { get; }
    
    public CustomerCreatedEvent(Guid customerId, string name)
    {
        CustomerId = customerId;
        Name = name;
    }
}