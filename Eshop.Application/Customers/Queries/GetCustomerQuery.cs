using Eshop.Application.Configuration.Queries;
using Eshop.Contracts.Shared;

namespace Eshop.Application.Customers.Queries;

public class GetCustomerQuery(Guid customerId) : IQuery<CustomerDto>
{
    public Guid CustomerId { get; } = customerId;
}