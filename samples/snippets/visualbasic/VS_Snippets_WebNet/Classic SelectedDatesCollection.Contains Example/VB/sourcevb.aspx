<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>ASP.NET Example</title>
<script language="VB" runat="server">

        Sub Button_Click(sender As Object, e As EventArgs)
            
            Dim current_month As Integer = Calendar1.VisibleDate.Month
            Dim current_year As Integer = Calendar1.VisibleDate.Year
            
            Calendar1.VisibleDate = Calendar1.TodaysDate
            
            Dim theDate As New DateTime(current_year, current_month, 15)
            
            If Calendar1.SelectedDates.Contains(theDate) Then
                Label1.Text = "Yes, you selected the 15th!!"
            Else
                Label1.Text = "No, you didn't select the 15th!!"
            End If 
        End Sub
 
    </script>
 
 </head>     
 <body>
 
    <form id="form1" runat="server">
 
       <asp:Calendar ID="Calendar1" runat="server"  
            SelectionMode="DayWeekMonth"/>
 
       <hr />
 
       Select dates on the Calendar and click the button below <br />
       to validate that the 15th on the month was selected <br /><br /> 
 
       <asp:Button id="Button1"
            text="Validate the 15th" 
            OnClick="Button_Click"  
            runat="server"  /> <br /><br />
 
       <asp:Label id="Label1" runat="server" />
 
    </form>
 </body>
 </html>
    
<!--</Snippet1>-->
