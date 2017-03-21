[Transaction(TransactionOption.Required)]
public class ContextUtil_DisableCommit : ServicedComponent
{
    public void Example()
    {
        // Set both the consistent bit and the done bit to false for the
        // current COM+ context.
        ContextUtil.DisableCommit();
    }
}