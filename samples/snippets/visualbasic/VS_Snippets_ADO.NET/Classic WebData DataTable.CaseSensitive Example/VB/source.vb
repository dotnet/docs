imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>

Private Sub ToggleCaseSensitive()
    Dim t As DataTable
    Dim foundRows() As DataRow

    t = CreateDataSet().Tables(0)

    t.CaseSensitive = False
    foundRows = t.Select("item = 'abc'")

    ' Print out DataRow values. Row 0 contains the value we're looking for.
    PrintRowValues(foundRows, "CaseSensitive = False")

    t.CaseSensitive = True
    foundRows = t.Select("item = 'abc'")

    PrintRowValues(foundRows, "CaseSensitive = True")
End Sub

Public Function CreateDataSet() As DataSet
    ' Create a DataSet with one table, two columns
    Dim ds As New DataSet
    Dim t As New DataTable("Items")

    ' Add table to DataSet
    ds.Tables.Add(t)

    ' Add two columns
    Dim c As DataColumn

    ' First column
    c = t.Columns.Add("id", Type.GetType("System.Int32"))
    c.AutoIncrement = True

    ' Second column
    t.Columns.Add("item", Type.GetType("System.String"))

    ' Set primary key
    t.PrimaryKey = New DataColumn() {t.Columns("id")}

    For i As Integer = 0 To 9
        t.Rows.Add(New Object() {i, i.ToString()})
    Next
    t.Rows.Add(New Object() {11, "abc"})
    t.Rows.Add(New Object() {15, "ABC"})

    CreateDataSet = ds
End Function

Private Sub PrintRowValues(ByRef rows As DataRow(), ByVal label As String)
    Console.WriteLine()
    Console.WriteLine(label)
    If rows.Length <= 0 Then
        Console.WriteLine("no rows found")
        Return
    End If

    For Each r As DataRow In rows
        For Each c As DataColumn In r.Table.Columns
            Console.Write(vbTab & " {0}", r(c))
        Next
        Console.WriteLine()
    Next
End Sub

 ' </Snippet1>

End Class
