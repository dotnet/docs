<!-- <Snippet1> -->

<%@ page language="VB" autoeventwireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub ItemDetailsView_ItemCommand(ByVal sender As Object, _
    ByVal e As DetailsViewCommandEventArgs) _
    Handles ItemDetailsView.ItemCommand

    ' Use the CommandName property to determine which button
    ' was clicked. 
    If e.CommandName = "Add" Then

      ' Add the customer to the customer list. 

      ' Get the row that contains the company name. In this
      ' example, the company name is in the second row (index 1)  
      ' of the DetailsView control.
      Dim row As DetailsViewRow = ItemDetailsView.Rows(1)

      ' Get the company's name from the appropriate cell.
      ' In this example, the company name is in the second cell  
      ' (index 1) of the row.
      Dim name As String = row.Cells(1).Text

      ' Create a ListItem object with the company name.
      Dim item As New ListItem(name)

      ' Add the ListItem object to the ListBox control, if the 
      ' item does not already exist.
      If Not CustomerListBox.Items.Contains(item) Then

        CustomerListBox.Items.Add(item)
        
      End If

    End If

  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewCommandEventArgs Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>DetailsViewCommandEventArgs Example</h3>
  
      <asp:detailsview id="ItemDetailsView"
        datasourceid="DetailsViewSource"
        allowpaging="true"
        autogeneraterows="false"  
        runat="server">
        <fields>
          <asp:boundfield datafield="CustomerID"
            headertext="Customer ID"/>
          <asp:boundfield datafield="CompanyName"
            headertext="Company Name"/>
          <asp:boundfield datafield="Address"
            headertext="Address"/>
          <asp:boundfield datafield="City"
            headertext="City"/>
          <asp:boundfield datafield="PostalCode"
            headertext="ZIP Code"/>
          <asp:boundfield datafield="Country"
            headertext="Country"/>
          <asp:buttonfield buttontype="Link"
            causesvalidation="false"
            text="Add to List"
            commandname="Add"/>
        </fields>
      </asp:detailsview>
      
      <br/><br/>
      
      Selected Customers:<br/>
      <asp:listbox id="CustomerListBox"
        runat="server"/>
      
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="DetailsViewSource"
        selectcommand="Select [CustomerID], [CompanyName], [Address], 
          [City], [PostalCode], [Country] From [Customers]"
        connectionstring=
            "<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>  
  
    </form>
  </body>
</html>
<!-- </Snippet1> -->