    // Create a class that inherits from XhtmlTextWriter.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level=AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level=AspNetHostingPermissionLevel.Minimal)] 
    public class CustomXhtmlTextWriter : XhtmlTextWriter
    {
        // Create two constructors, following 
        // the pattern for implementing a
        // TextWriter constructor.
        public CustomXhtmlTextWriter(TextWriter writer) : 
            this(writer, DefaultTabString)
        {
        }


        public CustomXhtmlTextWriter(TextWriter writer, string tabString) : 
            base(writer, tabString)
        {
        }