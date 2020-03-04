<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  Protected Sub SubmitButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    Message.InnerText = "You entered: " + Server.HtmlEncode(Input1.Value)

  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>HtmlInputButton Example</title>
</head>
<body>
    <form id="myform"
          method="post"
          enctype="application/x-www-form-urlencoded"
          runat="server">
    <div>
      <input id="Input1"
             type="Text" 
             maxlength="40"
             runat="server"/>
      <input id="SubmitButton"
             type="submit"
             value="Submit"
             onserverclick="SubmitButton_Click"
             runat="server" />
      <input id="ResetButton"
             type="reset"
             value="Reset"
             runat="server" />
      <input id="Button"
             type="button"
             value="Button"
             onclick="alert('Hello from the client side.');"
             runat="server" />
      <br />
      <span  id="Message" 
             runat="server"/>
    
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
