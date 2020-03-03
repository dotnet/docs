<!-- <Snippet2> -->
<%@ Page Language="VB" %>
<%@ Implements Interface="System.Web.UI.IPostBackEventHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
 
  Public Sub RaisePostBackEvent(ByVal eventArgument As String) _
    Implements IPostBackEventHandler.RaisePostBackEvent
    
    Label1.Text = "Postback handled by " & Me.ID.ToString() & ". <br/>" & _
           "Postback caused by " + eventArgument.ToString() & "."
  
  End Sub
  

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    ' Get a ClientScriptManager reference from the Page class.
    Dim cs As ClientScriptManager = Page.ClientScript
    
    ' Create a button element with its onClick attribute defined
    ' to create a postback event reference to the custom label control.
    Dim b As New HtmlInputButton()
    b.ID = "mybutton1"
    b.Value = "Click"
    b.Attributes.Add("onclick", cs.GetPostBackEventReference(Me, b.ID.ToString()))
    PlaceHolder1.Controls.Add(b)
    PlaceHolder1.Controls.Add(New LiteralControl("<br/>"))
    
    ' Create a link element with its href attribute defined
    ' to create a postback event reference to the custom label control.
    Dim a As New HtmlAnchor()
    a.ID = "myanchor1"
    a.InnerText = "link"
    a.HRef = cs.GetPostBackClientHyperlink(Me, a.ID.ToString())
    PlaceHolder1.Controls.Add(a)
    
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ClientScriptManager Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Label id="Label1"
                 runat="server" />
      <br />
      <asp:PlaceHolder id="PlaceHolder1" 
                       runat="server">
      </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
