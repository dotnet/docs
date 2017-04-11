imports Microsoft.VisualBasic
imports System
imports System.Windows.Forms
imports System.Web
imports System.Data
imports System.Diagnostics


Public Class Form1: Inherits Form

 Protected DS As DataSet

 Protected Sub Method( Context As TraceContext )
' <Snippet1>
If (Context.IsEnabled)
 
   Dim I As Integer
   For I = 0 To DS.Tables("Categories").Rows.Count - 1
 
     Trace.Write("ProductCategory",DS.Tables("Categories").Rows(I)(0).ToString())
   Next
 End If
   
' </Snippet1>
 End Sub
End Class
