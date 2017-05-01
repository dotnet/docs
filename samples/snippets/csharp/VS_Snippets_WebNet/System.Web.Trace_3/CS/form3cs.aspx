<!-- <Snippet1> -->
<%@ Page language="c#" Trace="true" %>
<script runat="server">
void Page_Load(object sender, EventArgs e)
{
    // Register a handler for the TraceFinished event.
    Trace.TraceFinished += new 
        TraceContextEventHandler(this.OnTraceFinished);

    // Write a trace message.
    Trace.Write("Web Forms Infrastructure Methods", "USERMESSAGE: Page_Load complete.");
}
 
// A TraceContextEventHandler for the TraceFinished event.
void OnTraceFinished(object sender, TraceContextEventArgs e)
{
    TraceContextRecord r = null;    
    
    // Iterate through the collection of trace records and write 
    // them to the response stream.
    foreach(object o in e.TraceRecords)
    {
        r = (TraceContextRecord)o;
        Response.Write(String.Format("trace message: {0} <BR>", r.Message));
    }
}       
</script>
<!-- </Snippet1> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>
