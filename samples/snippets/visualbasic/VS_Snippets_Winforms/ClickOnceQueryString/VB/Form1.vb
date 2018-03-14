Imports System.Deployment.Application
Imports System.Web
Imports System.Collections.Specialized

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    '<SNIPPET1>
    Private Function GetQueryStringParameters() As NameValueCollection
        Dim NameValueTable As New NameValueCollection()

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim QueryString As String = ApplicationDeployment.CurrentDeployment.ActivationUri.Query
            NameValueTable = HttpUtility.ParseQueryString(QueryString)
        End If

        GetQueryStringParameters = NameValueTable
    End Function
    '</SNIPPET1>
End Class
