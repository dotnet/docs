static class Overview
{
    public static void Run()
    {
        Console.WriteLine(GetDeliveryMessage(new ExpressDelivery("ZX-42")));
        PrintTrackingCode(new ExpressDelivery("ZX-42"));
        PrintPackageStatus(null);
        PrintDeliveryUpdate(new ExpressDelivery("ZX-42"));
        Console.WriteLine(GetStatusMessage(new StandardDelivery(2)));
    }

    // <SwitchExpressionOverview>
    static string GetDeliveryMessage(Delivery? delivery) =>
        delivery switch
        {
            null => "No delivery was scheduled.",
            ExpressDelivery express => $"Express package {express.TrackingCode}",
            StandardDelivery { Days: <= 2 } => "Standard delivery arriving soon",
            _ => "Standard delivery"
        };
    // </SwitchExpressionOverview>

    // <IsPatternOverview>
    static void PrintTrackingCode(Delivery delivery)
    {
        if (delivery is ExpressDelivery express)
        {
            Console.WriteLine($"Track express package {express.TrackingCode}");
        }
    }
    // </IsPatternOverview>

    // <NullPatterns>
    static void PrintPackageStatus(Delivery? delivery)
    {
        if (delivery is null)
        {
            Console.WriteLine("No package is available.");
        }
        else
        {
            Console.WriteLine("A package is ready to track.");
        }
    }
    // </NullPatterns>

    // <SwitchStatement>
    static void PrintDeliveryUpdate(Delivery? delivery)
    {
        switch (delivery)
        {
            case null:
                Console.WriteLine("No delivery was scheduled.");
                break;
            case ExpressDelivery express:
                Console.WriteLine($"Express delivery {express.TrackingCode} is ready.");
                Console.WriteLine("Notify the priority desk.");
                break;
            case StandardDelivery standard:
                Console.WriteLine($"Standard delivery arrives in {standard.Days} days.");
                break;
            default:
                Console.WriteLine("Another delivery type is scheduled.");
                break;
        }
    }
    // </SwitchStatement>

    // <StatusMessage>
    static string GetStatusMessage(StandardDelivery delivery) =>
        delivery.Days switch
        {
            0 => "Delivered today",
            1 => "Arriving tomorrow",
            <= 3 => "Arriving soon",
            _ => "In transit"
        };
    // </StatusMessage>
}

abstract record Delivery;
sealed record ExpressDelivery(string TrackingCode) : Delivery;
sealed record StandardDelivery(int Days) : Delivery;
