using System.Net;
using Ardalis.GuardClauses;
using Eshop.Application.Customers.Commands;
using Eshop.Application.Customers.Queries;
using Eshop.Contracts;
using Eshop.Contracts.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.API.Controllers;

[ApiController]
[Route("api/v1/customers")]
public class CustomerController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = Guard.Against.Null(sender, nameof(sender));

    [HttpPost]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create(
        [FromBody] CreateCustomerRequest request,
        CancellationToken cancellationToken = default)
    {
        var customerId = await _sender.Send(new CreateCustomerCommand(request.Name), cancellationToken);
        return Created($"api/v1/customers/{customerId}", customerId);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<CustomerDto>> Get(
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var customer = await _sender.Send(new GetCustomerQuery(id), cancellationToken);
        return Ok(customer);
    }
}