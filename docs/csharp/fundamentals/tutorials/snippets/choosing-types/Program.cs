#!/usr/bin/env dotnet

// <TupleDemo>
(int TotalOrders, decimal Revenue) GetDailySummary(int orders, decimal revenue)
    => (orders, revenue);

Console.WriteLine("=== Tuple: daily summary ===");
var summary = GetDailySummary(42, 1234.50m);
Console.WriteLine($"Orders: {summary.TotalOrders}, Revenue: {summary.Revenue:F2}");

var (orders, revenue) = summary;
Console.WriteLine($"Deconstructed: {orders} orders, {revenue:F2}");
// </TupleDemo>

// <RecordClassDemo>
Console.WriteLine("\n=== Record class: MenuItem ===");
var latte = new MenuItem("Latte", 4.50m, "Contains dairy");
var latte2 = new MenuItem("Latte", 4.50m, "Contains dairy");
var seasonal = latte with { Name = "Pumpkin Spice Latte", Price = 5.25m };

Console.WriteLine(latte);
Console.WriteLine(seasonal);
Console.WriteLine($"Same reference (latte vs latte2): {ReferenceEquals(latte, latte2)}");
Console.WriteLine($"Value equal (latte vs latte2):    {latte == latte2}");
Console.WriteLine($"Value equal (latte vs seasonal):  {latte == seasonal}");
// </RecordClassDemo>

// <RecordStructDemo>
Console.WriteLine("\n=== Record struct: Measurement ===");
var temp = new Measurement(72.5, "°F");
var copy = temp;

copy = copy with { Value = 23.0, Unit = "°C" };

Console.WriteLine($"Original: {temp.Value}{temp.Unit}");
Console.WriteLine($"Copy (converted): {copy.Value}{copy.Unit}");
// </RecordStructDemo>

// <ClassDemo>
Console.WriteLine("\n=== Class: Order ===");
var order = new Order();
order.AddItem("Latte", 4.50m);
order.AddItem("Croissant", 3.25m);
order.Status = "Ready";

Console.WriteLine(order);
// </ClassDemo>

// <InheritanceDemo>
Console.WriteLine("\n=== Inheritance: CateringOrder ===");
var catering = new CateringOrder(minimumGuests: 20);
catering.AddItem("Coffee (serves 20)", 45.00m);
catering.AddItem("Pastry platter", 60.00m);

try
{
    catering.Status = "Ready";
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Blocked: {ex.Message}");
}

catering.Approve("Sam");
catering.Status = "Ready";
Console.WriteLine(catering);
// </InheritanceDemo>

// <InterfaceDemo>
static decimal Checkout(decimal total, IDiscountPolicy policy) => policy.Apply(total);

Console.WriteLine("\n=== Interface: discount policy ===");
decimal subtotal = 12.00m;
Console.WriteLine($"Happy hour (20% off): {Checkout(subtotal, new HappyHourDiscount()):F2}");
Console.WriteLine($"Loyalty ($1 off):     {Checkout(subtotal, new LoyaltyDiscount()):F2}");
// </InterfaceDemo>

// <EvolveTupleToRecord>
Console.WriteLine("\n=== Evolve: tuple -> record ===");
var daily = new DailySummary(120, 525.75m);
Console.WriteLine(daily);
Console.WriteLine($"Average ticket: {daily.AverageTicket:F2}");
// </EvolveTupleToRecord>

// <EvolveStructToClass>
Console.WriteLine("\n=== Evolve: struct -> class ===");
var raw = new SensorReading(72.5, "°F");
var calibrated = new CalibratedReading(72.5, "°F", offset: -0.3);

Console.WriteLine($"Raw:        {raw.Display()}");
Console.WriteLine($"Calibrated: {calibrated.Display()}");
// </EvolveStructToClass>

// <EvolveClassToInterface>
Console.WriteLine("\n=== Evolve: class -> class + interface ===");
static void PrintOrderSummary(IOrder o) =>
    Console.WriteLine($"  {o.Total:F2} [{o.Status}]");

var walkIn = new Order();
walkIn.AddItem("Mocha", 5.00m);
walkIn.Status = "Ready";

var banquet = new CateringOrder(minimumGuests: 50);
banquet.AddItem("Coffee service", 90.00m);
banquet.Approve("Alex");
banquet.Status = "Ready";

Console.WriteLine("All orders:");
foreach (IOrder o in new IOrder[] { walkIn, banquet })
    PrintOrderSummary(o);
// </EvolveClassToInterface>

// <MenuItem>
record class MenuItem(string Name, decimal Price, string NutritionalNote);
// </MenuItem>

// <Measurement>
record struct Measurement(double Value, string Unit);
// </Measurement>

// <DailySummary>
record class DailySummary(int TotalOrders, decimal Revenue)
{
    public decimal AverageTicket => TotalOrders > 0 ? Revenue / TotalOrders : 0m;
}
// </DailySummary>

// <SensorReading>
class SensorReading(double value, string unit)
{
    public double Value { get; } = value;
    public string Unit { get; } = unit;

    public virtual string Display() => $"{Value}{Unit}";
}

class CalibratedReading(double value, string unit, double offset)
    : SensorReading(value, unit)
{
    public double Offset { get; } = offset;

    public override string Display() => $"{Value + Offset}{Unit} (offset {Offset:+0.0;-0.0})";
}
// </SensorReading>

// <IOrder>
interface IOrder
{
    string Status { get; set; }
    decimal Total { get; }
}
// </IOrder>

// <Order>
class Order : IOrder
{
    public virtual string Status { get; set; } = "Pending";
    private readonly List<(string Name, decimal Price)> _items = [];

    public void AddItem(string name, decimal price) => _items.Add((name, price));

    public decimal Total => _items.Sum(i => i.Price);

    public override string ToString() =>
        $"Order [{Status}]: {string.Join(", ", _items.Select(i => i.Name))} - Total: {Total:F2}";
}
// </Order>

// <CateringOrder>
class CateringOrder : Order
{
    public int MinimumGuests { get; }
    public string? ApprovedBy { get; private set; }

    public CateringOrder(int minimumGuests) => MinimumGuests = minimumGuests;

    public void Approve(string manager) => ApprovedBy = manager;

    public override string Status
    {
        get => base.Status;
        set
        {
            if (value == "Ready" && ApprovedBy is null)
                throw new InvalidOperationException(
                    "A catering order requires manager approval before it can be marked ready.");
            base.Status = value;
        }
    }

    public override string ToString() =>
        $"Catering [{Status}] for {MinimumGuests}+ guests, approved by: {ApprovedBy ?? "(none)"} - Total: {Total:F2}";
}
// </CateringOrder>

// <Interfaces>
interface IDiscountPolicy
{
    decimal Apply(decimal total);
}

class HappyHourDiscount : IDiscountPolicy
{
    public decimal Apply(decimal total) => total * 0.80m;
}

class LoyaltyDiscount : IDiscountPolicy
{
    public decimal Apply(decimal total) => total - 1.00m;
}
// </Interfaces>
