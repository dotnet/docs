Option Explicit
Option Strict

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.Caching



Public Class Page1
    Inherits Page
    
    Private Sub Page_Load(sender As Object, e As EventArgs)
        Dim Source As String = ""
        
        ' <Snippet1>
	Dim dep As New CacheDependency(Server.MapPath("isbn.xml"))
        Cache.Insert("ISBNData", Source, dep)
        ' </Snippet1>
    End Sub 'Page_Load 
End Class 'Page1 
