<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Panel.Direction Property Example</title>
<script runat="server">
          
        Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

            ' Determine which list item was clicked.
            ' Change the display direction of content in the panel.
            Select Case (ListBox1.SelectedIndex)
                Case 0
                    Panel1.Direction = ContentDirection.NotSet
                Case 1
                    Panel1.Direction = ContentDirection.LeftToRight
                Case 2
                    Panel1.Direction = ContentDirection.RightToLeft
                Case Else
                    Throw New Exception("You did not select a valid list item.")
            End Select

        End Sub
     
    </script>
</head>
<body>
    <form id="Form1" runat="server">
        
        <h3>Panel.Direction Property Example</h3>
        
        <h4>Select the content display direction for the 
        controls in the panel.</h4>
        
        <asp:ListBox ID="ListBox1"
            Rows="3"
            AutoPostBack="True"
            SelectionMode="Single"
            OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"
            runat="server">
                <asp:ListItem>NotSet</asp:ListItem>
            <asp:ListItem>LeftToRight</asp:ListItem> 
            <asp:ListItem>RightToLeft</asp:ListItem>                               
        </asp:ListBox>
            
        <hr />              
        
        <asp:Panel ID="Panel1"
            Height="100px"
            Width="300px"
            BackColor="Aqua"           
            runat="server">            
            
            <asp:Label ID="Label1"
                Text = "Select a programming language"
                runat="server">              
            </asp:Label><br /><br />
            
            <asp:RadioButton id="Radio1"
                Text="C#" 
                Checked="False" 
                GroupName="RadioGroup1" 
                runat="server">
            </asp:RadioButton><br />

            <asp:RadioButton id="Radio2"
                Text="Visual Basic" 
                Checked="False" 
                GroupName="RadioGroup1" 
                runat="server">
            </asp:RadioButton><br />
                   
            <asp:RadioButton id="Radio3"
                Text="C++" 
                Checked="False" 
                GroupName="RadioGroup1" 
                runat="server">
            </asp:RadioButton><br />           
            
        </asp:Panel>           
         
    </form>
</body>
</html>
<!--</Snippet1>-->


