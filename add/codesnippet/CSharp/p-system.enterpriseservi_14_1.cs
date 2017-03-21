[Transaction(TransactionOption.RequiresNew)]
public class TransactionAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the TransactionAttribute applied to the class.
        TransactionAttribute attribute =
            (TransactionAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(TransactionAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("TransactionAttribute.Value: {0}",
            attribute.Value);
    }
}