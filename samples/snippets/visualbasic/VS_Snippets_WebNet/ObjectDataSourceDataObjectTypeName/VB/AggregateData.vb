' <snippet2>
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

    Public Class AggregateData

        Public Sub New()
        End Sub

        Shared table As DataTable

        Private Function CreateData() As DataTable
            table = New DataTable()
            table.Columns.Add("Name", GetType(String))
            table.Columns.Add("Number", GetType(Integer))
            table.Rows.Add(New Object() {"one", 1})
            table.Rows.Add(New Object() {"two", 2})
            table.Rows.Add(New Object() {"three", 3})
            Return table
        End Function

        Public Function SelectMethod() As DataTable
            If table Is Nothing Then
                Return CreateData()
            Else
                Return table
            End If
        End Function


        Public Function Insert(ByVal newRecord As NewData) As Integer

            table.Rows.Add(New Object() {newRecord.Name, newRecord.Number})
            Return 1
        End Function
    End Class


    Public Class NewData

        Private nameValue As String
        Private numberValue As Integer

        Public Property Name() As String
            Get
                Return nameValue
            End Get
            Set(ByVal value As String)
                nameValue = value
            End Set
        End Property

        Public Property Number() As Integer
            Get
                Return numberValue
            End Get
            Set(ByVal value As Integer)
                numberValue = value
            End Set
        End Property
    End Class
End Namespace
' </snippet2>
