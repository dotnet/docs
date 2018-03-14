<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub EmployeeFormView_ItemCreated(ByVal sender As Object, ByVal e As EventArgs)

    ' Use the FooterRow property to retrieve the footer row.
    Dim footer As FormViewRow = EmployeeFormView.FooterRow

    ' Retrieve the FooterLabel Label control from the footer row. 
    Dim footerLabel As Label = CType(footer.FindControl("FooterLabel"), Label)

    If footerLabel IsNot Nothing Then
      
      ' Display the current page number.
      Dim currentPage As Integer = EmployeeFormView.PageIndex + 1
      footerLabel.Text = "Page " & currentPage.ToString()
    
    End If
  
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView FooterTemplate Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView FooterTemplate Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true" 
        datakeynames="EmployeeID"
        onitemcreated="EmployeeFormView_ItemCreated"
        runat="server">
        
        <footertemplate>
          <table>
            <tr>
              <td>
                <asp:image id="LogoImage"
                  imageurl="~/Images/LogoImage.jpg"
                  alternatetext="Our Logo" 
                  runat="server"/>
              </td>
              <td>
                <asp:label id="FooterLabel"
                  runat="server"/>
              </td>
            </tr>
          </table>
        </footertemplate>
        
        <footerstyle horizontalalign="Center"
          forecolor="White"
          backcolor="LightBlue"/>
           
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