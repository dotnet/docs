<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Implements Interface="System.Web.UI.ICallbackEventHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
    Public cbCount As Integer = 0
    
    ' Define method that processes the callbacks on server.
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) _
    Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        
        cbCount = Convert.ToInt32(eventArgument) + 1
        
    End Sub

    ' Define method that returns callback result.
    Public Function GetCallbackResult() _
    As String Implements _
    System.Web.UI.ICallbackEventHandler.GetCallbackResult

        Return cbCount.ToString()
        
    End Function
    
    
 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
        ' Define a StringBuilder to hold messages to output.
        Dim sb As New StringBuilder()
    
        ' Check if this is a postback.
        sb.Append("No page postbacks have occurred.")
        If (Page.IsPostBack) Then
      
            sb.Append("A page postback has occurred.")
      
        End If
    
        ' Write out any messages.
        MyLabel.Text = sb.ToString()
    
        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript

        ' Define one of the callback script's context.
        ' The callback script will be defined in a script block on the page.
        Dim context1 As New StringBuilder()
        context1.Append("function ReceiveServerData1(arg, context)")
        context1.Append("{")
        context1.Append("Message1.innerText =  arg;")
        context1.Append("value1 = arg;")
        context1.Append("}")
    
        ' Define callback references.
        Dim cbReference1 As String = cs.GetCallbackEventReference(Me, "arg", _
            "ReceiveServerData1", context1.ToString())
        Dim cbReference2 As String = cs.GetCallbackEventReference("'" & _
            Page.UniqueID & "'", "arg", "ReceiveServerData2", "", "ProcessCallBackError", False)
        Dim callbackScript1 As String = "function CallTheServer1(arg, context) {" + _
            cbReference1 + "; }"
        Dim callbackScript2 As String = "function CallTheServer2(arg, context) {" + _
            cbReference2 + "; }"
    
        ' Register script blocks will perform call to the server.
        cs.RegisterClientScriptBlock(Me.GetType(), "CallTheServer1", _
            callbackScript1, True)
        cs.RegisterClientScriptBlock(Me.GetType(), "CallTheServer2", _
            callbackScript2, True)
    
    End Sub
</script>

<script type="text/javascript">
var value1 = 0;
var value2 = 0;
function ReceiveServerData2(arg, context)
{
    Message2.innerText = arg;
    value2 = arg;
}
function ProcessCallBackError(arg, context)
{
    Message2.innerText = 'An error has occurred.';
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ClientScriptManager Example</title>
</head>
<body>
    <form id="Form1" 
          runat="server">
    <div>
      Callback 1 result: <span id="Message1">0</span>
      <br />
      Callback 2 result: <span id="Message2">0</span>
      <br /> <br />
      <input type="button" 
             value="ClientCallBack1" 
             onclick="CallTheServer1(value1, alert('Increment value'))"/>    
      <input type="button" 
             value="ClientCallBack2" 
             onclick="CallTheServer2(value2, alert('Increment value'))"/>
      <br /> <br />
      <asp:Label id="MyLabel" 
                 runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->