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

  ' This sample code creates a Web Parts control that acts as a 
  ' provider of field data.
  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public NotInheritable Class FieldProviderWebPart
    Inherits WebPart
    Implements IWebPartField
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


    <ConnectionProvider("FieldProvider")> _
    Public Function GetConnectionInterface() As IWebPartField
      Return New FieldProviderWebPart()

    End Function


    Public ReadOnly Property Schema() As ComponentModel.PropertyDescriptor _
      Implements IWebPartField.Schema
      Get
        ' The two parameters are row and field. Zero is the first record. 
        ' 0,2 returns the zip code field value.   
        Return TypeDescriptor.GetProperties(_table.DefaultView(0))(2)
      End Get
    End Property


    '<SNIPPET3>
    Sub GetFieldValue(ByVal callback As FieldCallback) _
      Implements IWebPartField.GetFieldValue

      callback(Schema.GetValue(_table.DefaultView(0)))

    End Sub
    '</SNIPPET3>

  End Class 'FieldProviderWebPart 


  ' This sample code creates a Web Parts control that acts as a 
  ' consumer of an IWebPartField interface.
  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class FieldConsumerWebPart
    Inherits WebPart

    Private _provider As IWebPartField
    Private _fieldValue As Object


    Private Sub GetFieldValue(ByVal fieldValue As Object)
      _fieldValue = fieldValue

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


    '<SNIPPET4>
    Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
      If Not (_provider Is Nothing) Then
        _provider.GetFieldValue(New FieldCallback(AddressOf GetFieldValue))
      End If
      MyBase.OnPreRender(e)

    End Sub


    Protected Overrides Sub RenderContents(ByVal writer As _
      HtmlTextWriter)

      If Not (_provider Is Nothing) Then
        Dim prop As PropertyDescriptor = _provider.Schema

        If Not (prop Is Nothing) AndAlso Not (_fieldValue Is Nothing) Then
          writer.Write(prop.DisplayName & ": " & _fieldValue)
        Else
          writer.Write("No data")
        End If
      Else
        writer.Write("Not connected")
      End If

    End Sub
    '</SNIPPET4>

    <ConnectionConsumer("FieldConsumer", "Connpoint1", _
      GetType(FieldConsumerConnectionPoint), AllowsMultipleConnections:=True)> _
    Public Sub SetConnectionInterface(ByVal provider As IWebPartField)
      _provider = provider

    End Sub

  End Class 'FieldConsumerWebPart

  Public Class FieldConsumerConnectionPoint
    Inherits ConsumerConnectionPoint

    Public Sub New(ByVal callbackMethod As MethodInfo, _
      ByVal interfaceType As Type, ByVal controlType As Type, _
      ByVal name As String, ByVal id As String, _
      ByVal allowsMultipleConnections As Boolean)
      MyBase.New(callbackMethod, interfaceType, controlType, _
        name, id, allowsMultipleConnections)

    End Sub


    Public Overrides Function GetEnabled(ByVal control As Control) _
      As Boolean

      Return CType(control, FieldConsumerWebPart).ConnectionPointEnabled

    End Function

  End Class 'FieldConsumerConnectionPoint

End Namespace  ' Samples.AspNet.VB.Controls
'</SNIPPET2>