<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server">
/*    System.Web.UI.WebControls.ListItemCollection.SyncRoot;System.Web.UI.WebControls.ListItemCollection.AddRange;
    System.Web.UI.WebControls.ListItemCollection.Remove(String)
    
    The following example demonstrates the 'Remove(String)','AddRange' methods and 'SyncRoot' 
    property of 'ListItemCollection' class. 

    It create a 'ListBox' webcontrol with some list items in it and gives option to add two listitems at a time
    to the user.The values  entered in the textfields are added to the 'ListBox' by using 'AddRange' method. It 
    also provides a  textfield to take the item  name to be removed from the 'ListBox'.
*/
           ListItemCollection ItemCollection;
           
              void AddButton_Click(Object Sender, EventArgs e)
              {
                   // Create a array of type 'ListItem'. 
                 ListItem[] listItemArray = new ListItem[2];
                 ListItem myListItem1=null;
                 ListItem myListItem2=null;
                 
                 // Check whether the textfield values are null or not.
                 if ((Item1.Text!="") && (Item2.Text!=""))
                 {
                     myListItem1 = new ListItem(Item1.Text.ToLower(),Item1.Text.ToLower());
                     myListItem2 = new ListItem(Item2.Text.ToLower(),Item2.Text.ToLower());
                     // Check whether the 'ItemName' entered by user in textfield already exists in 'ListBox' or not.
                     if (!ItemCollection.Contains(myListItem1))
                     {
// <Snippet1>
// <Snippet2>

                       // Check whether the 'ItemName' entered by user in textfield is already exists in 'ListBox' or not.             
                        if(!ItemCollection.Contains(myListItem2))
                        {  
                           // Obtain a thread safe 'ListItemCollection' object to allow synchronized access.                          
                           ListItemCollection myItemCollection = (ListItemCollection)ItemCollection.SyncRoot;
                           listItemArray.SetValue(myListItem1,0);
                           listItemArray.SetValue(myListItem2,1);
                           // Add the ListItem' array to the ListBox.
                              myItemCollection.AddRange(listItemArray);
                             Message.Text="<font color='green'><b>Added Successfully</b></font>";
                           }
// </Snippet2>
// </Snippet1>

                          else
                           {
                             Message.Text = "<font color='red'><b>'"+myListItem2.Value+"' already present in the ListBox. Please enter another one.</b></font>";
                           }
                        }
                        else
                        {
                           Message.Text = "<font color='red'><b>'"+myListItem1.Value+"' already present in the ListBox. Please enter another one.</b></font>";
                        }                     
                    }
                    else
                    {
                      Message.Text = "<font color='red'><b>Text Field is Empty without any value. Please enter the value.</b></font>";
                    }
               }
           
            void Delete_Click(Object Sender, EventArgs e) 
            {
// <Snippet3>          
               ListItem myListItem = new ListItem(Delete.Text.ToLower(),Delete.Text.ToLower());
               // Check whether the 'ListItem' is present in the 'ListBox' or not.
               if(ItemCollection.Contains(myListItem))
               {
                  String deleteString=Delete.Text;
                  // Delete the listitem entered by the user in textfield.
                  ItemCollection.Remove(deleteString.ToLower());
                  Message.Text="<font color='green'><b>Deleted Successfully</b></font>";
               }
               else
               {
                 Message.Text="<font color='red'><b>No ListItem with the given name is present in the ListBox for deletion.</b></font>";
               }               
// </Snippet3>
           }                             
          
          void Page_Load(Object Sender, EventArgs e) 
           { 
             // Create the 'ItemCollection' object.       
               ItemCollection = Listbox1.Items;
               Message.Text="";
          }
           
             
      </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>ListItemCollection Example</title>
    </head>
<body>
        <h3 style="text-align:center">ListItemCollection Example</h3>
        <form runat="server" id="Form1">
            <asp:ListBox id="Listbox1" Width="100px" runat="server">
                <asp:ListItem Value="item1">item1</asp:ListItem>
                <asp:ListItem Value="item2">item2</asp:ListItem>
                <asp:ListItem Value="item3">item3</asp:ListItem>
                <asp:ListItem Value="item4">item4</asp:ListItem>
                <asp:ListItem Value="item5">item5</asp:ListItem>
                <asp:ListItem Value="item6">item6</asp:ListItem>
            </asp:ListBox>
            <br />
            <asp:Label ID="Message" Runat="server"></asp:Label>
            <br />
            Please enter the Items you want to add to ListBox
            <br />
            Enter the first item &nbsp;&nbsp;<b>:</b>&nbsp;<asp:TextBox ID="Item1" Runat="server"></asp:TextBox>
            <br />
            Enter the second item<b>:</b>
            <asp:TextBox ID="Item2" Runat="server"></asp:TextBox>
            <br />
            <asp:button Text="Add to ListBox " OnClick="AddButton_Click" runat="server" ID="Add" />
            <br />
            <b>Please enter the Item name to delete from the ListBox</b>
            <br />
            Enter the item name to delete <b>:</b>
            <asp:TextBox ID="Delete" Runat="server"></asp:TextBox>
            <br />
            <asp:Button Text="Delete from ListBox" OnClick="Delete_Click" Runat="server" ID="Button1"></asp:Button>
            <asp:Label ID="DisplayAll" Runat="server"></asp:Label>
        </form>
</body>
</html>
