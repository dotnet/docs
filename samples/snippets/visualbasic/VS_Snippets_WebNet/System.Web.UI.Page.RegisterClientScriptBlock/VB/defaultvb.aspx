<!-- <Snippet1> -->
<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim csname1 As String = "PopupScript"

        Dim csname2 As String = "ButtonClickScript"
    
        If Not IsClientScriptBlockRegistered(csname1) Then
            Dim cstext1 As String = "<script type=""text/javascript"">" & _
                "alert('Hello World');</" & "script>"
            RegisterStartupScript(csname1, cstext1)
        End If
    
        If Not IsClientScriptBlockRegistered(csname2) Then
            Dim cstext2 As New StringBuilder()
            cstext2.Append("<script type=""text/javascript""> function DoClick() {")
            cstext2.Append("Form1.Message.value='Text from client script.'} </")
            cstext2.Append("script>")
            RegisterClientScriptBlock(csname2, cstext2.ToString())
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