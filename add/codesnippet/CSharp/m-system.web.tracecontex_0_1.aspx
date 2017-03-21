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
    Response.Write("<table>");
    foreach(object o in e.TraceRecords)
    {
        r = (TraceContextRecord)o;
        Response.Write(String.Format("<tr><td>{0}</td><td>{1}</td></tr>", r.Message, r.Category));        
    }
    Response.Write("</table>");
}       
</script>