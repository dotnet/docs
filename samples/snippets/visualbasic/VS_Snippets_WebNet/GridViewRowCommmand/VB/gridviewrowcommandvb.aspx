<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub ContactsGridView_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

    ' If multiple buttons are used in a GridView control, use the
    ' CommandName property to determine which button was clicked.
    If e.CommandName = "Add" Then
    
      ' Convert the row index stored in the CommandArgument
      ' property to an Integer.
      Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            
      ' Retrieve the row that contains the button clicked 
      ' by the user from the Rows collection.
      Dim row As GridViewRow = ContactsGridView.Rows(index)
            
      ' Create a new ListItem object for the contact in the row.     
      Dim item As New ListItem()
      item.Text = Server.HtmlDecode(row.Cells(2).Text) & " " & _
        Server.HtmlDecode(row.Cells(3).Text)
            
      ' If the contact is not already in the ListBox, add the ListItem 
      ' object to the Items collection of the ListBox control. 
      If Not ContactsListBox.Items.Contains(item) Then
      
        ContactsListBox.Items.Add(item)
        
      End If
      
    End If
    
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>GridView RowCommand Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>GridView RowCommand Example</h3>

      <table width="100%">
        <tr>
          <td style="width:50%">

            <asp:gridview id="ContactsGridView" 
              datasourceid="ContactsSource"
              allowpaging="true" 
              autogeneratecolumns="false"
              onrowcommand="ContactsGridView_RowCommand"
              runat="server">

              <columns>
                <asp:buttonfield buttontype="Link" 
                  commandname="Add" 
                  text="Add"/>
                <asp:boundfield datafield="ContactID" 
                  headertext="Contact ID"/>
                <asp:boundfield datafield="FirstName" 
                  headertext="First Name"/> 
                <asp:boundfield datafield="LastName" 
                  headertext="Last Name"/>
              </columns>

            </asp:gridview>

          </td>

          <td style="vertical-align:top; width:50%">

            Contacts: <br/>
            <asp:listbox id="ContactsListBox"
              runat="server" Height="200px" Width="200px"/>

          </td>
        </tr>
      </table>

      <!-- This example uses Microsoft SQL Server and connects    -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET  -->
      <!-- expression to retrieve the connection string value     -->
      <!-- from the Web.config file.                              -->
      <asp:sqldatasource id="ContactsSource"
        selectcommand="Select [ContactID], [FirstName], [LastName] From Person.Contact"
        connectionstring="<%$ ConnectionStrings:AdventureWorks_DataConnectionString%>" 
        runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->