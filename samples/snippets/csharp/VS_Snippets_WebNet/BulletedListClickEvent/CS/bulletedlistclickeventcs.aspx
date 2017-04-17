<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>BulletedList Click Example</title>
  <script runat="server">

    void ItemsBulletedList_Click(object sender, System.Web.UI.WebControls.BulletedListEventArgs e)
    {

	    // Change the message displayed in the label based on the index
	    // of the list item that was clicked.
	    switch (e.Index) 
      {
		    case 0:
			    Message.Text = "You clicked list item 1.";
			    break;
		    case 1:
			    Message.Text = "You clicked list item 2.";
			    break;
		    case 2:
			    Message.Text = "You clicked list item 3.";
			    break;
		    default:
			    throw new Exception("You did not click a valid list item.");
			    break;
	    }

    }

  </script>

</head>
<body>

  <h3>BulletedList Click Example</h3>

  <form id="form1" runat="server">
            
    <p>Click on an item in the list to raise the Click event.</p> 
    
    <asp:BulletedList id="ItemsBulletedList" 
      BulletStyle="Disc"
      DisplayMode="LinkButton" 
      OnClick="ItemsBulletedList_Click"
      runat="server">    
        <asp:ListItem Value="http://www.cohowinery.com">Coho Winery</asp:ListItem>
        <asp:ListItem Value="http://www.contoso.com">Contoso, Ltd.</asp:ListItem>
        <asp:ListItem Value="http://www.tailspintoys.com">Tailspin Toys</asp:ListItem>
    </asp:BulletedList>
            
    <asp:Label id="Message" 
      Font-Size="12"
      Width="168px" 
      Font-Bold="True" 
      runat="server"
      AssociatedControlID="ItemsBulletedList"/>
              
   </form>

</body>
</html>
<!--</Snippet1>-->