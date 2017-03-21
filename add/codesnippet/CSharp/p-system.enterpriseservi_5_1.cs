[Transaction(Isolation=TransactionIsolationLevel.Serializable)]
public class TransactionAttribute_Isolation : ServicedComponent
{
    public void IsolationExample()
    {
        // Get the TransactionAttribute applied to the class.
        TransactionAttribute attribute =
            (TransactionAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(TransactionAttribute),
            false);

        // Display the current value of the attribute's Isolation property.
        Console.WriteLine("TransactionAttribute.Isolation: {0}",
            attribute.Isolation);

        // Set the Isolation property value of the attribute.
        attribute.Isolation = TransactionIsolationLevel.RepeatableRead;

        // Display the new value of the attribute's Isolation property.
        Console.WriteLine("TransactionAttribute.Isolation: {0}",
            attribute.Isolation);
    }
}