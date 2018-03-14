<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>ASP.NET Example</title>
<script language="VB" runat="server">
 
        Sub Selection_Change(sender As Object, e As EventArgs)
            
            Dim current_month As Integer = Calendar1.VisibleDate.Month
            Dim current_year As Integer = Calendar1.VisibleDate.Year
            
            Dim i As Integer
            For i = 0 To Calendar1.SelectedDates.Count - 1
                If Calendar1.SelectedDates(i).DayOfWeek = DayOfWeek.Wednesday Then
                    Label1.Text = "Wednesday falls on " & _
                        Calendar1.SelectedDates(i).Month & "/" & _
                        Calendar1.SelectedDates(i).Day & "/" & _
                        Calendar1.SelectedDates(i).Year
                End If
            Next i            
            
            If Calendar1.SelectedDates.Count <> 7 Then
                Label1.Text = ""
            End If 
        End Sub
 
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
