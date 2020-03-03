<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>ASP.NET Example</title>
<script language="C#" runat="server">
 
       void Selection_Change(Object sender, EventArgs e) 
       {
 
          int current_month = Calendar1.VisibleDate.Month;
          int current_year = Calendar1.VisibleDate.Year;
   
          for (int i = 0; i < Calendar1.SelectedDates.Count; i++)
          {
             if (Calendar1.SelectedDates[i].DayOfWeek == DayOfWeek.Wednesday)
                Label1.Text = "Wednesday falls on " + 
                              Calendar1.SelectedDates[i].Month + "/" +
                              Calendar1.SelectedDates[i].Day + "/" + 
                              Calendar1.SelectedDates[i].Year;
                
          }
 
          if (Calendar1.SelectedDates.Count != 7)
             Label1.Text = "";
 
       }
 
    </script>
 
 </head>     
 <body>
 
    <form id="form1" runat="server">
 
       <asp:Calendar ID="Calendar1" runat="server"  
            SelectionMode="DayWeekMonth" 
            OnSelectionChanged="Selection_Change" />
 
       <hr />
 
       Select an entire week <br /><br />
 
       <asp:Label id="Label1" runat="server" />
 
    </form>
 </body>
 </html>
    
<!--</Snippet1>-->
