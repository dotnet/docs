<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>ASP.NET Example</title>
<script runat="server">

        Sub Select_Change(sender As Object, e As EventArgs)
            
            Dim current_date As DateTime
            
            ' Create IEnumerator.
            Dim myEnum As IEnumerator = Calendar1.SelectedDates.GetEnumerator()
            
            Label1.Text = "The dates selected are: "
            
            ' Loop through the IEnumerator and display the contents.
            While myEnum.MoveNext()
            
                current_date = CType(myEnum.Current, DateTime)
                Label1.Text &= " " & current_date.Day.ToString()
                
            End While 
        End Sub
 
    </script>
 
 </head>     
 <body>
 
    <form id="form1" runat="server">
 
       <asp:Calendar ID="Calendar1" runat="server"  
            SelectionMode="DayWeekMonth" 
            OnSelectionChanged="Select_Change"/>
 
       <hr />
 
       Select dates from the Calendar.<br /><br />
 
       <asp:Label id="Label1" runat="server" />
 
    </form>
 </body>
 </html>
    
<!--</Snippet1>-->
