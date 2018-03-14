<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BulletImageUrl Example</title>
</head>
<body>

    <h3>BulletImageUrl Example</h3>

    <form id="form1" runat="server">
                    
        <asp:BulletedList id="ItemsBulletedList"             
        DisplayMode="Text" 
        BulletStyle="CustomImage"
        BulletImageUrl="Images/image1.jpg"
        runat="server">    
            <asp:ListItem Value="0">Coho Winery</asp:ListItem>
        <asp:ListItem Value="1">Contoso, Ltd.</asp:ListItem>
        <asp:ListItem Value="2">Tailspin Toys</asp:ListItem>
        </asp:BulletedList>                        
              
   </form>

</body>
</html>
<!--</Snippet1>-->