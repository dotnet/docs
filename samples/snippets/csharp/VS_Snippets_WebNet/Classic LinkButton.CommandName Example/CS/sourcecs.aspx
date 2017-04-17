<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>LinkButton Command Event Example</title>
<script language="C#" runat="server">
     
      void LinkButton_Command(Object sender, CommandEventArgs e) 
      {
         Label1.Text = "You chose: " + e.CommandName + " Item " + e.CommandArgument;
      }
 
   </script>
 
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>LinkButton Command Event Example</h3>
  
      <asp:LinkButton id="LinkButton1" 
           Text="Order Item 10001"
           CommandName="Order" 
           CommandArgument="10001" 
           OnCommand="LinkButton_Command" 
           runat="server"/>
 
      <br />
  
      <asp:LinkButton id="LinkButton2" 
           Text="Order Item 10002"
           CommandName="Order" 
           CommandArgument="10002" 
           OnCommand="LinkButton_Command" 
           Runat="server"/>
 
      <br />
      <br />
 
      <asp:Label id="Label1" runat="server"/>
 
   </form>

</body>
</html>

<!--</Snippet1>-->
