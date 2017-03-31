<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      Sub Check_Change(sender As Object, e As EventArgs)
   
         ' Show or hide the gridlines in the Calendar control
         ' depending on the state of the ShowGridLinesCheckBox CheckBox
         ' control.
         If ShowGridLinesCheckBox.Checked Then

            Calendar1.ShowGridLines = True

         Else

            Calendar1.ShowGridLines = False

         End If

      End Sub
  
   </script>
  
<head runat="server">
    <title> Calendar ShowGridLines Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> Calendar ShowGridLines Example </h3>

      Select whether to show or hide the gridlines.

      <br /><br /> 
  
      <asp:Calendar id="Calendar1" 
           ShowTitle="True"
           runat="server"/>

      <br /><br />

      <asp:CheckBox id="ShowGridLinesCheckBox"
           Text="Show/Hide gridlines"
           AutoPostBack="True"
           Checked="False"
           OnCheckedChanged="Check_Change"
           runat="server"/>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
