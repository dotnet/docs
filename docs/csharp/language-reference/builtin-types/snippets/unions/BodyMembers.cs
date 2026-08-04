// <BodyMembers>
public record class Meters(double Value);
public record class Feet(double Value);

public union Length(Meters, Feet)
{
    public double TotalMeters => this switch
    {
        Meters m => m.Value,
        Feet f => f.Value * 0.3048,
        _ => throw new InvalidOperationException("The Length has no value."),
    };

    public Length Add(Length other) => new Meters(TotalMeters + other.TotalMeters);
}
// </BodyMembers>

public static class BodyMembersScenario
{
    public static void Run()
    {
        BodyMembersExample();
    }

    // <BodyMembersExample>
    static void BodyMembersExample()
    {
        Length distance = new Meters(10.0);
        Length height = new Feet(3.0);

        Console.WriteLine(distance.TotalMeters); // output: 10
        Console.WriteLine(height.TotalMeters);   // output: 0.9144

        Length total = distance.Add(height);
        Console.WriteLine(total.TotalMeters);    // output: 10.9144
    }
    // </BodyMembersExample>
}
