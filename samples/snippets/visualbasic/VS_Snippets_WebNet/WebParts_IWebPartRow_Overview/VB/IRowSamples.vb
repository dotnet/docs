 '<SNIPPET2>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Reflection
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Namespace Samples.AspNet.VB.Controls

  ' This sample code creates a Web Parts control that acts as a provider 
  ' of row data.
  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public NotInheritable Class RowProviderWebPart
    Inherits WebPart
    Implements IWebPartRow
    Private _table As DataTable


    Public Sub New()
      _table = New DataTable()

      Dim col As New DataColumn()
      col.DataType = GetType(String)
      col.ColumnName = "Name"
      _table.Columns.Add(col)

      col = New DataColumn()
      col.DataType = GetType(String)
      col.ColumnName = "Address"
      _table.Columns.Add(col)

      col = New DataColumn()
      col.DataType = GetType(Integer)
      col.ColumnName = "ZIP Code"
      _table.Columns.Add(col)

      Dim row As DataRow = _table.NewRow()
      row("Name") = "John Q. Public"
      row("Address") = "123 Main Street"
      row("ZIP Code") = 98000
      _table.Rows.Add(row)

    End Sub 'New


    <ConnectionProvider("Row")> _
    Public Function GetConnectionInterface() As IWebPartRow
      Return New RowProviderWebPart()

    End Function 'GetConnectionInterface


    Public ReadOnly Property Schema() As _
      ComponentModel.PropertyDescriptorCollection Implements IWebPartRow.Schema

      Get
        Return TypeDescriptor.GetProperties(_table.DefaultView(0))
      End Get

    End Property


    Public Sub GetRowData(ByVal callback As RowCallback) _
      Implements IWebPartRow.GetRowData
      callback(_table.Rows)

    End Sub

  End Class 'RowProviderWebPart 


  ' This sample code creates a Web Parts control that acts as a consumer 
  ' of row data.
  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public NotInheritable Class RowConsumerWebPart
    Inherits WebPart
    Private _provider As IWebPartRow
    Private _tableData As ICollection


    Private Sub GetRowData(ByVal rowData As Object)
      _tableData = CType(rowData, ICollection)

    End Sub


    Protected Overrides Sub OnPreRender(ByVal e As EventArgs)

      If Not (_provider Is Nothing) Then
        _provider.GetRowData(New RowCallback(AddressOf GetRowData))
      End If

    End Sub

    Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)

      If Not (_provider Is Nothing) Then
        Dim props As PropertyDescriptorCollection = _provider.Schema
        Dim count As Integer = 0
        If Not (props Is Nothing) AndAlso props.Count > 0 _
          AndAlso Not (_tableData Is Nothing) Then

          Dim prop As PropertyDescriptor
          For Each prop In props
            Dim o As DataRow
            For Each o In _tableData
              writer.Write(prop.DisplayName & ": " & o(count))
              writer.WriteBreak()
              writer.WriteLine()
              count = count + 1
            Next o
          Next prop
        Else
          writer.Write("No data")
        End If
      Else
        writer.Write("Not connected")
      End If

    End Sub


    <ConnectionConsumer("Row")> _
    Public Sub SetConnectionInterface(ByVal provider As IWebPartRow)
      _provider = provider

    End Sub

  End Class 'RowConsumerWebPart 

End Namespace  ' Samples.AspNet.VB.Controls 
'</SNIPPET2>