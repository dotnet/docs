' <snippet1>
Imports System
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Collections
Imports System.Security
Imports System.Security.Permissions

Namespace MyControls

    ' MyDataBound control is a simple read-only grid control.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class MyDataBound
        Inherits System.Web.UI.WebControls.DataBoundControl

        ' This is an enumerator for the data source.
        Private dataSourceEnumerator As IEnumerator = Nothing

        ' Render the data source as a table, without row and column headers.
        Protected Overrides Sub RenderContents( _
            ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Render the <table> tag.
            writer.RenderBeginTag(HtmlTextWriterTag.Table)

            ' Render the table rows.
            While dataSourceEnumerator.MoveNext()

                ' Get the next data row as an object array.
                Dim dataArray As Object() = CType( _
                    dataSourceEnumerator.Current, DataRowView).Row.ItemArray

                ' Render the <tr> tag.
                writer.RenderBeginTag(HtmlTextWriterTag.Tr)

                ' Render the fields of the row.
                Dim col As Integer
                For col = 0 To (dataArray.GetLength(0)) - 1

                    'Render the <td> tag, the field data and the </td> tag.
                    writer.RenderBeginTag(HtmlTextWriterTag.Td)
                    writer.Write(dataArray(col))
                    writer.RenderEndTag()
                Next col

                ' Render the </tr> tag.
                writer.RenderEndTag()
            End While

            ' Render the </table> tag.
            writer.RenderEndTag()
        End Sub 'RenderContents

        ' Data binding consists of saving an enumerator for the data.
        Protected Overrides Sub PerformDataBinding(ByVal data As IEnumerable)

            dataSourceEnumerator = data.GetEnumerator()
        End Sub 'PerformDataBinding
    End Class 'MyDataBound

    ' MyDataBoundAdapter modifies a MyDataBound control to display a
    ' grid as a list with row separators.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class MyDataBoundAdapter
        Inherits System.Web.UI.WebControls.Adapters.DataBoundControlAdapter

        ' <snippet2>
        ' Returns a strongly-typed reference to the MyDataBound control.
        Public Shadows ReadOnly Property Control() As MyDataBound
            Get
                Return CType(MyBase.Control, MyDataBound)
            End Get
        End Property
        ' </snippet2>

        ' <snippet3>
        ' One-dimensional list for the grid data.
        Private dataArray As New ArrayList()

        ' Copy grid data to one-dimensional list, add row separators.
        Protected Overrides Sub PerformDataBinding(ByVal data As IEnumerable)

            Dim dataSourceEnumerator As IEnumerator = data.GetEnumerator()

            ' Iterate through the table rows.
            While dataSourceEnumerator.MoveNext()

                ' Add the next data row to the ArrayList.
                dataArray.AddRange(CType(dataSourceEnumerator.Current, _
                                        DataRowView).Row.ItemArray)

                ' Add a separator to the ArrayList.
                dataArray.Add("----------")
            End While
        End Sub 'PerformDataBinding

        ' Render the data source as a one-dimensional list.
        Protected Overrides Sub RenderContents( _
            ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Render the data list.
            Dim col As Integer
            For col = 0 To dataArray.Count - 1
                writer.Write(dataArray(col))
                writer.WriteBreak()
            Next col
        End Sub 'RenderContents
        ' </snippet3>
    End Class 'MyDataBoundAdapter 
End Namespace ' MyControls
' </snippet1>