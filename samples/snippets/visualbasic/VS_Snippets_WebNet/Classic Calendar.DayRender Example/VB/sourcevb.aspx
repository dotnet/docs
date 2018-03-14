<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>DayRender Event Example</title>
<script language="VB" runat="server">
   
        Sub DayRender(source As Object, e As DayRenderEventArgs)
            
            ' Change the background color of the days in the month
            ' to yellow.
            If Not e.Day.IsOtherMonth And Not e.Day.IsWeekend Then
                e.Cell.BackColor = System.Drawing.Color.Yellow
            End If 
            ' Add custom text to cell in the Calendar control.
            If e.Day.Date.Day = 18 Then
                e.Cell.Controls.Add(New LiteralControl(ChrW(60) & "br" & ChrW(62) & "Holiday"))
            End If 
        End Sub 'DayRender 

   </script>
 
</head>
 
<body>
 
   <form id="form1" runat="server">

      <h3>DayRender Event Example</h3>
 
      <asp:Calendar id="calendar1" 
                    OnDayRender="DayRender"
                    runat="server">

         <WeekendDayStyle BackColor="gray">
         </WeekendDayStyle>

      </asp:Calendar>
                   
   </form>
          
</body>
</html>
   
<!--</Snippet1>-->
