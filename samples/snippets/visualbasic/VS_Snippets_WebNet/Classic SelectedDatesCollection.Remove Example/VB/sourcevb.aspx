<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>ASP.NET Example</title>
<script language="VB" runat="server">

        Sub Button_Click(sender As Object, e As EventArgs)
            
            If Calendar1.SelectedDates.Count > 0 Then
                Calendar1.SelectedDates.Remove(Calendar1.SelectedDates(0))
            End If
            
        End Sub

    </script>
 
 </head>     
 <body>
 
    <form id="form1" runat="server">
 
       <asp:Calendar ID="Calendar1" runat="server"  
            SelectionMode="DayWeekMonth"/>
 
       <hr />
    
       Select some dates then click the button below <br /><br />
 
       <asp:Button id="Button1"
            text="Remove First Date" 
            OnClick="Button_Click"  
            runat="server"  /> <br />
 
       <asp:Label id="Label1" runat="server" />
 
    </form>
 </body>
 </html>
    
<!--</Snippet1>-->
