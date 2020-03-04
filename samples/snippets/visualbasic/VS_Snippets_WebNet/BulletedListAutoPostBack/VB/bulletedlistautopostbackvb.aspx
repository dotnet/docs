<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AutoPostBack Property Example</title>
<script runat="server">

        Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

            Dim value As Boolean
            ' Get the value of AutoPostBack for this bulleted list.
            value = ItemsBulletedList.AutoPostBack

            ' This property is not applicable to the BulletedList class.
            ' This message will never be displayed.
            If value = True Then
                   Message.Text = "The value of the AutoPostBack property is True."
            End If

             ' The default AutoPostBack value inherited from ListControl is False.
             ' This message will always be displayed.
            If value = False Then
                Message.Text = "The value of the AutoPostBack property is " & value & "." _
                    & "This property is inherited by the ListControl class." _
                    & "It is not applicable to the BulletedList class."
            End If
        End Sub

    </script>

</head>
<body>

    <h3>AutoPostBack Property Example</h3>

    <form id="form1" runat="server">
                    
        <asp:BulletedList id="ItemsBulletedList" 
            BulletStyle="Disc"
            DisplayMode="Text" 
            runat="server">    
                <asp:ListItem Value="0">The first list item.</asp:ListItem>
            <asp:ListItem Value="1">The second list item.</asp:ListItem>
        <asp:ListItem Value="2">The third list item.</asp:ListItem>
        <asp:ListItem Value="3">The fourth list item.</asp:ListItem>
        </asp:BulletedList>        
        
    <p>        
    <asp:Label id="Message" 
        Font-Size="12"
        Width="368px" 
        runat="server"/></p>
                           
    </form>

</body>
</html>
<!--</Snippet1>-->