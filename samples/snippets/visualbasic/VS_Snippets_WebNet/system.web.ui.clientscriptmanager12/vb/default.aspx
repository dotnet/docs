<!-- <Snippet1> -->
<%@ Page Language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Public Sub Page_Load(ByVal sender As [Object], ByVal e As EventArgs)
        ' Define the name and type of the client script on the page. 
        Dim csName As [String] = "ButtonClickScript"
        Dim csType As Type = Me.[GetType]()
        
        ' Get a ClientScriptManager reference from the Page class. 
        Dim cs As ClientScriptManager = Page.ClientScript
        
        ' Check to see if the client script is already registered. 
        If Not cs.IsClientScriptBlockRegistered(csType, csName) Then
            Dim csText As New StringBuilder()
            csText.Append("<script type=""text/javascript""> function DoClick() {")
            csText.Append("Form1.Message.value='Text from client script.'} </")
            csText.Append("script>")
            cs.RegisterClientScriptBlock(csType, csName, csText.ToString())
        End If
    End Sub
</script>
<html  >
  <head>
    <title>RegisterClientScriptBlock Example</title>
  </head>
  <body>
     <form id="Form1"
         runat="server">
        <input type="text" id="Message" /> <input type="button" value="ClickMe" onclick="DoClick()" />
     </form>
  </body>
</html>
<!-- </Snippet1> -->

