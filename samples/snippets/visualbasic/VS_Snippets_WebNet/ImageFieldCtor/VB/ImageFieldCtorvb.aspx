<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    If Not IsPostBack Then
      
      ' Dynamically create a GridView control.
      Dim employeesView As GridView = New GridView()
      employeesView.ID = "EmployeesGrid"
      employeesView.AutoGenerateColumns = False
      employeesView.DataSourceID = "EmployeeSource"

      ' Dynamically create field columns to display the desired
      ' fields from the data source.

      ' Create an ImageField object to display an employee's photo.
      Dim photoImageField As ImageField = New ImageField()
      photoImageField.DataImageUrlField = "PhotoPath"
      photoImageField.AlternateText = "Employee Photo"
      photoImageField.NullDisplayText = "No image on file."
      photoImageField.HeaderText = "Photo"
      photoImageField.ReadOnly = True

      ' Create a BoundField object to display an employee's last name.
      Dim lastNameBoundField As BoundField = New BoundField()
      lastNameBoundField.DataField = "LastName"
      lastNameBoundField.HeaderText = "Last Name"

      ' Create a BoundField object to display an employee's first name.
      Dim firstNameBoundField As BoundField = New BoundField()
      firstNameBoundField.DataField = "FirstName"
      firstNameBoundField.HeaderText = "First Name"

      ' Add the field columns to the Fields collection of the
      ' GridView control.
      employeesView.Columns.Add(photoImageField)
      employeesView.Columns.Add(lastNameBoundField)
      employeesView.Columns.Add(firstNameBoundField)
      
      ' Add the GridView control to the Controls collection
      ' of the PlaceHolder control. 
      GridViewPlaceHolder.Controls.Add(employeesView)

    End If

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ImageField Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>ImageField Constructor Example</h3>
                  
      <asp:placeholder id="GridViewPlaceHolder"
        runat="server"/>            
           
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [PhotoPath] From [Employees]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->