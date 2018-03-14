<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>Panel Example</title>
<script language="VB" runat="server">
 
    Sub Page_Load(sender As Object, e As EventArgs)
       Dim l As New Label()
       l.Text = "This panel contains a label control."
       Panel1.Controls.Add(l)
    End Sub
     
    Sub Button1_Click(sender As Object, e As EventArgs)
       If Panel1.HorizontalAlign = HorizontalAlign.Left Then
          Panel1.HorizontalAlign = HorizontalAlign.Right
          Button1.Text = "Left justify text within Panel"
       Else
          Panel1.HorizontalAlign = HorizontalAlign.Left
          Button1.Text = "Right justify text within Panel"
       End If
    End Sub
    
    </script>
 
 </head>
 <body>
    <h3>Panel Example</h3>
    <form id="form1" runat="server">
 
       <asp:Panel id="Panel1" Height="200" Width="100" BackColor="Gainsboro"
            Wrap="True" HorizontalAlign="Right" runat="server"/>
 
       <br />
       <asp:Button id="Button1" OnClick="Button1_Click"
            Text="Left justify text within panel" runat="server"/>
 
    </form>
 </body>
 </html>
    
<!--</Snippet1>-->
