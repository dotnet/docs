'<Snippet1>
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace Samples.AspNet.VB
    Public Class SortingData
        Public Sub New()

        End Sub

        Private Shared table As DataTable

        Private Function CreateData() As DataTable
            table = New DataTable()
            table.Columns.Add("Name", GetType(String))
            table.Columns.Add("Number", GetType(Integer))
            table.Rows.Add(New Object() {"one", 1})
            table.Rows.Add(New Object() {"two", 2})
            table.Rows.Add(New Object() {"three", 3})
            table.Rows.Add(New Object() {"four", 4})
            Return table
        End Function

        Public Function SelectMethod(ByVal sortExpression As String) As DataView
            If table Is Nothing Then
                table = CreateData()
            End If

            Dim dv As New DataView(table)
            dv.Sort = sortExpression
            Return dv
        End Function


    End Class
End Namespace
'</Snippet1>