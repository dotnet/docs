<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Server_Change(ByVal sender As Object, ByVal e As EventArgs)
         
    ' The ServerChange event is commonly used for data validation.
    ' This method determines whether the comment entered into the
    ' HtmlTextArea control is longer than 20 characters.
    If TextArea1.Value.Length > 20 Then
      Span1.InnerHtml = "Your comment cannot exceed 20 characters."
    Else
      Span1.InnerHtml = "You wrote: <br />" + TextArea1.Value
    End If
      
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
   <title>HtmlTextArea ServerChange Example</title>

</head>
<body>

   <form id="form1" runat="server">

      <h3>HtmlTextArea ServerChange Example</h3>

      Enter your comments: <br />

      <textarea rows="2" cols="20" id="TextArea1"
                onserverchange="Server_Change" 
                runat="server"/>

      <br />

      <input type="submit"  
             value="Submit" 
             runat="server"/>

      <br />

      <span id="Span1" 
            runat="server" />

   </form>

</body>
</html>
<!--</Snippet1>-->
