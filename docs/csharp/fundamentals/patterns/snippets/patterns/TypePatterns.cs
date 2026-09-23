static class TypePatterns
{
    public static void Run()
    {
        Console.WriteLine(CanRoute(new CustomerAddress("15 Pine Street"))
            ? "Add the destination to the route plan."
            : "Reject the destination.");
        ShowCompatibility();
        Console.WriteLine(RouteRequest(new PasswordResetRequest()));

        ShowConfidentialBatchHandling();
    }

    // <TypePattern>
    static bool CanRoute(object? destination) =>
        destination is IRouteStop;
    // </TypePattern>

    // <TypePatternSwitch>
    static string RouteRequest(object request) =>
        request switch
        {
            PasswordResetRequest => "Identity queue",
            BillingQuestion => "Billing queue",
            SupportRequest => "General support queue",
            _ => "Intake queue"
        };
    // </TypePatternSwitch>

    // <ClassAndInterface>
    interface IRouteStop { }

    abstract class RouteStop(string street) : IRouteStop
    {
        public string Street { get; } = street;

        public string GetDisplayName() => Street;
    }

    sealed class ExpressRouteStop(string street) : RouteStop(street)
    {
    }

    static void ShowCompatibility()
    {
        object destination = new ExpressRouteStop("8 Oak Avenue");

        Console.WriteLine($"Exact class: {destination is ExpressRouteStop}");
        Console.WriteLine($"Base class: {destination is RouteStop}");
        Console.WriteLine($"Interface: {destination is IRouteStop}");
    }
    // </ClassAndInterface>

    // <GenericTypePattern>
    static void ShowConfidentialBatchHandling()
    {
        object[] incomingRequests = [new BillingQuestion(), new ConfidentialRequest()];
        bool requiresConfidentialHandling =
            ContainsRequestOfType<ConfidentialRequest>(incomingRequests);

        Console.WriteLine(requiresConfidentialHandling
            ? "Send the entire batch to confidential handling."
            : "Send the batch to standard handling.");
    }

    static bool ContainsRequestOfType<TRequest>(IEnumerable<object> requests)
    {
        foreach (object request in requests)
        {
            if (request is TRequest)
            {
                return true;
            }
        }

        return false;
    }
    // </GenericTypePattern>

    sealed class CustomerAddress(string street) : IRouteStop
    {
        public string Street { get; } = street;
    }

    abstract record SupportRequest;
    sealed record PasswordResetRequest : SupportRequest;
    sealed record BillingQuestion : SupportRequest;
    sealed record ConfidentialRequest : SupportRequest;
}
