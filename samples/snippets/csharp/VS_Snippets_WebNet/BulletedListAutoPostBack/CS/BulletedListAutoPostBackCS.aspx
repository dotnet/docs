<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AutoPostBack Property Example</title>
<script language="c#" runat="server">

        void Page_Load(Object sender, EventArgs e)
        {
            // Get the value of AutoPostBack for this bulleted list.
            bool value;
            value = ItemsBulletedList.AutoPostBack;

            // This property is not applicable to the BulletedList class.
            // This message will never be displayed.
            if(value)
            {
                Message.Text = "The value of the AutoPostBack property is True.";
            }

            // The default AutoPostBack value inherited from ListControl is False.
            // This message will always be displayed.
            if(!value)
            {
                Message.Text = "The value of the AutoPostBack property is " + value.ToString() + "."
                    + "This property is inherited by the ListControl class."
                    + "It is not applicable to the BulletedList class.";
            }
        }       


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
