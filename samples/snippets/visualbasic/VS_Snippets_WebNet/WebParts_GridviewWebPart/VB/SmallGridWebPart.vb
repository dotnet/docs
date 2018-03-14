' <snippet2>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.Configuration
Imports System.Data.Sql
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Namespace Samples.AspNet.VB.Controls

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class SmallGridWebPart
    Inherits WebPart
    Private connString As String

    ' Use predefined strings for commands in the data source.
    Private Const selectStmt As String = "Select * from [Customers]"
    Private Const deleteCmd As String = "DELETE FROM [Customers] " _
      & "WHERE [CustomerID] = @CustomerID"
    Private Const insertCmd As String = "INSERT INTO [Customers] " _
      & "([CustomerID], [CompanyName], [ContactName], [Phone]) " _
      & "VALUES (@CustomerID, @CompanyName, @ContactName, @Phone)"
    Private Const updateCmd As String = "UPDATE [Customers] SET " _
      & "[CompanyName] = @CompanyName, [ContactName] = @ContactName, " _
      & "[Phone] = @Phone WHERE [CustomerID] = @CustomerID"


    Public Sub New()
      ExportMode = WebPartExportMode.All
    End Sub 'New

    ' This override prevents users from closing the control.
    Public Overrides Property AllowClose() As Boolean
      Get
        Return False
      End Get
      Set(ByVal value As Boolean)
        ' No implementation for the set accessor. We have to have 
        ' it because the base property has it, but we want to 
        ' prevent users from closing the control and developers 
        ' from being able to update the property.
      End Set
    End Property

    ' Allow page developers to set the connection string.
    Public Property ConnectionString() As String
      Get
        Return connString
      End Get
      Set(ByVal value As String)
        connString = value
      End Set
    End Property


    Protected Overrides Sub CreateChildControls()
      Controls.Clear()

      ' Create the SqlDataSource control.
      Dim ds As New SqlDataSource(Me.ConnectionString, selectStmt)
      ds.ID = "dsCustomers"
      ds.DataSourceMode = SqlDataSourceMode.DataSet
      ds.InsertCommandType = SqlDataSourceCommandType.Text
      ds.InsertCommand = insertCmd
      ds.UpdateCommandType = SqlDataSourceCommandType.Text
      ds.UpdateCommand = updateCmd
      ds.DeleteCommandType = SqlDataSourceCommandType.Text
      ds.DeleteCommand = deleteCmd
      Dim deleteParams As New ParameterCollection()
      deleteParams.Add(BuildParam("CustomerID", TypeCode.String))
      Dim insertParams As New ParameterCollection()
      insertParams.Add(BuildParam("CustomerID", TypeCode.String)) 
      insertParams.Add(BuildParam("CompanyName", TypeCode.String))
      insertParams.Add(BuildParam("ContactName", TypeCode.String)) 
      insertParams.Add(BuildParam("Phone", TypeCode.String))
      Dim updateParams As New ParameterCollection()
      updateParams.Add(BuildParam("CustomerID", TypeCode.String))
      updateParams.Add(BuildParam("CompanyName", TypeCode.String))
      updateParams.Add(BuildParam("ContactName", TypeCode.String))
      updateParams.Add(BuildParam("Phone", TypeCode.String))

      Me.Controls.Add(ds)

      ' Create the GridView control and bind it to the SqlDataSource.
      Dim grid As New GridView()
      grid.ID = "customerGrid"
      grid.Font.Size = 8
      grid.AllowPaging = True
      grid.AllowSorting = True
      grid.AutoGenerateColumns = False
      Dim fields As String() = {"CustomerID"}
      grid.DataKeyNames = fields
      grid.DataSourceID = "dsCustomers"
      Dim controlButton As New CommandField()
      controlButton.ShowEditButton = True
      controlButton.ShowSelectButton = True
      grid.Columns.Add(controlButton)
      Dim customerID As BoundField = BuildBoundField("CustomerID")
      customerID.ReadOnly = True
      grid.Columns.Add(customerID)
      grid.Columns.Add(BuildBoundField("CompanyName"))
      grid.Columns.Add(BuildBoundField("ContactName"))
      grid.Columns.Add(BuildBoundField("Phone"))

      Me.Controls.Add(grid)

    End Sub 'CreateChildControls


    Private Function BuildParam(ByVal paramName As String, _
      ByVal dataTypeCode As TypeCode) As Parameter

      Dim theParm As New Parameter(paramName, dataTypeCode)
      Return theParm

    End Function 'BuildParam


    Private Function BuildBoundField(ByVal fieldName _
      As String) As BoundField

      Dim theField As New BoundField()
      theField.DataField = fieldName
      theField.HeaderText = fieldName
      theField.SortExpression = fieldName
      Return theField

    End Function 'BuildBoundField
  End Class 'SmallGridWebPart 

End Namespace
' </snippet2>