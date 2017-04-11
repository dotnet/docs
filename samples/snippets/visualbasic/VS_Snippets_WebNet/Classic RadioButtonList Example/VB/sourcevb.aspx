<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>RadioButtonList Example</title>
<script language="VB" runat="server">

    Sub Button1_Click(Source As Object, e As EventArgs)
        If RadioButtonList1.SelectedIndex > - 1 Then
            Label1.Text = "You selected: " & RadioButtonList1.SelectedItem.Text
        End If
    End Sub

    Sub chkLayout_CheckedChanged(sender As Object, e As EventArgs)        
        If chkLayout.Checked = True Then
            RadioButtonList1.RepeatLayout = RepeatLayout.Table
        Else
            RadioButtonList1.RepeatLayout = RepeatLayout.Flow
        End If
    End Sub

    Sub chkDirection_CheckedChanged(sender As Object, e As EventArgs)        
        If chkDirection.Checked = True Then
            RadioButtonList1.RepeatDirection = RepeatDirection.Horizontal
        Else
            RadioButtonList1.RepeatDirection = RepeatDirection.Vertical
        End If
    End Sub
 
     </script>
 
 </head>
 <body>
 
     <h3>RadioButtonList Example</h3>
 
     <form id="form1" runat="server">
 
         <asp:RadioButtonList id="RadioButtonList1" runat="server">
            <asp:ListItem>Item 1</asp:ListItem>
            <asp:ListItem>Item 2</asp:ListItem>
            <asp:ListItem>Item 3</asp:ListItem>
            <asp:ListItem>Item 4</asp:ListItem>
            <asp:ListItem>Item 5</asp:ListItem>
            <asp:ListItem>Item 6</asp:ListItem>
         </asp:RadioButtonList>
 
         <br />
         
         <asp:CheckBox id="chkLayout" OnCheckedChanged="chkLayout_CheckedChanged" Text="Display Table Layout" Checked="true" AutoPostBack="true" runat="server" />
 
         <br />
         
         <asp:CheckBox id="chkDirection" OnCheckedChanged="chkDirection_CheckedChanged" Text="Display Horizontally" AutoPostBack="true" runat="server" />
 
         <br />
         
         <asp:Button id="Button1" Text="Submit" onclick="Button1_Click" runat="server"/>
 
         <br />
         
         <asp:Label id="Label1" font-names="Verdana" font-size="8pt" runat="server"/>
 
     </form>
 
 </body>
 </html>
   
<!--</Snippet1>-->
