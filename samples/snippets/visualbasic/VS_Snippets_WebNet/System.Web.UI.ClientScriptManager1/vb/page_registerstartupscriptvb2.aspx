<!-- <Snippet2> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    ' Define the name and type of the client scripts on the page.
    Dim csname1 As String = "PopupScript"
    Dim csname2 As String = "ButtonClickScript"
    Dim cstype As Type = Me.GetType()
    
    ' Get a ClientScriptManager reference from the Page class.
    Dim cs As ClientScriptManager = Page.ClientScript

    ' Check to see if the startup script is already registered.
    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
      
      Dim cstext1 As String = "alert('Hello World');"
            cs.RegisterStartupScript(cstype, csname1, cstext1)
      
    End If
    
    ' Check to see if the client script is already registered.
    If (Not cs.IsClientScriptBlockRegistered(cstype, csname2)) Then
      
      Dim cstext2 As New StringBuilder()
            cstext2.Append("<script type=""text/javascript""> function DoClick() {")
      cstext2.Append("Form1.Message.value='Text from client script.'} </")
      cstext2.Append("script>")
            cs.RegisterClientScriptBlock(cstype, csname2, cstext2.ToString())
      
    End If
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ClientScriptManager Example</title>
  </head>
  <body>
     <form id="Form1"
         runat="server">
        <input type="text" id="Message" /> <input type="button" value="ClickMe" onclick="DoClick()" />
     </form>
  </body>
</html>
<!-- </Snippet2> -->
