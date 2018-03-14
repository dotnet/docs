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
  ' of table data.
  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public NotInheritable Class TableProviderWebPart
    Inherits WebPart
    Implements IWebPartTable
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

    End Sub


    Public ReadOnly Property Schema() As _
      ComponentModel.PropertyDescriptorCollection Implements IWebPartTable.Schema

      Get
        Return TypeDescriptor.GetProperties(_table.DefaultView(0))
      End Get

    End Property


    Public Sub GetTableData(ByVal callback As TableCallback) _
      Implements IWebPartTable.GetTableData

      callback(_table.Rows)

    End Sub


    Public Property ConnectionPointEnabled() As Boolean
      Get
        Dim o As Object = ViewState("ConnectionPointEnabled")
        Return IIf(Not (o Is Nothing), CBool(o), True)
      End Get
      Set(ByVal value As Boolean)
        ViewState("ConnectionPointEnabled") = value
      End Set
    End Property


    <ConnectionProvider("Table", GetType(TableProviderConnectionPoint), _
      AllowsMultipleConnections:=True)> _
    Public Function GetConnectionInterface() As IWebPartTable

      Return New TableProviderWebPart()

    End Function

  End Class 'TableProviderWebPart

  ' The connection point for the provider control.
  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class TableProviderConnectionPoint
    Inherits ProviderConnectionPoint

    Public Sub New(ByVal callbackMethod As MethodInfo, _
      ByVal interfaceType As Type, ByVal controlType As Type, _
      ByVal name As String, ByVal id As String, _
      ByVal allowsMultipleConnections As Boolean)
      MyBase.New(callbackMethod, interfaceType, controlType, _
        name, id, allowsMultipleConnections)

    End Sub


    Public Overrides Function GetEnabled(ByVal control _
      As Control) As Boolean

      Return CType(control, TableProviderWebPart).ConnectionPointEnabled

    End Function
  End Class


  ' This code sample creates a Web Parts control that acts as a consumer 
  ' of information provided by the TableProvider.ascx control.
  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class TableConsumer
    Inherits WebPart
    Private _provider As IWebPartTable
    Private _tableData As ICollection


    Private Sub GetTableData(ByVal tableData As ICollection)
      _tableData = CType(tableData, ICollection)

    End Sub


    Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
      If Not (_provider Is Nothing) Then
        _provider.GetTableData(New TableCallback(AddressOf GetTableData))
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
            Next o
            writer.WriteBreak()
            writer.WriteLine()
            count = count + 1
          Next prop
        Else
          writer.Write("No data")
        End If
      Else
        writer.Write("Not connected")
      End If

    End Sub


    <ConnectionConsumer("Table")> _
    Public Sub SetConnectionInterface(ByVal provider As IWebPartTable)
      _provider = provider

    End Sub

  End Class 'TableConsumer

  ' The connection point for the consumer control.
  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class TableConsumerConnectionPoint
    Inherits ConsumerConnectionPoint

    Public Sub New(ByVal callbackMethod As MethodInfo, _
      ByVal interfaceType As Type, ByVal controlType As Type, _
      ByVal name As String, ByVal id As String, _
      ByVal allowsMultipleConnections As Boolean)
      MyBase.New(callbackMethod, interfaceType, controlType, name, _
        id, allowsMultipleConnections)

    End Sub
  End Class 'TableConsumerConnectionPoint

End Namespace  ' Samples.AspNet.CS.Controls
'</SNIPPET2>