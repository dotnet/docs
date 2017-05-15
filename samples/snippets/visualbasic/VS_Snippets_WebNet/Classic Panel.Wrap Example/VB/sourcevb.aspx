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
       If Panel1.Wrap = True Then
          Panel1.Wrap = False
          Button1.Text = "Set Wrap=True"
       Else
          Panel1.Wrap = True
          Button1.Text = "Set Wrap=False"
       End If
    End Sub
 
    </script>
 </head>
 <body>
 
    <h3>Panel Example</h3>
    <form id="form1" runat="server">
 
       <asp:Panel id="Panel1" Height="200" Width="100" BackColor="Gainsboro"
            Wrap="True" runat="server"/>
     
       <br /> 
       <asp:Button id="Button1" OnClick="Button1_Click"
            Text="Set Wrap=False" runat="server"/>
 
    </form>
 </body>
 </html>
 
<!--</Snippet1>-->
