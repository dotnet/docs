[Synchronization(SynchronizationOption.RequiresNew)]
public class SynchronizationAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the SynchronizationAttribute applied to the class.
        SynchronizationAttribute attribute =
            (SynchronizationAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(SynchronizationAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("SynchronizationAttribute.Value: {0}",
            attribute.Value);
    }
}