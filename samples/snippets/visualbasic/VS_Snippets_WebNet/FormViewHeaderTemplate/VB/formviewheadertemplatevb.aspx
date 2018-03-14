<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub EmployeeFormView_ItemCreated(ByVal sender As Object, ByVal e As EventArgs)
  
    ' Use the HeaderRow property to retrieve the header row.
    Dim header As FormViewRow = EmployeeFormView.HeaderRow

    ' Retrieve the HeaderLabel Label control from the header row. 
    Dim headerLabel As Label = CType(header.FindControl("HeaderLabel"), Label)

    If headerLabel IsNot Nothing Then
    
      ' Display the current page number.
      Dim currentPage As Integer = EmployeeFormView.PageIndex + 1
      headerLabel.Text = "Page " & currentPage.ToString()
    
    End If

  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView HeaderTemplate Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>FormView HeaderTemplate Example</h3>
                       
      <asp:formview id="EmployeeFormView"
        datasourceid="EmployeeSource"
        allowpaging="true" 
        datakeynames="EmployeeID"
        onitemcreated="EmployeeFormView_ItemCreated"
        runat="server">
        
        <headertemplate>
          <table>
            <tr>
              <td>
                <asp:image id="LogoImage"
                  imageurl="~/Images/LogoImage.jpg"
                  alternatetext="Our Logo"
                  runat="server"/>
              </td>
              <td>
                <asp:label id="HeaderLabel"
                  runat="server"/>
              </td>
            </tr>
          </table>
        </headertemplate>
        
        <headerstyle horizontalalign="Center"
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