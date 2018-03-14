<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>ASP.NET Example</title>
<script language="C#" runat="server">
 
       void Button_Click(Object sender, EventArgs e) 
       {
   
          int current_month = Calendar1.VisibleDate.Month;
          int current_year = Calendar1.VisibleDate.Year;
           
          Calendar1.VisibleDate = Calendar1.TodaysDate;
 
          DateTime date = new DateTime(current_year, current_month, 15);
 
          if (Calendar1.SelectedDates.Contains(date)) 
             Label1.Text = "Yes, you selected the 15th!!";
          else
             Label1.Text = "No, you didn't select the 15th!!";
             
       }
 
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
