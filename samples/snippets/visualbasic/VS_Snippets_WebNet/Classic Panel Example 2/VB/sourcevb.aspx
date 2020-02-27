<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>Panel Example</title>
<script runat="server">

    Sub Page_Load(sender As Object, e As EventArgs)
        
        ' Show or Hide the Panel contents.
        If Check1.Checked Then
            Panel1.Visible = False
        Else
            Panel1.Visible = True
        End If
        
        ' Generate the Label controls.
        Dim numlabels As Integer = Int32.Parse(DropDown1.SelectedItem.Value)
        
        Dim i As Integer
        For i = 1 To numlabels
            Dim l As New Label()
            l.Text = "Label" + i.ToString()
            l.ID = "Label" + i.ToString()
            Panel1.Controls.Add(l)
            Panel1.Controls.Add(New LiteralControl("<br />"))
        Next i
        
        ' Generate the Textbox controls.
        Dim numtexts As Integer = Int32.Parse(DropDown2.SelectedItem.Value)
        
        For i = 1 To numtexts
            Dim t As New TextBox()
            t.Text = "TextBox" & i.ToString()
            t.ID = "TextBox" & i.ToString()
            Panel1.Controls.Add(t)
            Panel1.Controls.Add(New LiteralControl("<br />"))
        Next i
    End Sub
 
    </script>
 
 </head>
 <body>
 
    <h3>Panel Example</h3>
 
    <form id="form1" runat="server">
 
       <asp:Panel id="Panel1" runat="server"
            BackColor="gainsboro"
            Height="200px"
            Width="300px">
 
            Panel1: Here is some static content...
            <br />
 
       </asp:Panel>
 
       <br />
         
       Generate Labels:
       <asp:DropDownList id="DropDown1" runat="server">
          <asp:ListItem Value="0">0</asp:ListItem>
          <asp:ListItem Value="1">1</asp:ListItem>
          <asp:ListItem Value="2">2</asp:ListItem>
          <asp:ListItem Value="3">3</asp:ListItem>
          <asp:ListItem Value="4">4</asp:ListItem>
       </asp:DropDownList>
 
       <br />
         
       Generate TextBoxes:
       <asp:DropDownList id="DropDown2" runat="server">
          <asp:ListItem Value="0">0</asp:ListItem>
          <asp:ListItem Value="1">1</asp:ListItem>
          <asp:ListItem Value="2">2</asp:ListItem>
          <asp:ListItem Value="3">3</asp:ListItem>
          <asp:ListItem Value="4">4</asp:ListItem>
       </asp:DropDownList>
 
       <br />
       <asp:CheckBox id="Check1" Text="Hide Panel" runat="server"/>
             
       <br />
       <asp:Button Text="Refresh Panel" runat="server"/>
 
    
    </form>
 
 </body>
 </html>
 
<!--</Snippet1>-->
