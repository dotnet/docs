<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>MultiView Class Example</title>
<script runat="server">

        Sub Index_Changed(ByVal Sender As Object, ByVal e As EventArgs)
            ' Set the active view to
            ' the view selected by the user.
            Dim text As String = ViewListBox.SelectedItem.Text
            Select Case (text)
                Case "View1"
                    MultiView1.SetActiveView(View1)
                Case "View2"
                    MultiView1.SetActiveView(View2)
                Case "View3"
                    MultiView1.SetActiveView(View3)
                Case Else
                    Throw New Exception("You did not select a valid view.")
            End Select

        End Sub

    </script>
</head>
<body>
    <form id="Form1" runat="server">
        
        <h3>MultiView Class Example</h3>
        
        <h4>Select a View to display in a MultiView control:</h4>

        <asp:ListBox id="ViewListBox" 
            Rows="1"
            SelectionMode="Single"
            AutoPostBack="True"
            OnselectedIndexChanged="Index_Changed"
            runat="Server">             
                <asp:ListItem Value="0">View1</asp:ListItem>
                <asp:ListItem Value="1">View2</asp:ListItem>
                <asp:ListItem Value="2">View3</asp:ListItem>
        </asp:ListBox><br /><br />
       
        <hr />

        <asp:MultiView id="MultiView1"
            runat="Server">

            <asp:View id="View1" 
                runat="Server">              
                    <asp:Label id="View1Label" 
                        Font-bold="true"
                        Font-size="14" 
                        Text="This is the content for View1."
                        runat="Server"
                        AssociatedControlID="View1">
                    </asp:Label>               
            </asp:View>
            
            <asp:View id="View2" 
                runat="Server">              
                    <asp:Label id="View2Label" 
                        Font-bold="true"
                        Font-size="14" 
                        Text="This is the content for View2."
                        runat="Server"
                        AssociatedControlID="View2">
                    </asp:Label>               
            </asp:View>
            
            <asp:View id="View3" 
                runat="Server">              
                    <asp:Label id="View3Label" 
                        Font-bold="true"
                        Font-size="14" 
                        Text="This is the content for View3."
                        runat="Server"
                        AssociatedControlID="View3">
                    </asp:Label>               
            </asp:View>

        </asp:MultiView>

    </form>
</body>
</html>
<!--</Snippet1>-->
