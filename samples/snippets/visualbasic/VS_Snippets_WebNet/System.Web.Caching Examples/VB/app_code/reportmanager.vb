' <Snippet10>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Caching

Public Class ReportManager
    Private Shared _lastRemoved As String = ""

    Public Shared Function GetReport() As String
        Dim report As String = CStr(HttpRuntime.Cache("MyReport"))
        If report Is Nothing Then
            report = GenerateAndCacheReport()
        End If
        Return report
    End Function

    Private Shared Function GenerateAndCacheReport() As String
        Dim report As String = "Report Text. " & _lastRemoved

        HttpRuntime.Cache.Insert( _
            "MyReport", _
            report, _
            Nothing, _
            Cache.NoAbsoluteExpiration, _
            New TimeSpan(0, 0, 15), _
            CacheItemPriority.Default, _
            New CacheItemRemovedCallback(AddressOf ReportRemovedCallback))

        Return report
    End Function

    Public Shared Sub ReportRemovedCallback(ByVal key As String, _
            ByVal value As Object, ByVal removedReason _
            As CacheItemRemovedReason)
        _lastRemoved = "Re-created " & DateTime.Now.ToString()
    End Sub
End Class
' </Snippet10>
