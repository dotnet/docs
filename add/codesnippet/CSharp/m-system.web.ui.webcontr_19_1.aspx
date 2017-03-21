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