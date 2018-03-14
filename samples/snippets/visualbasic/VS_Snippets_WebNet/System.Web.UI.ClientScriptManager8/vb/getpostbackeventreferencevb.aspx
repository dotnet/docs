<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  Public Class MyControl
    Inherits Label
    Implements IPostBackEventHandler
     
    Public Sub New()
      
      MyBase.Text = "No postback raised."
    
    End Sub
    
    Public Sub RaisePostBackEvent(ByVal eventArgument As String) Implements System.Web.UI.IPostBackEventHandler.RaisePostBackEvent
      
      MyBase.Text = "Postback handled by " & Me.ID.ToString() & ". <br/>" & _
                "Postback caused by " + eventArgument.ToString() & "."

    End Sub
    
  End Class
   

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    ' Get a ClientScriptManager reference from the Page class.
    Dim cs As ClientScriptManager = Page.ClientScript

    ' Create an instance of the custom label control and 
    ' add it to the page.
    Dim mycontrol As New MyControl()
    MyControl.ID = "mycontrol1"
    PlaceHolder1.Controls.Add(MyControl)
    PlaceHolder1.Controls.Add(New LiteralControl("<br/>"))
    
    ' Create a button element with its onClick attribute defined
    ' to create a postback event reference to the custom label control.
    Dim b As New HtmlInputButton()
    b.ID = "mybutton1"
    b.Value = "Click"
    b.Attributes.Add("onclick", cs.GetPostBackEventReference(MyControl, b.ID.ToString()))
    PlaceHolder1.Controls.Add(b)
    PlaceHolder1.Controls.Add(New LiteralControl("<br/>"))
    
    ' Create a link element with its href attribute defined
    ' to create a postback event reference to the custom label control.
    Dim a As New HtmlAnchor()
    a.ID = "myanchor1"
    a.InnerText = "link"
    a.HRef = cs.GetPostBackClientHyperlink(MyControl, a.ID.ToString())
    PlaceHolder1.Controls.Add(a)
    
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ClientScriptManager Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:PlaceHolder id="PlaceHolder1" 
                       runat="server">
      </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
