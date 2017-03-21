[JustInTimeActivation(false)]
public class JITAAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the JustInTimeActivationAttribute applied to the class.
        JustInTimeActivationAttribute attribute =
            (JustInTimeActivationAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(JustInTimeActivationAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("JustInTimeActivationAttribute.Value: {0}",
            attribute.Value);
    }
}