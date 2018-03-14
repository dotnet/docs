<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>DisplayMode Example</title>
<script runat="server">
  
  void Index_Changed(object sender, System.EventArgs e)
  {

	  // Change the message displayed, based on 
	  // the display mode selected from the list box.
	  if (DisplayModeListBox.SelectedIndex > -1)
	  {
		  Message1.Text = "You chose: " + DisplayModeListBox.SelectedItem.Text;
	  }

	  // Change the display mode, based on 
	  // the mode selected from the list box.
	  switch (DisplayModeListBox.SelectedIndex) 
    {
		  case 0:
			  ItemsBulletedList.DisplayMode = BulletedListDisplayMode.Text;
			  Message2.Text = "";
			  break;
		  case 1:
			  ItemsBulletedList.DisplayMode = BulletedListDisplayMode.HyperLink;
			  // Opens a new browser window to display the page linked to.
			  ItemsBulletedList.Target = "_blank";
			  Message2.Text = "";
			  break;
		  case 2:
			  ItemsBulletedList.DisplayMode = BulletedListDisplayMode.LinkButton;
			  break;
		  default:
			  throw new Exception("You did not select a valid display mode.");
			  break;
	  }

  }

  void ItemsBulletedList_Click(object sender, System.Web.UI.WebControls.BulletedListEventArgs e)
  {

	  // Change the message displayed, based on the index
	  // of the bulletedlist list item that was clicked.
	  switch (e.Index) 
    {
		  case 0:
			  Message2.Text = "You  clicked list item 1.";
			  break;
		  case 1:
			  Message2.Text = "You  clicked list item 2.";
			  break;
		  case 2:
			  Message2.Text = "You  clicked list item 3.";
			  break;
		  default:
			  throw new Exception("You did not click a valid list item.");
			  break;
	  }

  }

</script>

</head>
<body>

  <h3>DisplayMode Example</h3>

  <form id="form1" runat="server">

    <h3>BulletedListDisplayMode Example</h3>

    <p>
    <asp:BulletedList id="ItemsBulletedList" 
      BulletStyle="Disc"
      DisplayMode="Text" 
      OnClick="ItemsBulletedList_Click"
      runat="server">    
      <asp:ListItem Value="http://www.cohowinery.com">Coho Winery</asp:ListItem>
      <asp:ListItem Value="http://www.contoso.com">Contoso, Ltd.</asp:ListItem>
      <asp:ListItem Value="http://www.tailspintoys.com">Tailspin Toys</asp:ListItem>
    </asp:BulletedList></p>

    <hr />

    <h4>Select from the list to change the display mode:</h4>
    <asp:ListBox id="DisplayModeListBox" 
      Rows="1"
      SelectionMode="Single"
      AutoPostBack="True"
      OnSelectedIndexChanged="Index_Changed"
      runat="server">
        <asp:ListItem>Text</asp:ListItem>
        <asp:ListItem>Hyperlink</asp:ListItem>
        <asp:ListItem>LinkButton</asp:ListItem>
    </asp:ListBox>

    <asp:Label id="Message1" 
      runat="server"
      AssociatedControlID="DisplayModeListBox"/><br /><br />

    <asp:Label id="Message2"
      runat="server"
      AssociatedControlID="DisplayModeListBox"/>

   </form>

</body>
</html>
<!--</Snippet1>-->