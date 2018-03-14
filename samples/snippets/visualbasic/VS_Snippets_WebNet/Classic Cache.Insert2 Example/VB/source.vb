Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.Caching

Public Class Page1
    Inherits Page
    
    Private Sub Page_Load(sender As Object, e As EventArgs)
        Dim connectionString As String = ""
        ' <Snippet1>
        Cache.Insert("DSN", connectionString, Nothing, DateTime.Now.AddMinutes(2), Cache.NoSlidingExpiration)
        ' </Snippet1>
        ' <Snippet2>
        Cache.Insert("DSN", connectionString, Nothing, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(10))
        ' </Snippet2>
    End Sub 'Page_Load 
End Class 'Page1
