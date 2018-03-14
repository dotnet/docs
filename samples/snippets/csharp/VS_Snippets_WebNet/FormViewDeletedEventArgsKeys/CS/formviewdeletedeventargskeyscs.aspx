<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void EmployeeFormView_ItemDeleted(Object sender, FormViewDeletedEventArgs e)
  {
    // Display the values of the key fields in the Keys property.
    KeysMessageLabel.Text =
      "The key fields for the deleted record are: <br/>";

    foreach (DictionaryEntry entry in e.Keys)
    {
      DisplayValue(entry, KeysMessageLabel);
    }

    // Display the values of the non-key fields in the Values 
    // property.
    ValuesMessageLabel.Text =
      "The non-key fields for the deleted record are: <br/>";

    foreach (DictionaryEntry entry in e.Values)
    {
      DisplayValue(entry, ValuesMessageLabel);
    }

  }

  void DisplayValue(DictionaryEntry entry, Label displayLabel)
  {
    // Display the field name contained in the DictionaryEntry object.
    if (entry.Key != null)
    {
      displayLabel.Text += "Name=" + entry.Key.ToString() + ", ";
    }
    else
    {
      displayLabel.Text += "Name=null, ";
    }

    // Display the field value contained in the DictionaryEntry object.
    if (entry.Value != null)
    {
      displayLabel.Text += "Value=" + entry.Value.ToString() + "<br/>";
    }
    else
    {
      displayLabel.Text += "Value=null<br/>";
    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormViewDeletedEventArgs Keys and Values Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormViewDeletedEventArgs Keys and Values Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        onitemdeleted="EmployeeFormView_ItemDeleted"  
        runat="server">
        
        <itemtemplate>
        
          <table>
            <tr>
              <td>
                <asp:image id="EmployeeImage"
                  imageurl='<%# Eval("PhotoPath") %>'
                  alternatetext='<%# Eval("LastName") %>' 
                  runat="server"/>
              </td>
              <td>
                <asp:label id="FirstNameLabel"
                  text='<%#Bind("FirstName")%>'
                  font-bold="true"
                  runat="server"/>
                <asp:label id="LastNameLabel"
                  text='<%#Bind("LastName")%>'
                  font-bold="true"
                  runat="server"/>
                <br/>     
                <asp:label id="TitleLabel"
                  text='<%#Bind("Title")%>'
                  runat="server"/>        
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:button id="DeleteButton"
                  text="Delete Record"
                  commandname="Delete"
                  runat="server" />
              </td>
            </tr>
          </table>
        
        </itemtemplate>         
                  
      </asp:formview>
      
      <asp:label id="KeysMessageLabel"
        forecolor="Red"
        runat="server"/>
          
      <br/><br/>
          
      <asp:label id="ValuesMessageLabel"
        forecolor="Red"
        runat="server"/>
          
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [Title], [PhotoPath] From [Employees]"
        deletecommand="Delete [Employees] Where [EmployeeID]=@EmployeeID"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->