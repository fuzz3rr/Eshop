using Eshop.Application.Configuration.Commands;
using Eshop.Domain.Customers;
using Eshop.Domain.SeedWork;

namespace Eshop.Application.Customers.Commands;

public class CreateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCustomerCommand, Guid>
{
    public async Task<Guid> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(command.Name);

        customerRepository.Add(customer);

        await unitOfWork.CommitAsync(cancellationToken);

        return customer.Id;
    }
}