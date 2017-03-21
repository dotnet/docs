[Transaction(TransactionOption.Required)]
public class ContextUtil_EnableCommit : ServicedComponent
{
    public void Example()
    {
        // Set the consistent bit to true and the done bit to false for the
        // current COM+ context.
        ContextUtil.EnableCommit();
    }
}