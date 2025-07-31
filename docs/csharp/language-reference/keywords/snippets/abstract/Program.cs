//<snippet1>
public abstract class Vehicle
{
    protected string _brand;
    
    // Constructor - implemented method in abstract class
    public Vehicle(string brand)
    {
        _brand = brand;
    }
    
    // Implemented method - provides functionality that all vehicles share
    public string GetInfo() => $"This is a {_brand} vehicle.";
    
    // Another implemented method
    public virtual void StartEngine() => Console.WriteLine($"{_brand} engine is starting...");
    
    // Abstract method - must be implemented by derived classes
    public abstract void Move();
    
    // Abstract property - must be implemented by derived classes  
    public abstract int MaxSpeed { get; }
}

public class Car : Vehicle
{
    public Car(string brand) : base(brand) { }
    
    // Implementation of abstract method
    public override void Move() => Console.WriteLine($"{_brand} car is driving on the road.");
    
    // Implementation of abstract property
    public override int MaxSpeed => 200;
}

public class Boat : Vehicle
{
    public Boat(string brand) : base(brand) { }
    
    // Implementation of abstract method
    public override void Move() => Console.WriteLine($"{_brand} boat is sailing on the water.");
    
    // Implementation of abstract property
    public override int MaxSpeed => 50;
}

class Program
{
    static void Main()
    {
        // Cannot instantiate abstract class: Vehicle v = new Vehicle("Generic"); // Error!
        
        Car car = new Car("Toyota");
        Boat boat = new Boat("Yamaha");
        
        // Using implemented methods from abstract class
        Console.WriteLine(car.GetInfo());
        car.StartEngine();
        
        // Using abstract methods implemented in derived class
        car.Move();
        Console.WriteLine($"Max speed: {car.MaxSpeed} km/h");
        
        Console.WriteLine();
        
        Console.WriteLine(boat.GetInfo());
        boat.StartEngine();
        boat.Move();
        Console.WriteLine($"Max speed: {boat.MaxSpeed} km/h");
    }
}
/* Output:
This is a Toyota vehicle.
Toyota engine is starting...
Toyota car is driving on the road.
Max speed: 200 km/h

This is a Yamaha vehicle.
Yamaha engine is starting...
Yamaha boat is sailing on the water.
Max speed: 50 km/h
*/
//</snippet1>