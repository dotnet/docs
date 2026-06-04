namespace Patterns.ClosedHierarchy;

// <PaymentMethodTypes>
public closed record class PaymentMethod;
public record class Cash : PaymentMethod;
public record class Card(string Last4) : PaymentMethod;
public record class BankTransfer(string Iban) : PaymentMethod;
// </PaymentMethodTypes>

public static class PaymentMethodExamples
{
    public static string Run(PaymentMethod method) => Describe(method);

    // <DescribePaymentMethod>
    public static string Describe(PaymentMethod method) => method switch
    {
        Cash => "cash",
        Card(var last4) => $"card ending {last4}",
        BankTransfer(var iban) => $"bank transfer to {iban}",
        // No warning: every direct descendant of 'PaymentMethod' is handled.
    };
    // </DescribePaymentMethod>
}

// <ShapeTypes>
// Assembly 1
public closed record class Shape;
public record class Circle(double Radius) : Shape;
internal record class Triangle(double Base, double Height) : Shape;
// </ShapeTypes>

public static class ShapeExamples
{
    // <ShapeAreaSameAssembly>
    // Same assembly: 'Triangle' is visible, so the switch is exhaustive.
    internal static double Area(Shape shape) => shape switch
    {
        Circle(var r) => Math.PI * r * r,
        Triangle(var b, var h) => 0.5 * b * h,
    };
    // </ShapeAreaSameAssembly>

#pragma warning disable CS8509 // Demonstrates the cross-assembly warning by example.
    // <ShapeNameCrossAssembly>
    // Assembly 2
    public static string Name(Shape shape) => shape switch
    {
        Circle => "circle",
        // Warning CS8509: the switch expression doesn't handle all possible values.
        // 'Triangle' is a direct descendant of 'Shape' but isn't visible here.
    };
    // </ShapeNameCrossAssembly>
#pragma warning restore CS8509
}

// <VehicleTypes>
// Assembly 1
public closed record class Vehicle;
public record class Car(int Doors) : Vehicle;
public record class Truck(double PayloadTons) : Vehicle;

// Assembly 2
public record class Sedan(int Doors) : Car;
// </VehicleTypes>

public static class VehicleExamples
{
    // <VehicleCategoryExhaustive>
    public static string Category(Vehicle v) => v switch
    {
        Car => "car",
        Truck => "truck",
        // No warning. The 'Car' arm covers 'Sedan' through ordinary subtype matching.
    };
    // </VehicleCategoryExhaustive>

    // <VehicleCategorySedanFirst>
    public static string CategorySedanFirst(Vehicle v) => v switch
    {
        Sedan => "sedan",
        Car => "car",      // Reachable: 'Car' values that aren't 'Sedan'.
        Truck => "truck",
    };
    // </VehicleCategorySedanFirst>
}

public static class TypeParamGoverningTypeExamples
{
    // <TypeParamGoverningType>
    public static string Describe<X>(X method) where X : PaymentMethod => method switch
    {
        Cash => "cash",
        Card(var last4) => $"card ending {last4}",
        BankTransfer(var iban) => $"bank transfer to {iban}",
        // No warning: 'X' is constrained to the closed type 'PaymentMethod',
        // so handling every direct descendant exhausts the switch.
    };
    // </TypeParamGoverningType>
}
