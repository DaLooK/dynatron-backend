using System.Collections.Immutable;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace interview_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ILogger<CustomersController> _logger;
    private readonly CustomersContext _customersContext;

    public CustomersController(ILogger<CustomersController> logger)
    {
        _logger = logger;
        _customersContext = new CustomersContext();
    }

    [HttpGet("")]
    public List<Customer> ListCustomers()
    {
        return _customersContext.Customers.ToList();
    }

    [HttpPost("")]
    public IActionResult CreateCustomer([FromBody] CustomerDto customerData)
    {
        Customer newCustomer = new Customer(customerData);
        _customersContext.Add(newCustomer);
        var result = _customersContext.SaveChanges();

        return result == 1 ? Created("", newCustomer) : Problem();
    }

    [HttpPut("/:id")]
    public IActionResult EditCustomer([FromQuery] int customerId, [FromBody] CustomerDto customerDto)
    {
        var customer = _customersContext.Find<Customer>(customerId);
        if (customer == null)
        {
            return NotFound();
        }

        customer.update(customerDto);
        var result = _customersContext.SaveChanges();
        return result == 1 ? NoContent() : Problem();
    }

    [HttpDelete("/:id")]
    public IActionResult DeleteCustomer([FromQuery] int customerId)
    {
        var customer = _customersContext.Find<Customer>(customerId);
        if (customer == null)
        {
            return NotFound();
        }

        _customersContext.Remove(customer);
        var result = _customersContext.SaveChanges();
        return result == 1 ? NoContent() : Problem();
    }
}