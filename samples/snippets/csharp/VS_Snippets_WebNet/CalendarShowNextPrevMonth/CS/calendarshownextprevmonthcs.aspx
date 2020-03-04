<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      void Check_Change(Object sender, EventArgs e)
      {
   
         // Show or hide the navigation controls to the next and previous  
         // months in the Calendar control depending on the state of the 
         // ShowNextPrevMonthCheckBox CheckBox control.
         if (ShowNextPrevMonthCheckBox.Checked)
         {

            Calendar1.ShowNextPrevMonth = true;

         }
         else
         {

            Calendar1.ShowNextPrevMonth = false;

         }

      }
  
   </script>
  
<head runat="server">
    <title> Calendar ShowNextPrevMonth Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> Calendar ShowNextPrevMonth Example </h3>

      Select whether to show or hide the next and previous month 
      navigation controls.

      <br /><br /> 
  
      <asp:Calendar id="Calendar1" 
           ShowTitle="True"
           runat="server"/>

      <br /><br />

      <asp:CheckBox id="ShowNextPrevMonthCheckBox"
           Text="Show/Hide the navigation controls."
           AutoPostBack="True"
           Checked="True"
           OnCheckedChanged="Check_Change"
           runat="server"/>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
