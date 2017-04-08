<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>HtmlInputHidden Sample</title>
<script language="VB" runat="server">
    Sub Page_Load(sender As Object, e As EventArgs)
        
        If Page.IsPostBack Then
            Span1.InnerHtml = "Hidden value: " & "<b>" & HiddenValue.Value & "</b>"
        End If
    End Sub 'Page_Load


    Sub SubmitBtn_Click(sender As Object, e As EventArgs)
        HiddenValue.Value = StringContents.Value
    End Sub 'SubmitBtn_Click
 </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3>HtmlInputHidden Sample</h3>

      <input id="HiddenValue" 
             type="hidden" 
             value="Initial Value" 
             runat="server" />

      Enter a string: 
 
      <input id="StringContents" 
             type="text" 
             size="40" 
             runat="server" />

      <br />

      <input type="submit" 
             value="Enter" 
             onserverclick="SubmitBtn_Click" 
             runat="server" />

      <br />

      <span id="Span1" runat="server">
         This label will display the previously entered string.
      </span>

   </form>

</body>
</html>

   
<!--</Snippet1>-->
