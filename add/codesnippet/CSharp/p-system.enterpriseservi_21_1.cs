[LoadBalancingSupported(false)]
public class LoadBalancingSupportedAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the LoadBalancingSupportedAttribute applied to the class.
        LoadBalancingSupportedAttribute attribute =
            (LoadBalancingSupportedAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(LoadBalancingSupportedAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("LoadBalancingSupportedAttribute.Value: {0}",
            attribute.Value);
    }
}