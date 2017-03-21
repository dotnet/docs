[Transaction(Timeout=30)]
public class TransactionAttribute_Timeout : ServicedComponent
{
    public void TimeoutExample()
    {
        // Get the TransactionAttribute applied to the class.
        TransactionAttribute attribute =
            (TransactionAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(TransactionAttribute),
            false);

        // Display the current value of the attribute's Timeout property.
        Console.WriteLine("TransactionAttribute.Timeout: {0}",
            attribute.Timeout);

        // Set the Timeout property value of the attribute to sixty
        // seconds.
        attribute.Timeout = 60;

        // Display the new value of the attribute's Timeout property.
        Console.WriteLine("TransactionAttribute.Timeout: {0}",
            attribute.Timeout);
    }
}