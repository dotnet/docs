<!--<Snippet1>-->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>View.Activate Event Example</title>

    <script runat="server">

        Sub Index_Changed(ByVal Sender As Object, ByVal e As EventArgs)
            ' Set the active view to
            ' the view selected by the user.
            Dim str As String = ViewListBox.SelectedItem.Text
            Select Case (str)
                Case "DefaultView"
                    MultiView1.SetActiveView(DefaultView)
                Case "NewsView"
                    MultiView1.SetActiveView(NewsView)
                Case "ShoppingView"
                    MultiView1.SetActiveView(ShoppingView)
            End Select

        End Sub

        ' The handler for the DefaultView's Activate event.
        Sub DefaultView_Activate(ByVal sender As Object, ByVal e As EventArgs)
            ' Notify the user that the event was raised.
            ActivateLabel.Text = "The Activate event was raised for the DefaultView."
        End Sub

        ' The handler for the DefaultView's Deactivate event.
        Sub DefaultView_Deactivate(ByVal sender As Object, ByVal e As EventArgs)
            ' Notify the user that the event was raised.
            DeactivateLabel.Text = "The Deactivate event was raised for the DefaultView."
        End Sub

        ' The handler for the ShoppingView's Activate event.
        Sub ShoppingView_Activate(ByVal sender As Object, ByVal e As EventArgs)
            ' Notify the user that the event was raised.
            ActivateLabel.Text = "The Activate event was raised for the ShoppingView."
        End Sub

        ' The handler for the ShoppingView's Deactivate event.
        Sub ShoppingView_Deactivate(ByVal sender As Object, ByVal e As EventArgs)
            ' Notify the user that the event was raised.
            DeactivateLabel.Text = "The Deactivate event was raised for the ShoppingView."
        End Sub

        ' The handler for the NewsView's Activate event.
        Sub NewsView_Activate(ByVal sender As Object, ByVal e As EventArgs)
            ' Notify the user that the event was raised.
            ActivateLabel.Text = "The Activate event was raised for the NewsView."
        End Sub

        ' The handler for the NewsView's Deactivate event.
        Sub NewsView_Deactivate(ByVal sender As Object, ByVal e As EventArgs)
            ' Notify the user that the event was raised.
            DeactivateLabel.Text = "The Deactivate event was raised for the NewsView."
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not (IsPostBack) Then
                MultiView1.SetActiveView(DefaultView)
            End If
        End Sub
    </script>

</head>
<body>
    <form id="Form1" runat="server">
        <h3>
            View Activate and Deactivate Events Example</h3>
        <h4>
            Select a view to display in a MultiView control:</h4>
        <asp:ListBox ID="ViewListBox" Rows="1" SelectionMode="Single" AutoPostBack="True"
            OnSelectedIndexChanged="Index_Changed" runat="Server">
            <asp:ListItem Value="0">DefaultView</asp:ListItem>
            <asp:ListItem Value="1">NewsView</asp:ListItem>
            <asp:ListItem Value="2">ShoppingView</asp:ListItem>
        </asp:ListBox><br />
        <br />
        <hr />
        <asp:MultiView ID="MultiView1" runat="Server">
            <asp:View ID="DefaultView" OnActivate="DefaultView_Activate" OnDeactivate="DefaultView_Deactivate"
                runat="Server">
                <asp:Panel ID="DefaultPanel1" Width="250px" BackColor="#C0C0FF" BorderColor="#404040"
                    BorderStyle="Double" runat="Server">
                    <asp:Label ID="DefaultLabel1" Font-Bold="true" Font-Size="20" Text="The Default View"
                        runat="Server" AssociatedControlID="DefaultView">
                    </asp:Label>
                </asp:Panel>
            </asp:View>
            <asp:View ID="NewsView" OnActivate="NewsView_Activate" OnDeactivate="NewsView_Deactivate"
                runat="Server">
                <asp:Panel ID="NewsPanel1" Width="250px" BackColor="#C0FFC0" BorderColor="#404040"
                    BorderStyle="Double" runat="Server">
                    <asp:Label ID="NewsLabel1" Font-Bold="true" Font-Size="20" Text="The News View" runat="Server"
                        AssociatedControlID="NewsView">                    
                    </asp:Label>
                </asp:Panel>
            </asp:View>
            <asp:View ID="ShoppingView" OnActivate="ShoppingView_Activate" OnDeactivate="ShoppingView_Deactivate"
                runat="Server">
                <asp:Panel ID="ShoppingPanel1" Width="250px" BackColor="#FFFFC0" BorderColor="#404040"
                    BorderStyle="Double" runat="Server">
                    <asp:Label ID="ShoppingLabel1" Font-Bold="true" Font-Size="20" Text="The Shopping View"
                        runat="Server" AssociatedControlID="ShoppingView">
                    </asp:Label>
                </asp:Panel>
            </asp:View>
        </asp:MultiView><br />
        <br />
        <asp:Label ID="ActivateLabel" BackColor="#ffff66" runat="Server">
        </asp:Label><br />
        <asp:Label ID="DeactivateLabel" BackColor="#ffff66" runat="Server">
        </asp:Label>
    </form>
</body>
</html>
<!--</Snippet1>-->
