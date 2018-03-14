<%@ Page Language="VB" %>
<%@ Implements Interface="System.Web.UI.ICallbackEventHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    Dim returnValue As String
    ' <Snippet5>
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) _
    Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Try
            Page.ClientScript.ValidateEvent("ClientCallback1")
            ' Callback logic goes here.
            returnValue = "callback result"
            
        Catch
            ' Failed callback validation logic.
        End Try

    End Sub
    ' </Snippet5>
    '<Snippet6>
    Public Function GetCallbackResult() _
    As String Implements _
    System.Web.UI.ICallbackEventHandler.GetCallbackResult

        Return returnValue

    End Function
    '</Snippet6>
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        
        Page.ClientScript.RegisterForEventValidation("ClientCallback1")
        MyBase.Render(writer)
        
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>