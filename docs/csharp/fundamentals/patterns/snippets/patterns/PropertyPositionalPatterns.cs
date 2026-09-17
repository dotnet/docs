static class PropertyPositionalPatterns
{
    public static void Run()
    {
        Console.WriteLine(NeedsSpecialHandling(
            new Package("International", 24)));
        Console.WriteLine(SelectFulfillmentTeam(
            new ShippedOrder(new Address("CA"))));
        Console.WriteLine(ClassifyPoint(new GridPoint(0, 5)));
        Console.WriteLine(GetCrossingInstruction(
            PedestrianSignal.Walk, crossingIsClear: true));
    }

    // <PropertyPattern>
    static bool NeedsSpecialHandling(Package package) =>
        package is { Destination: "International", WeightKg: > 20 };

    sealed record Package(string Destination, decimal WeightKg);
    // </PropertyPattern>

    // <NestedPropertyPattern>
    static string SelectFulfillmentTeam(Order? order) =>
        order switch
        {
            StorePickup => "Store team",
            ShippedOrder { Address.CountryCode: not "US" } =>
                "International shipping team",
            ShippedOrder => "Domestic shipping team",
            null => "No order to fulfill",
            _ => "Order review team"
        };

    abstract record Order;
    sealed record StorePickup : Order;
    sealed record ShippedOrder(Address Address) : Order;
    sealed record Address(string CountryCode);
    // </NestedPropertyPattern>

    // <PositionalPattern>
    static string ClassifyPoint(GridPoint point) =>
        point switch
        {
            (0, 0) => "Origin",
            (0, _) => "On the vertical axis",
            (_, 0) => "On the horizontal axis",
            _ => "Away from both axes"
        };

    readonly record struct GridPoint(int X, int Y);
    // </PositionalPattern>

    // <TuplePattern>
    static string GetCrossingInstruction(
        PedestrianSignal signal, bool crossingIsClear) =>
        (signal, crossingIsClear) switch
        {
            (PedestrianSignal.Walk, true) => "Cross now",
            (PedestrianSignal.Walk, false) => "Wait for the crossing to clear",
            _ => "Wait for the walk signal"
        };

    enum PedestrianSignal
    {
        Stop,
        Walk
    }
    // </TuplePattern>
}
