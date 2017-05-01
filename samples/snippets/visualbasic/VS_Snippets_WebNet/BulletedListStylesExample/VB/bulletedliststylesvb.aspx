<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BulletStyle Example</title>
<script runat="server">       
        Sub Index_Changed(ByVal sender As Object, ByVal e As System.EventArgs)
            ' Change the message displayed, based on 
            ' the style selected from the list box.
            If BulletStylesListBox.SelectedIndex > -1 Then
                Message.Text = "You selected bullet style: " & BulletStylesListBox.SelectedItem.Text
            End If

            ' Change the bullet style used, based on 
            ' the style selected from the list box.
            Select Case (BulletStylesListBox.SelectedIndex)
                Case 0
                    ItemsBulletedList.BulletStyle = BulletStyle.Numbered
                Case 1
                    ItemsBulletedList.BulletStyle = BulletStyle.LowerAlpha
                Case 2
                    ItemsBulletedList.BulletStyle = BulletStyle.UpperAlpha
                Case 3
                    ItemsBulletedList.BulletStyle = BulletStyle.LowerRoman
                Case 4
                    ItemsBulletedList.BulletStyle = BulletStyle.UpperRoman
                Case 5
                    ItemsBulletedList.BulletStyle = BulletStyle.Disc
                Case 6
                    ItemsBulletedList.BulletStyle = BulletStyle.Circle
                Case 7
                    ItemsBulletedList.BulletStyle = BulletStyle.Square
                Case 8
                    ItemsBulletedList.BulletStyle = BulletStyle.CustomImage
                    ' Specify the path to the custom image to use for the bullet.
                    ItemsBulletedList.BulletImageUrl = "Images/image1.jpg"
                Case 9
                    Message.Text = "You selected NotSet. The browser will determine the bullet style."
                Case Else
                    Throw New Exception("You did not select a valid bullet style.")
            End Select

        End Sub

</script>

</head>
<body>
    <form id="form1" runat="server"> 

        <h3>BulletStyle Example</h3>

        <asp:BulletedList id="ItemsBulletedList"             
            DisplayMode="Text" 
            BulletStyle="NotSet"
            runat="server">    
                <asp:ListItem Value="0">Coho Winery</asp:ListItem>
                <asp:ListItem Value="1">Contoso, Ltd.</asp:ListItem>
                <asp:ListItem Value="2">Tailspin Toys</asp:ListItem>
            </asp:BulletedList>        

            <hr />

        <h4>Select a bullet type:</h4>        
        <asp:ListBox id="BulletStylesListBox" 
            SelectionMode="Single"
            Rows="1" 
            OnSelectedIndexChanged="Index_Changed"
            AutoPostBack="True"
            runat="server">         
                <asp:ListItem Value="Numbered">Numbered</asp:ListItem>
                <asp:ListItem Value="LowerAlpha">LowerAlpha</asp:ListItem>
                <asp:ListItem Value="UpperAlpha">UpperAlpha</asp:ListItem>
                <asp:ListItem Value="LowerRoman">LowerRoman</asp:ListItem>
                <asp:ListItem Value="UpperRoman">UpperRoman</asp:ListItem>
                <asp:ListItem>Disc</asp:ListItem>
                <asp:ListItem>Circle</asp:ListItem>
                <asp:ListItem>Square</asp:ListItem>
                <asp:ListItem>CustomImage</asp:ListItem>       
                <asp:ListItem Value="NotSet">NotSet</asp:ListItem>
        </asp:ListBox>        
            
        <hr />

        <asp:Label id="Message" 
            runat="server"
            AssociatedControlID="BulletStylesListBox"/>            
                  
   </form>
</body>
</html>
<!--</Snippet1>-->
