' <Snippet2>
Imports System
Imports System.Collections
Imports System.Data.Common
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB

    Public Class SimpleSpreadsheetControl
        Inherits CompositeDataBoundControl

        Protected table As New Table()

        Public Overridable ReadOnly Property Rows() As TableRowCollection
            Get
                Return table.Rows
            End Get
        End Property


        Protected Overrides Function CreateChildControls(ByVal dataSource As IEnumerable, ByVal dataBinding As Boolean) As Integer

            Dim count As Integer = 0
            ' If dataSource is not Nothing, iterate through it and
            ' extract each element from it as a row, then
            ' create a SimpleSpreadsheetRow and add it to the
            ' rows collection.
            If Not (dataSource Is Nothing) Then

                Dim row As SimpleSpreadsheetRow
                Dim e As IEnumerator = dataSource.GetEnumerator()

                While e.MoveNext()
                    Dim datarow As Object = e.Current
                    row = New SimpleSpreadsheetRow(count, datarow)
                    Me.Rows.Add(row)
                    count += 1
                End While

                Controls.Add(table)
            End If
            Return count
        End Function 'CreateChildControls
    End Class 'SimpleSpreadsheetControl


    Public Class SimpleSpreadsheetRow
        Inherits TableRow
        Implements IDataItemContainer

        Private dataObj As Object
        Private _itemIndex As Integer

        Public Sub New(ByVal itemIndex As Integer, ByVal o As Object)
            dataObj = o
            _itemIndex = itemIndex
        End Sub 'New

        Public Overridable ReadOnly Property Data() As Object
            Get
                Return dataObj
            End Get
        End Property

        ' <Snippet3>
        ReadOnly Property DataItem() As Object Implements IDataItemContainer.DataItem
            Get
                Return Data
            End Get
        End Property
        ' </Snippet3>

        ' <Snippet4>
        ReadOnly Property DataItemIndex() As Integer Implements IDataItemContainer.DataItemIndex
            Get
                Return _itemIndex
            End Get
        End Property
        ' </Snippet4>

        ' <Snippet5>
        ReadOnly Property DisplayIndex() As Integer Implements IDataItemContainer.DisplayIndex
            Get
                Return _itemIndex
            End Get
        End Property
        ' </Snippet5>
        Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)

            If Not (Data Is Nothing) Then
                If TypeOf Data Is System.Data.Common.DbDataRecord Then
                    Dim temp As DbDataRecord = CType(Data, DbDataRecord)
                    Dim i As Integer

                    While i < temp.FieldCount
                        writer.Write("<TD>")
                        writer.Write(temp.GetValue(i).ToString())
                        writer.Write("</TD>")
                        i += 1
                    End While
                Else
                    writer.Write(("<TD>" + Data.ToString() + "</TD>"))
                End If

            Else
                writer.Write("<TD>This is a test</TD>")
            End If
        End Sub 'RenderContents
    End Class 'SimpleSpreadsheetRow
End Namespace
' </Snippet2>