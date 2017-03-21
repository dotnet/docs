[Transaction(TransactionOption.Required)]
public class ContextUtil_IsInTransaction : ServicedComponent
{
    public void Example()
    {
        // Display whether the current COM+ context is enlisted in a
        // transaction.
        Console.WriteLine("Current context enlisted in transaction: {0}",
            ContextUtil.IsInTransaction);
    }
}