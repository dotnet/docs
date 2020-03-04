<!-- <Snippet1> -->
<%@ page language="VB" autoeventwireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub ItemDetailsView_ItemCommand(ByVal sender As Object, _
    ByVal e As DetailsViewCommandEventArgs) _
    Handles CustomerDetailsView.ItemCommand, _
    EmployeesDetailsView.ItemCommand
   
    ' Use the CommandName property to determine which button
    ' was clicked. 
    If e.CommandName = "Add" Then
      
      ' Because this event handler is used for two different
      ' DetailsView controls, use the CommandSource property 
      ' to get the DetailsView control that raised the event.
      Dim view As DetailsView = CType(e.CommandSource, DetailsView)
      
      ' Determine which ListBox control to update based on the
      ' ID of the DetailsView control that raised the event.
      Dim list As ListBox
      If view.ID = "CustomerDetailsView" Then

        list = CustomerListBox
      
      Else
      
        list = EmployeesListBox
      
      End If

      ' Add the selected item to the appropriate ListBox control. 

      ' Get the row that contains the value to add. For this
      ' example, get the second row (index 1) of the DetailsView 
      ' control.
      Dim row As DetailsViewRow = view.Rows(1)

      ' Get the value from the appropriate cell. For this
      ' example, get the value of the second cell (index 1) 
      ' of the row.
      Dim value As String = row.Cells(1).Text

      ' Create a ListItem object using the value.
      Dim item As New ListItem(value)

      ' Add the ListItem object to the ListBox control, if the 
      ' item does not already exist.
      If Not list.Items.Contains(item) Then
      
        list.Items.Add(item)
        
      End If

    End If

  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewCommandEventArgs CommandSource Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>DetailsViewCommandEventArgs CommandSource Example</h3>
  
      <table border="0">
        <tr valign="top">
          <td>
            <asp:detailsview id="CustomerDetailsView"
              datasourceid="CustomerSource"
              allowpaging="true"
              autogeneraterows="true" 
              onitemcommand="ItemDetailsView_ItemCommand"  
              runat="server">
              <fields>
                <asp:buttonfield buttontype="Link"
                  causesvalidation="false"
                  text="Add to List"
                  commandname="Add"/>
              </fields>
            </asp:detailsview>
          </td>
          <td>
            <asp:detailsview id="EmployeesDetailsView"
              datasourceid="EmployeesSource"
              allowpaging="true"
              autogeneraterows="true" 
              onitemcommand="ItemDetailsView_ItemCommand"  
              runat="server">
              <fields>
                <asp:buttonfield buttontype="Link"
                  causesvalidation="false"
                  text="Add to List"
                  commandname="Add"/>
              </fields>
            </asp:detailsview>
          </td>
        </tr>
        <tr>
          <td>
            Selected Customers:<br/>
            <asp:listbox id="CustomerListBox"
              runat="server"/>
          </td>
          <td>
            Selected Employees:<br/>
            <asp:listbox id="EmployeesListBox"
              runat="server"/>
          </td>
        </tr>
      </table>
      
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomerSource"
        selectcommand="Select [CustomerID], [CompanyName], [Address], 
          [City], [PostalCode], [Country] From [Customers]"
        connectionstring=
            "<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>  
        
      <asp:sqldatasource id="EmployeesSource"
        selectcommand="Select [EmployeeID], [FirstName], [LastName], 
          [Title] From [Employees]"
        connectionstring=
            "<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
  
    </form>
  </body>
</html>
<!-- </Snippet1> -->