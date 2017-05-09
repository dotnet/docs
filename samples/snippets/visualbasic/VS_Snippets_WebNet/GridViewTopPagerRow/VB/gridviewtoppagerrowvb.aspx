<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub PageDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    
    ' Retrieve the pager row.
    Dim pagerRow As GridViewRow = CustomersGridView.TopPagerRow
    
    ' Retrieve the PageDropDownList DropDownList from the bottom pager row.
    Dim pageList As DropDownList = CType(pagerRow.Cells(0).FindControl("PageDropDownList"), DropDownList)
        
    ' Set the PageIndex property to display that page selected by the user.
    CustomersGridView.PageIndex = pageList.SelectedIndex
    
  End Sub
    
  Sub CustomersGridView_DataBound(ByVal sender As Object, ByVal e As EventArgs)
    
    ' Get the PagerRow.
    Dim pagerRow As GridViewRow = CustomersGridView.TopPagerRow
    
    ' Retrieve the DropDownList and Label controls from the row.
    Dim pageList As DropDownList = CType(pagerRow.Cells(0).FindControl("PageDropDownList"), DropDownList)
    Dim pageLabel As Label = CType(pagerRow.Cells(0).FindControl("CurrentPageLabel"), Label)
        
    If Not pageList Is Nothing Then
        
      ' Create the values for the DropDownList control based on 
      ' the  total number of pages required to display the data
      ' source.
      Dim i As Integer
            
      For i = 0 To CustomersGridView.PageCount - 1
            
        ' Create a ListItem object to represent a page.
        Dim pageNumber As Integer = i + 1
        Dim item As ListItem = New ListItem(pageNumber.ToString())
            
        ' If the ListItem object matches the currently selected
        ' page, flag the ListItem object as being selected. Because
        ' the DropDownList control is recreated each time the pager
        ' row gets created, this will persist the selected item in
        ' the DropDownList control.   
        If i = CustomersGridView.PageIndex Then
          
          item.Selected = True
                
        End If
            
        ' Add the ListItem object to the Items collection of the 
        ' DropDownList.
        pageList.Items.Add(item)
                
      Next i
        
    End If
        
    If Not pageLabel Is Nothing Then
        
      ' Calculate the current page number.
      Dim currentPage As Integer = CustomersGridView.PageIndex + 1
        
      ' Update the Label control with the current page information.
      pageLabel.Text = "Page " & currentPage.ToString() & _
          " of " & CustomersGridView.PageCount.ToString()
        
    End If
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView TopPagerRow Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView TopPagerRow Example</h3>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource"   
        autogeneratecolumns="true"
        allowpaging="true"
        ondatabound="CustomersGridView_DataBound"  
        runat="server">
              
        <pagerstyle forecolor="Blue"
          backcolor="LightBlue"/>
          
        <pagersettings position="Top"/>
              
        <pagertemplate>
          
          <table width="100%">                    
            <tr>                        
              <td style="width:70%">
                          
                <asp:label id="MessageLabel"
                  forecolor="Blue"
                  text="Select a page:" 
                  runat="server"/>
                <asp:dropdownlist id="PageDropDownList"
                  autopostback="true"
                  onselectedindexchanged="PageDropDownList_SelectedIndexChanged" 
                  runat="server"/>
                      
              </td>   
                      
              <td style="width:70%" align="right">
                      
                <asp:label id="CurrentPageLabel"
                  forecolor="Blue"
                  runat="server"/>
                      
              </td>
                                            
            </tr>                    
          </table>
          
        </pagertemplate> 
          
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->