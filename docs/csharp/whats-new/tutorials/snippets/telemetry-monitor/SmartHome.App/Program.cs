using SmartHome.Core;
using SmartHome.Extensions;

// <ProgramMain>
// Union declarations: a Reading holds a double, bool, or string.
Reading[] readings = [23.5, true, "offline"];
foreach (Reading reading in readings)
{
    Console.WriteLine($"Reading: {ReadingReporter.Render(reading)}");
}
Console.WriteLine($"Reading: {ReadingReporter.Render(default)}");

// Generic union declaration with a member.
OneOrMore<string> rooms = new(["Kitchen", "Garage"]);
Console.WriteLine($"Rooms: {string.Join(", ", rooms.AsEnumerable())}");

// Migrate from a conventional result type to a union.
Result<double> ok = 42.0;
Result<double> bad = new TimeoutException("sensor timed out");
Console.WriteLine(ResultReporter.Describe(ok));
Console.WriteLine(ResultReporter.Describe(bad));

// Custom non-boxing union.
Console.WriteLine(QuantityReporter.Describe(new Quantity(3)));
Console.WriteLine(QuantityReporter.Describe(new Quantity(2.5)));

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
// </ProgramMain>

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
