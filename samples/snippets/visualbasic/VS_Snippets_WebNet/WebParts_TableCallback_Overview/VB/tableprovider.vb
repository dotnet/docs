'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Reflection
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

'This sample code creates a Web Parts control that acts as a provider of table data.
Namespace Samples.AspNet.VB.Controls

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

        End Sub 'New

        <ConnectionProvider("Table")> _
        Public Function GetConnectionInterface() As IWebPartTable
            Return New TableProviderWebPart()

        End Function 'GetConnectionInterface

        Public ReadOnly Property Schema() As PropertyDescriptorCollection _
            Implements IWebPartTable.Schema
            Get
                Return TypeDescriptor.GetProperties(_table.DefaultView(0))
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

        Public Sub GetTableData(ByVal callback As TableCallback) _
            Implements IWebPartTable.GetTableData
            callback(_table.Rows)

        End Sub 'GetTableData
    End Class 'TableProviderWebPart           

End Namespace
'</Snippet1>
