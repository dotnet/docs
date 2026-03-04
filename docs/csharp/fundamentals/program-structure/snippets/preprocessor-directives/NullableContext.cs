namespace MyApp.Data;

// <NullableDirective>
#nullable enable
class CustomerRepository
{
    // With #nullable enable, the compiler warns if you return null
    // without declaring the return type as nullable:
    public string? FindCustomerName(int id)
    {
        if (id == 1)
        {
            return "Alice";
        }
        return null; // No warning — return type is string?
    }
}
#nullable restore
// </NullableDirective>
