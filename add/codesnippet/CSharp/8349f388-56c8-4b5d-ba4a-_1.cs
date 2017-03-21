// Creates a  message filter.
[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
public class TestMessageFilter : IMessageFilter
{
    public bool PreFilterMessage(ref Message m)
    {
        // Blocks all the messages relating to the left mouse button.
        if (m.Msg >= 513 && m.Msg <= 515)
        {
            Console.WriteLine("Processing the messages : " + m.Msg);
            return true;
        }
        return false;
    }
}
