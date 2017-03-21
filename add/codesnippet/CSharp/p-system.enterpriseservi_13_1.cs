[MustRunInClientContext(false)]
public class MustRunInClientContextAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the MustRunInClientContextAttribute applied to the class.
        MustRunInClientContextAttribute attribute =
            (MustRunInClientContextAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(MustRunInClientContextAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("MustRunInClientContextAttribute.Value: {0}",
            attribute.Value);
    }
}