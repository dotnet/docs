<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Calendar Example</title>
<script language="C#" runat="server">

      void ButtonClick(Object sender, EventArgs e) 
      {
         Calendar1.VisibleDate = new DateTime(Calendar1.TodaysDate.Year, 
                                              DropList1.SelectedIndex + 1, 
                                              1);
         Label1.Text = "The VisibleDate property is " + 
                       Calendar1.VisibleDate.ToShortDateString();
      }

   </script>

</head>     
<body>

   <form id="form1" runat="server">

      <h3>Calendar Example</h3>

      <asp:Calendar id="Calendar1" runat="server"  
           SelectionMode="None" 
           ShowGridLines="True">
 
         <SelectedDayStyle BackColor="Yellow"
                           ForeColor="Red">
         </SelectedDayStyle>

      </asp:Calendar>

      <hr /><br />

      Select the month to display: <br />

      <asp:DropDownList id="DropList1" runat="server">

         <asp:ListItem>1</asp:ListItem>
         <asp:ListItem>2</asp:ListItem>
         <asp:ListItem>3</asp:ListItem>
         <asp:ListItem>4</asp:ListItem>
         <asp:ListItem>5</asp:ListItem>
         <asp:ListItem>6</asp:ListItem>
         <asp:ListItem>7</asp:ListItem>
         <asp:ListItem>8</asp:ListItem>
         <asp:ListItem>9</asp:ListItem>
         <asp:ListItem>10</asp:ListItem>
         <asp:ListItem>11</asp:ListItem>
         <asp:ListItem>12</asp:ListItem>

      </asp:DropDownList>

      <asp:Button id="Button1" 
           Text="Submit"
           OnClick="ButtonClick"
           runat="server" />

      <br /><br />

      <asp:Label id="Label1" runat="server"/>

   </form>
</body>
</html>

<!--</Snippet1>-->
