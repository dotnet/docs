Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.Caching



Public Class Page1
    Inherits Page
    Private onRemove As CacheItemRemovedCallback
    
    
    Private Sub Page_Load(sender As Object, e As EventArgs)
        Dim connectionString As String = ""
        ' <Snippet1>
        Cache.Insert("DSN", connectionString, Nothing, DateTime.Now.AddMinutes(2), TimeSpan.Zero, CacheItemPriority.High, onRemove)
        ' </Snippet1>
    End Sub 'Page_Load 
End Class 'Page1 
