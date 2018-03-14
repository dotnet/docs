Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim ClsidStr As String
Dim MyObject As Object
 
ClsidStr = "42754580-16b7-11ce-80eb-00aa003d7352"
MyObject = Server.CreateObject(ClsidStr)
   
' </Snippet1>
 End Sub
End Class
