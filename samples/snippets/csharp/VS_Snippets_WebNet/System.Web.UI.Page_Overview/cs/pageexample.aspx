<!-- <Snippet1> -->
<%@ Page Language="C#" CodeFile="pageexample.aspx.cs" Inherits="MyCodeBehindCS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Page Class Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table>
          <tr>
            <td> Name: </td>
            <td> <asp:textbox id="MyTextBox" runat="server"/> </td>
          </tr>
          <tr>
             <td></td>
             <td><asp:button id="MyButton" text="Click Here" onclick="SubmitBtn_Click" runat="server"/></td>
          </tr>
          <tr>
             <td></td>
             <td><span id="MySpan" runat="server" /></td>
          </tr>
       </table>     
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->