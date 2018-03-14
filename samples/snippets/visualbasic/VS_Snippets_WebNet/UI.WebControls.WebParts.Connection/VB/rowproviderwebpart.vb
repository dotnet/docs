 '<SNIPPET1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Reflection
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

'This sample code creates a Web Parts control that acts as a provider of row data.
Namespace MyCustomWebPart

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

        '<SNIPPET6>
        <ConnectionProvider("Row")> _
        Public Function GetConnectionInterface() As IWebPartRow
            Return New RowProviderWebPart()

        End Function 'GetConnectionInterface
        '</SNIPPET6>
        '<SNIPPET4>

        Public ReadOnly Property Schema() As PropertyDescriptorCollection _
            Implements IWebPartRow.Schema
            Get
                Return TypeDescriptor.GetProperties(_table.DefaultView(0))
            End Get
        End Property

        '</SNIPPET4>
        '<SNIPPET7>
        Public Sub GetRowData(ByVal callback As RowCallback) _
            Implements IWebPartRow.GetRowData
            callback(_table.Rows)

        End Sub 'GetRowData
    End Class 'RowProviderWebPart 
    '</SNIPPET7>            
    '</SNIPPET1>

End Namespace
