namespace Eshop.Contracts;

public class CreateCustomerRequest
{
    public string Name { get; }

    private CreateCustomerRequest()
    {
    }

    public CreateCustomerRequest(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}