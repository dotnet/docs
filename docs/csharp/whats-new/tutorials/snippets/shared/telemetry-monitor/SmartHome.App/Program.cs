using SmartHome.Core;
using SmartHome.Extensions;

UnionMain();
ClosedMain();

void UnionMain()
{
    // <UnionMain>
    // Union declarations: a Reading holds a double, bool, or string.
    Reading[] readings = [23.5, true, "offline"];
    foreach (Reading reading in readings)
    {
        Console.WriteLine($"Reading: {ReadingReporter.Render(reading)}");
    }
    Console.WriteLine($"Reading: {ReadingReporter.Render(default)}");

    // Migrate from a conventional result type to a union.
    Result<double> ok = 42.0;
    Result<double> bad = new TimeoutException("sensor timed out");
    Console.WriteLine(ResultReporter.Describe(ok));
    Console.WriteLine(ResultReporter.Describe(bad));

    // Generic union reused across numeric widths.
    Sample<byte> raw = (byte)200;
    Sample<short> railed = new Saturated(High: true);
    Console.WriteLine($"Sample: {SampleReporter.Normalize(raw, byte.MaxValue):P0} (in range: {raw.InRange})");
    Console.WriteLine($"Sample: {SampleReporter.Normalize(railed, short.MaxValue):P0} (in range: {railed.InRange})");

    // Custom non-boxing union.
    Console.WriteLine(QuantityReporter.Describe(new Quantity(3)));
    Console.WriteLine(QuantityReporter.Describe(new Quantity(2.5)));
    // </UnionMain>
}

void ClosedMain()
{
    // <ClosedMain>
    // Closed hierarchy with an exhaustive switch.
    Sensor[] sensors =
    [
        new Temperature(21.4),
        new Humidity(55),
        new Contact(Open: true),
    ];
    foreach (Sensor sensor in sensors)
    {
        Console.WriteLine($"Sensor: {SensorReporter.Describe(sensor)}");
    }

    // <DoorContactConsume>
    // A DoorContact from another assembly still matches the Contact case.
    Sensor frontDoor = new DoorContact(Open: false, Door: "Front");
    Console.WriteLine($"Sensor: {SensorReporter.Describe(frontDoor)}");
    // </DoorContactConsume>

    // Generic closed hierarchy.
    Report<string> report = new Group<string>(
        new Single<string>("Kitchen"),
        new Group<string>(new Single<string>("Garage"), new Single<string>("Attic")));
    Console.WriteLine($"Report leaves: {ReportReporter.Count(report)}");
    // </ClosedMain>
}
