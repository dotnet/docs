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
 
          if (Calendar1.SelectedDates.Count > 0)
          {
 
             Label1.Text = "Selected date(s) are: ";
 
             for (int i = 0; i < Calendar1.SelectedDates.Count; i++)
             {
                Label1.Text += " " + Calendar1.SelectedDates[i].Day.ToString();
             } 
 
          }
          else
             Label1.Text = "No dates selected!!";
       }
 
    </script>
 
 </head>     
 <body>
 
    <form id="form1" runat="server">
 
       <asp:Calendar ID="Calendar1" runat="server"  
            SelectionMode="DayWeekMonth"/>
 
       <hr />
 
       <asp:Button id="Button1"
            text="Display Selected Dates" 
            OnClick="Button_Click"  
            runat="server"  /> <br /><br />
 
       <asp:Label id="Label1" runat="server" />
 
    </form>
 </body>
 </html>
 
<!--</Snippet1>-->
