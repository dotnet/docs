<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <script language="VB" runat="server">
       Sub SubmitBtn_Click (Source As Object, ByVal E as EventArgs)
           If (Basketball.Checked = true) Then 
               ' You like basketball
           End If
 
           If (Football.Checked = true) Then
               ' You like football
           End If
 
           If (Soccer.Checked = true) Then
               ' You like soccer
           End If
       End Sub
    </script>
  
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
       <form id="form1" method="post" runat="server">
         Enter Interests:  
         <input id="Basketball" checked="checked" type="checkbox" runat="server" /> Basketball
         <input id="Football" type="checkbox" runat="server" /> Football
         <input id="Soccer" type="checkbox" runat="server" /> Soccer
                 
         <input type="button" value="Enter" onserverclick="SubmitBtn_Click" runat="server" />
        </form>
    </body>
 </html>
   
<!--</Snippet1>-->
