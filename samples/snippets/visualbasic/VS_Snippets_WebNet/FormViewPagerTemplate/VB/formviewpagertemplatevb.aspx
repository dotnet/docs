<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub EmployeeFormView_DataBound(ByVal sender As Object, ByVal e As EventArgs)

    ' Get the pager row.
    Dim pagerRow As FormViewRow = EmployeeFormView.BottomPagerRow

    ' Get the Label controls that display the current page information 
    ' from the pager row.
    Dim pageNum As Label = CType(pagerRow.Cells(0).FindControl("PageNumberLabel"), Label)
    Dim totalNum As Label = CType(pagerRow.Cells(0).FindControl("TotalPagesLabel"), Label)

    If pageNum IsNot Nothing And totalNum IsNot Nothing Then

      ' Update the Label controls with the current page values.
      Dim page As Integer = EmployeeFormView.PageIndex + 1
      Dim count As Integer = EmployeeFormView.PageCount

      pageNum.Text = page.ToString()
      totalNum.Text = count.ToString()
    
    End If

  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView PagerTemplate Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView PagerTemplate Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true"
        datakeynames="EmployeeID"
        ondatabound="EmployeeFormView_DataBound" 
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
                <h3><%# Eval("FirstName") %>&nbsp;<%# Eval("LastName") %></h3>      
                <%# Eval("Title") %>        
              </td>
            </tr>
          </table>    
        </itemtemplate>
        
        <pagertemplate>   
          <table width="100%">
            <tr>
              <td>
                <asp:linkbutton id="PreviousButton"
                  text="<"
                  commandname="Page"
                  commandargument="Prev"
                  runat="Server"/>
                <asp:linkbutton id="NextButton"
                  text=">"
                  commandname="Page"
                  commandargument="Next"
                  runat="Server"/> 
              </td>
              <td align="right">                
                Page <asp:label id="PageNumberLabel" runat="server"/> 
                of <asp:label id="TotalPagesLabel" runat="server"/>                
              </td>
            </tr>
          </table>          
        </pagertemplate>
          
        <pagersettings position="Bottom"
          mode="NextPrevious"/> 
                  
      </asp:formview>
          
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [Title], [PhotoPath] From [Employees]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->