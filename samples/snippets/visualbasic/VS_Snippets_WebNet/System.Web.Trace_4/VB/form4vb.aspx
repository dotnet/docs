<!-- <Snippet1> -->
<%@ Page language="VB" Trace="true" %>
<script runat="server">
' The Page_Load method.
Private Sub Page_Load(sender As Object, e As EventArgs)

    ' Register a handler for the TraceFinished event.
    AddHandler Trace.TraceFinished, AddressOf OnTraceFinished

    Try 
	Dim ae As New ArgumentException("Trace Test")
        Throw ae
    
    catch ioe As InvalidOperationException
        ' You can write an error trace message using the Write method.
        Trace.Write("Exception Handling", "Exception: Page_Load.", ioe)
    
    Catch ae As ArgumentException
        ' You can write a warning trace message using the Warn method.
        Trace.Warn("Exception Handling", "Warning: Page_Load.", ae)

    End Try

End Sub ' Page_Load
 
' A TraceContextEventHandler for the TraceFinished event.
Private Sub OnTraceFinished(sender As Object, e As TraceContextEventArgs)

    Dim r As TraceContextRecord
    Dim o As Object
    
    ' Iterate through the collection of trace records and write 
    ' them to the response stream.

    For Each o In e.TraceRecords
        r = CType(o, TraceContextRecord)
	If r.IsWarning Then
            Response.Write(String.Format("warning message: {0} <BR>", r.Message))
        Else
            Response.Write(String.Format("error message: {0} <BR>", r.Message))
        End If
    Next

End Sub	' OnTraceFinished
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
