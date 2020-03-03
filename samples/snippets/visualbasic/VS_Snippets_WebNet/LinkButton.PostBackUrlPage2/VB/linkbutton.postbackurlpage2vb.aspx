<!--<Snippet1>-->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
    
    Dim text As String
    
    ' Get the value of TextBox1 from the page that posted
    ' to this page.
    text = CType((PreviousPage.FindControl("TextBox1")), TextBox).Text
       
    ' Check for an empty string.
    If Not (text = "") Then
      PostedLabel.Text = "The string posted from the previous page is " _
                         & text & "."
    Else
      PostedLabel.Text = "An empty string was posted from the previous page."
    End If
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
  <title>LinkButton.PostBackUrl Target Page Example</title>
</head>
<body>
  <form id="form1" runat="server">
    
    <h3>LinkButton.PostBackUrl Target Page Example</h3>
       
    <br />
    
    <asp:label id="PostedLabel"
       runat="Server">
    </asp:label>

    </form>
</body>
</html>
<!--</Snippet1>-->

