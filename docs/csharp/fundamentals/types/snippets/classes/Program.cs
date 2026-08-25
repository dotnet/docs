// --- Top-level statements ---

// <CreateObject>
var customer = new Customer("Allison");
Console.WriteLine(customer.Name); // Allison
// </CreateObject>

// <ReferenceSemantics>
var c1 = new Customer("Grace");
var c2 = c1; // both variables reference the same object

c2.Name = "Hopper";
Console.WriteLine(c1.Name); // Hopper — c1 sees the change made through c2
// </ReferenceSemantics>

// <UsingRequired>
// var missing = new Person(); // Error: required properties not set
var person = new Person { FirstName = "Grace", LastName = "Hopper" };
Console.WriteLine($"{person.FirstName} {person.LastName}"); // Grace Hopper
// </UsingRequired>

// <UsingStaticClass>
double circumference = MathHelpers.CircleCircumference(5.0);
Console.WriteLine($"Circumference: {circumference:F2}"); // Circumference: 31.42
// </UsingStaticClass>

// <UsingObjectInitializer>
var options = new ConnectionOptions
{
    Host = "db.example.com",
    Port = 5432,
    UseSsl = true
};
Console.WriteLine($"{options.Host}:{options.Port} (SSL: {options.UseSsl})");
// db.example.com:5432 (SSL: True)
// </UsingObjectInitializer>

// <Inheritance>
var manager = new Manager("Satya", "Engineering");
Console.WriteLine($"{manager.Name} manages {manager.Department}");
// Satya manages Engineering
// </Inheritance>

// --- Type declarations ---

// <ClassDeclaration>
public class Customer
{
    public string Name { get; set; }

    public Customer(string name) => Name = name;
}
// </ClassDeclaration>

// <RequiredProperties>
public class Person
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}
// </RequiredProperties>

// <StaticClass>
static class MathHelpers
{
    public static double CircleCircumference(double radius) =>
        2 * Math.PI * radius;
}
// </StaticClass>

// <ObjectInitializer>
class ConnectionOptions
{
    public string Host { get; init; } = "localhost";
    public int Port { get; init; } = 80;
    public bool UseSsl { get; init; }
}
// </ObjectInitializer>

class Employee
{
    public string Name { get; set; }
    public Employee(string name) => Name = name;
}

class Manager : Employee
{
    public string Department { get; set; }

    public Manager(string name, string department) : base(name) =>
        Department = department;
}