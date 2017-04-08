<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>AccessKey Property of a Web Control</title>
</head>
 <body>
 
   <h3>AccessKey Property of a Web Control</h3>
 
 <form id="form1" runat="server">
 
   <asp:TextBox id="TextBox1" 
     AccessKey="Y" 
     Text="Press Alt-Y to get focus here" 
     Columns="45"
     runat="server"/>
 
   <br />
 
   <asp:TextBox id="TextBox2" 
     AccessKey="Z" 
     Text="Press Alt-Z to get focus here" 
     Columns="45"
     runat="server"/>
 
 </form>
 
 </body>
 </html>
    
<!--</Snippet1>-->
