<!-- <Snippet2> -->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Button Example</title>
<script language="VB" runat="server">
    Sub CommandBtn_Click(sender As Object, e As CommandEventArgs)
        ' Insert code to sort in ascending order here.
        Message.Text = "You clicked the " & e.CommandName & _
            " - " & e.CommandArgument & " button."
    End Sub 'CommandBtn_Click
  </script>
</head>
 
<body>
   <form id="form1" runat="server">

      <h3>Button Example</h3>

      Click on the command button.<br /><br />
 
      <asp:Button id="Button1"
           Text="Sort Ascending"
           CommandName="Sort"
           CommandArgument="Ascending"
           OnCommand="CommandBtn_Click" 
           runat="server"/>
       
      <br />

      <asp:label id="Message" runat="server"/>
 
   </form>
 
</body>
</html>
<!-- </Snippet2> -->
