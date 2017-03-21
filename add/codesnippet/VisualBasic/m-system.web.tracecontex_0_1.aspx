<%@ Page language="VB" Trace="true" %>
<script runat="server">
' The Page_Load method.
Private Sub Page_Load(sender As Object, e As EventArgs)

    ' Register a handler for the TraceFinished event.
    AddHandler Trace.TraceFinished, AddressOf OnTraceFinished

    ' Write a trace message.
    Trace.Write("Web Forms Infrastructure Methods", "USERMESSAGE: Page_Load complete.")
End Sub ' Page_Load
 
' A TraceContextEventHandler for the TraceFinished event.
Private Sub OnTraceFinished(sender As Object, e As TraceContextEventArgs)

    Dim r As TraceContextRecord
    Dim o As Object
    
    ' Iterate through the collection of trace records and write 
    ' them to the response stream.
    Response.Write("<table>")
    For Each o In e.TraceRecords
        r = CType(o, TraceContextRecord)
        Response.Write(String.Format("<tr><td>{0}</td><td>{1}</td></tr>", r.Message, r.Category))
    Next
    Response.Write("</table>")

End Sub ' OnTraceFinished
</script>