Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Reflection
Imports System.Security.Permissions
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
' <Snippet2>
Namespace Samples.AspNet.VB.Controls

    '<Snippet5>
    ' An interface that the transformer provides to the consumer.
    <AspNetHostingPermission(SecurityAction.Demand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Interface IString
        Sub GetStringValue(ByVal callback As StringCallback)
    End Interface
    '</Snippet5>

    ' A callback method to retrieve the string value.
    Public Delegate Sub StringCallback(ByVal stringValue As String)

    ' A provider WebPart control that provides a row of data.
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
            col.ColumnName = "Zip Code"
            _table.Columns.Add(col)

            Dim row As DataRow = _table.NewRow()
            row("Name") = "John Q. Public"
            row("Address") = "123 Main Street"
            row("Zip Code") = 98000
            _table.Rows.Add(row)
        End Sub

        Private ReadOnly Property RowData() As Object
            Get
                Return _table.DefaultView(0)
            End Get
        End Property

        Public Property ConnectionPointEnabled() As Boolean
            Get
                Dim o As Object
                o = ViewState("ConnectionPointEnabled")
                If Not (o Is Nothing) Then
                    Return CBool(o)
                Else
                    Return True
                End If

            End Get
            Set(ByVal value As Boolean)
                ViewState("ConnectionPointEnabled") = value
            End Set
        End Property

        Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
            Dim props As PropertyDescriptorCollection = Me.Schema

            For Each prop As PropertyDescriptor In props
                writer.Write(prop.DisplayName + ": " + _
                   prop.GetValue(RowData).ToString())
                writer.WriteBreak()
                writer.WriteLine()
            Next
        End Sub

        <ConnectionProvider("Row", GetType(RowProviderConnectionPoint))> _
        Public Function GetConnectionInterface() As IWebPartRow
            Return Me
        End Function

        Public Class RowProviderConnectionPoint
            Inherits ProviderConnectionPoint
            Public Sub New(ByVal callbackMethod As MethodInfo, _
               ByVal interfaceType As Type, ByVal controlType As Type, _
               ByVal name As String, ByVal id As String, _
               ByVal allowsMultipleConnections As Boolean)
                MyBase.New(callbackMethod, interfaceType, controlType, _
                    name, id, allowsMultipleConnections)
            End Sub

            Public Overrides Function GetEnabled(ByVal control As Control) As Boolean
                Return CType(control, RowProviderWebPart).ConnectionPointEnabled
            End Function
        End Class

        Public Sub GetRowData(ByVal callback As RowCallback) _
            Implements System.Web.UI.WebControls.WebParts.IWebPartRow.GetRowData
            callback(RowData)
        End Sub

        Public ReadOnly Property Schema() As PropertyDescriptorCollection _
            Implements System.Web.UI.WebControls.WebParts.IWebPartRow.Schema
            Get
                Return TypeDescriptor.GetProperties(RowData)
            End Get
        End Property
    End Class

    '<Snippet4>
    ' A transformer that transforms a row to a string.
    <AspNetHostingPermission(SecurityAction.Demand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    <WebPartTransformer(GetType(IWebPartRow), GetType(IString))> _
    Public Class RowToStringTransformer
        Inherits WebPartTransformer
        Implements IString

        Private _provider As IWebPartRow
        Private _callback As StringCallback

        Private Sub GetRowData(ByVal rowData As Object)
            Dim props As PropertyDescriptorCollection = _provider.Schema

            If ((Not (props Is Nothing)) AndAlso (props.Count > 0) _
              AndAlso (Not (rowData Is Nothing))) Then
                Dim returnValue As String = String.Empty
                For Each prop As PropertyDescriptor In props
                    If Not (prop Is props(0)) Then
                        returnValue += ", "
                    End If
                    returnValue += prop.DisplayName.ToString() + ": " + _
                        prop.GetValue(rowData).ToString()
                Next
                _callback(returnValue)
            Else
                _callback(Nothing)
            End If
        End Sub

        '<Snippet3>
        Public Overrides Function Transform(ByVal providerData As Object) As Object
            _provider = CType(providerData, IWebPartRow)
            Return Me
        End Function
        '</Snippet3>


        Sub GetStringValue(ByVal callback As StringCallback) _
           Implements IString.GetStringValue
            If (callback Is Nothing) Then
                Throw New ArgumentNullException("callback")
            End If

            If (Not (_provider Is Nothing)) Then
                _callback = callback
                _provider.GetRowData(New RowCallback(AddressOf GetRowData))
            Else
                callback(Nothing)
            End If
        End Sub
    End Class
    '</Snippet4>


    ' A consumer WebPart control that consumes strings.
    <AspNetHostingPermission(SecurityAction.Demand, _
      Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
      Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class StringConsumerWebPart
        Inherits WebPart

        Private _provider As IString
        Private _stringValue As String

        Private Sub GetStringValue(ByVal stringValue As String)
            _stringValue = stringValue
        End Sub

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            If Not (_provider Is Nothing) Then
                _provider.GetStringValue(New StringCallback(AddressOf GetStringValue))
            End If
        End Sub

        Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
            If Not (_provider Is Nothing) Then
                If (Not (_stringValue Is Nothing) _
                   AndAlso _stringValue.Length > 0) Then
                    writer.Write(_stringValue)
                Else
                    writer.Write("No data")
                End If
            Else
                writer.Write("Not connected")
            End If
        End Sub

        <ConnectionConsumer("String")> _
        Public Sub SetConnectionInterface(ByVal provider As IString)
            _provider = provider
        End Sub
    End Class
End Namespace
' </Snippet2>