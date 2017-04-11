Option Explicit
Option Strict

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.Caching



Public Class Page1
    Inherits Page
    
    Private Sub Page_Load(sender As Object, e As EventArgs)
        Dim connectionString As String = ""
        ' <Snippet1>
        Cache.Insert("DSN", connectionString, New CacheDependency(Server.MapPath("myconfig.xml")))
        ' </Snippet1>
    End Sub 'Page_Load 
End Class 'Page1 
