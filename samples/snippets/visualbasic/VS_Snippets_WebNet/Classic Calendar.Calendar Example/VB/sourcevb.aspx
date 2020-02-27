<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Calendar Example</title>
<script runat="server">
        Sub Page_Load(sender As Object, e As EventArgs)
            ' Create new Calendar control.
            Dim calendar1 as Calendar = New Calendar

            ' Set Calendar properties.
            calendar1.OtherMonthDayStyle.ForeColor=System.Drawing.Color.LightGray
            calendar1.TitleStyle.BackColor=System.Drawing.Color.Blue
            calendar1.TitleStyle.ForeColor=System.Drawing.Color.White
            calendar1.DayStyle.BackColor=System.Drawing.Color.Gray
            calendar1.SelectionMode=CalendarSelectionMode.DayWeekMonth
            calendar1.ShowNextPrevMonth=true

            ' Add Calendar control to Controls collection.
            Form1.Controls.Add(calendar1)
        End Sub 'Page_Load 
   </script>

</head>
<body>

   <form id="Form1" runat="server">

      <h3>Calendar Example</h3>
            
   </form>
        

</body>
</html>
   
<!--</Snippet1>-->
