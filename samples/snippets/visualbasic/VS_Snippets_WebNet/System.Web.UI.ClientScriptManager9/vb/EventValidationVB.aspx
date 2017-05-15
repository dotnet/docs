<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Implements Interface="System.Web.UI.ICallbackEventHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Dim _cbMessage As String = ""
    ' Define method that processes the callbacks on server.
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) _
    Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        
        Try
            Page.ClientScript.ValidateEvent(button1.UniqueID, Me.ToString())
            _cbMessage = "Correct event raised callback."
            
        Catch ex As Exception
            _cbMessage = "Incorrect event raised callback."

        End Try
        
    End Sub

    ' Define method that returns callback result.
    Public Function GetCallbackResult() _
    As String Implements _
    System.Web.UI.ICallbackEventHandler.GetCallbackResult

        Return _cbMessage
        
    End Function
    
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        If (Not IsPostBack) Then
            Dim cs As ClientScriptManager = Page.ClientScript
            Dim cbReference As String = cs.GetCallbackEventReference("'" & _
                Page.UniqueID & "'", "arg", "ReceiveServerData", "", _
                "ProcessCallBackError", False)
            Dim callbackScript As String = "function CallTheServer(arg, context) {" & _
                cbReference & "; }"
            cs.RegisterClientScriptBlock(Me.GetType(), "CallTheServer", _
                callbackScript, True)
            
        End If
    End Sub
    
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        
        Page.ClientScript.RegisterForEventValidation(button1.UniqueID, Me.ToString())
        MyBase.Render(writer)
    End Sub
    
</script>

<script type="text/javascript">
var value1 = new Date();
function ReceiveServerData(arg, context)
{
    Message.innerText = arg;
    Label1.innerText = "Callback completed at " + value1;
    value1 = new Date();
}
function ProcessCallBackError(arg, context)
{
    Message.innerText = 'An error has occurred.';
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CallBack Event Validation Example</title>
</head>
<body>
    <form id="Form1" runat="server">
    <div>
      Callback result: <span id="Message"></span>
      <br /> <br />
      <input type="button"
             id="button1" 
             runat="server"
             value="ClientCallBack" 
             onclick="CallTheServer(value1, null )"/>
      <br /> <br />
      <asp:Label id="Label1" runat="server"/>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
