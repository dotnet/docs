
public partial class customeditablebox : System.Web.UI.UserControl, IEditableTextControl
{
    private static readonly object EventCustomTextChanged = new Object();

    public event EventHandler TextChanged
    {
        add
        {
            Events.AddHandler(EventCustomTextChanged, value);
        }
        remove
        {
            Events.RemoveHandler(EventCustomTextChanged, value);
        }
    }

    public string Text
    {
        get
        {
            // Provide implementation.
            return String.Empty;
        }
        set
        {
            // Provide implementation.
        }
    }
}