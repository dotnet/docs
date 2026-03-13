// <Gadget>
public struct Gadget : IDescribable<Gadget>
{
    public static string TypeName => "Gadget";

    // Overrides the default Describe() with a custom message
    public static string Describe() => $"{TypeName} (version 2.0)";
}
// </Gadget>
