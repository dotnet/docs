<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server">

' System.Web.UI.WebControls.ListItemCollection.SyncRoot;System.Web.UI.WebControls.ListItemCollection.AddRange;
' System.Web.UI.WebControls.ListItemCollection.Remove(String)

' The following example demonstrates the 'Remove(String)','AddRange' methods and 'SyncRoot' 
' property of 'ListItemCollection' class. 
' It create a 'ListBox' webcontrol with some list items in it and gives option to add two listitems at a time
' to the user.The values  entered in the textfields are added to the 'ListBox' by using 'AddRange' method. It 
' also provides a  textfield to take the item  name to be removed from the 'ListBox'.

           Dim ItemCollection As ListItemCollection
           
              Sub AddButton_Click(Sender As Object, e As EventArgs )
              
                ' Create a array of type 'ListItem' .

                 Dim listItemArray(1) As ListItem 
                 Dim myListItem1 As ListItem=Nothing
                 Dim myListItem2 As ListItem=Nothing
                 
                 ' Check whether the textfield values are null or not.
                 If ((Item1.Text <> "") And (Item2.Text <> "")) Then
                 
                     myListItem1 = new ListItem(Item1.Text.ToLower(),Item1.Text.ToLower())
                     myListItem2 = new ListItem(Item2.Text.ToLower(),Item2.Text.ToLower())
                     ' Check whether the 'ItemName' entered by user in textfield already exists in 'ListBox' or not.
                     If (Not ItemCollection.Contains(myListItem1)) Then
                     
' <Snippet1>
' <Snippet2>

                       ' Check whether the 'ItemName' entered by user in textfield is already exists in 'ListBox' or not.             
                        If(Not ItemCollection.Contains(myListItem2)) Then
                        
                           ' Obtain a thread safe 'ListItemCollection' object to allow synchronized access.                          
                           Dim myItemCollection As ListItemCollection = CType(ItemCollection.SyncRoot,ListItemCollection)
                           listItemArray.SetValue(myListItem1,0)
                           listItemArray.SetValue(myListItem2,1)

                           ' Add the ListItem' array to the ListBox.

                           myItemCollection.AddRange(listItemArray)
                           Message.Text="<font color='green'><b>Added Successfully</b></font>"
                           
' </Snippet2>
' </Snippet1>

                          Else
                           
                             Message.Text = "<font color='red'><b>'"+myListItem2.Value+"' already present in the ListBox. Please enter another one.</b></font>"
                           End If
                        
                        Else
                        
                           Message.Text = "<font color='red'><b>'"+myListItem1.Value+"' already present in the ListBox. Please enter another one.</b></font>"
                        End If                     
                    
                    Else
                    
                      Message.Text = "<font color='red'><b>Text Field is Empty without any value. Please enter the value.</b></font>"
                    End If
               End Sub
           
            Sub Delete_Click(Sender As Object, e As EventArgs ) 
           
' <Snippet3>    
          
               Dim myListItem As ListItem = new ListItem(Delete.Text.ToLower(),Delete.Text.ToLower())
               ' Check whether the 'ListItem' is present in the 'ListBox' or not.
               If(ItemCollection.Contains(myListItem)) Then
               
                  Dim deleteString As String =Delete.Text
                  ' Delete the listitem entered by the user in textfield.
                  ItemCollection.Remove(deleteString.ToLower())
                  Message.Text="<font color='green'><b>Deleted Successfully</b></font>"
               Else
               
                 Message.Text="<font color='red'><b>No ListItem with the given name is present in the ListBox for deletion.</b></font>"
               End If
' </Snippet3>

        End Sub                             
          
             Sub Page_Load(Sender As Object, e As EventArgs ) 
           
             ' Create the 'ItemCollection' object.       
               ItemCollection = Listbox1.Items
               Message.Text=""
          End Sub
           
             
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
