<!-- <Snippet1> -->
<%@ Page language="c#" Trace="true" %>
<script runat="server">
void Page_Load(object sender, EventArgs e)
{
    // Register a handler for the TraceFinished event.
    Trace.TraceFinished += new 
        TraceContextEventHandler(this.OnTraceFinished);

    try {
        throw new ArgumentException("Trace Test");
    }
    catch (InvalidOperationException ioe) {    
        // You can write an error trace message using the Write method.
        Trace.Write("Exception Handling", "Exception: Page_Load.", ioe);
    }
    catch (ArgumentException ae) {    
        // You can write a warning trace message using the Warn method.
        Trace.Warn("Exception Handling", "Warning: Page_Load.", ae);
    }
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
        if (r.IsWarning) {
            Response.Write(String.Format("warning message: {0} <BR>", r.Message));
        }
        else {
            Response.Write(String.Format("error message: {0} <BR>", r.Message));
        }

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
