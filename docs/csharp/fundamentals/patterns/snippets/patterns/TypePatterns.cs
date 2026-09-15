static class TypePatterns
{
    public static void Run()
    {
        Console.WriteLine(CanRoute(new CustomerAddress("15 Pine Street")));
        Console.WriteLine(RouteRequest(new PasswordResetRequest()));
        ShowCompatibility();

        object[] inventory = [new ShippingLabel(), new PackingSlip()];
        Console.WriteLine(ContainsItemOfType<ShippingLabel>(inventory));
    }

    // <TypePattern>
    static bool CanRoute(object? destination) =>
        destination is IRouteStop;
    // </TypePattern>

    // <TypePatternSwitch>
    static string RouteRequest(object request) =>
        request switch
        {
            PasswordResetRequest => "Identity team",
            BillingQuestion => "Billing team",
            SupportRequest => "General support team",
            _ => "Intake team"
        };
    // </TypePatternSwitch>

    // <ClassAndInterface>
    static void ShowCompatibility()
    {
        object destination = new ExpressRouteStop("8 Oak Avenue");

        Console.WriteLine(destination is ExpressRouteStop); // Exact class: True
        Console.WriteLine(destination is RouteStop);        // Base class: True
        Console.WriteLine(destination is IRouteStop);       // Interface: True
    }
    // </ClassAndInterface>

    // <GenericTypePattern>
    static bool ContainsItemOfType<TItem>(IEnumerable<object> inventory)
    {
        foreach (object item in inventory)
        {
            if (item is TItem)
            {
                return true;
            }
        }

        return false;
    }
    // </GenericTypePattern>
}

interface IRouteStop { }
record CustomerAddress(string Street) : IRouteStop;
abstract record RouteStop(string Street) : IRouteStop;
sealed record ExpressRouteStop(string Street) : RouteStop(Street);

abstract record SupportRequest;
sealed record PasswordResetRequest : SupportRequest;
sealed record BillingQuestion : SupportRequest;

sealed record ShippingLabel;
sealed record PackingSlip;
