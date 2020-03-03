<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Set ASP.NET Server Control Style Properties Using ASP.NET Syntax</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <!-- <Snippet3> -->
      <asp:Calendar Id="MyCalendar" 
        SelectionMode="DayWeek" runat="server" 
        TitleStyle-Backcolor="#3366ff"
        TitleStyle-ForeColor="White" />
      <!--</Snippet3>-->
      
  <br />
  
      <!-- <Snippet4>-->
      <asp:Calendar id="Calendar1" 
        SelectionMode="DayWeek" runat="server">
        <TitleStyle BackColor="#3366ff" ForeColor="white" />
      </asp:Calendar>
      <!--</Snippet4>-->
  
    </form>
</body>
</html>
