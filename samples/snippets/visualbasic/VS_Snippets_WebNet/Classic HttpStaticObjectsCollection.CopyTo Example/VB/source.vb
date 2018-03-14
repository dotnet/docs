Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
' Find the number of members in the StaticObjects collection.
Dim ObjCount As Integer = Application.StaticObjects.Count
' Create an array of the same size.
Dim MyObjArray(ObjCount) As Object
' Copy the entire collection into the array.
Application.StaticObjects.CopyTo(MyObjArray, 0)

' </Snippet1>
 End Sub
End Class
