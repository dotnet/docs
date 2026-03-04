// <TypeAlias>
using CustomerList = System.Collections.Generic.List<MyApp.Models.Customer>;

namespace MyApp.Services;

class CustomerService
{
    public CustomerList GetTopCustomers()
    {
        CustomerList customers = [new() { Name = "Alice" }, new() { Name = "Bob" }];
        return customers;
    }
}
// </TypeAlias>
