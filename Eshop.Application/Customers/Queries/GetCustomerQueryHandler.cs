using AutoMapper;
using Eshop.Application.Configuration.Queries;
using Eshop.Contracts.Shared;
using Eshop.Domain.Customers;

namespace Eshop.Application.Customers.Queries;

public class GetCustomerQueryHandler(
    ICustomerRepository customerRepository,
    IMapper mapper) : IQueryHandler<GetCustomerQuery, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<CustomerDto> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(query.CustomerId);
        return _mapper.Map<CustomerDto>(customer);
    }
}