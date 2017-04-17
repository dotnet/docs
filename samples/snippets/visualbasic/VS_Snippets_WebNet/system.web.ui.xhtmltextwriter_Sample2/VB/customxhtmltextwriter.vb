' CustomXhtmlTextWriter.vb
'
' <snippet1>
Imports System
Imports System.IO
Imports System.Web
Imports System.Security.Permissions
Imports System.Web.UI
Imports System.Web.UI.Adapters
Imports System.Web.UI.WebControls.Adapters

Namespace Samples.AspNet.VB

' <snippet5>
    ' Create a class that inherits from XhtmlTextWriter.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class CustomXhtmlTextWriter
        Inherits XhtmlTextWriter

        ' Create two constructors, following 
        ' the pattern for implementing a
        ' TextWriter constructor.
        Public Sub New(writer As TextWriter)
          MyClass.New(writer, DefaultTabString)
        End Sub 'New


        Public Sub New(writer As TextWriter, tabString As String)
          MyBase.New(writer, tabString)
        End Sub 'New
' </snippet5>


' <snippet2>        
        ' Override the OnAttributeRender method to 
        ' allow this text writer to render only eight-point 
        ' text size.
        Overrides Protected Function OnAttributeRender(ByVal name As String, _
          ByVal value As String, _
          ByVal key As HtmlTextWriterAttribute _
        ) As Boolean
           If key = HtmlTextWriterAttribute.Size Then
              If String.Compare(value, "8pt") = 0 Then
                 Return True
              Else
                 Return False
              End If 
           Else
              Return MyBase.OnAttributeRender(name, value, key)
           End If
        End Function
 ' </snippet2>       
        
' <snippet3>        
        ' Override the OnStyleAttributeRender
        ' method to prevent this text writer 
        ' from rendering purple text.
        Overrides Protected Function OnStyleAttributeRender(ByVal name As String, _
          ByVal value As String, _
          ByVal key As HtmlTextWriterStyle _
        ) As Boolean
           If key = HtmlTextWriterStyle.Color Then
              If String.Compare(value, "purple") = 0 Then
                 Return False
              Else
                 Return True
              End If
           Else
              Return MyBase.OnStyleAttributeRender(name, value, key)        
           End If
        End Function  
' </snippet3>

' <snippet4>        
        ' Override the BeginRender method to write a
        ' message and call the WriteBreak method
        ' before a control is rendered.
        Overrides Public Sub BeginRender()
           Me.Write("A control is about to render.")
           Me.WriteBreak()
        End Sub
        
        ' Override the EndRender method to
        ' write a string immediately after 
        ' a control has rendered. 
        Overrides Public Sub EndRender()
           Me.Write("A control just rendered.")
        End Sub  
' </snippet4>
         
    End Class
End Namespace
' </snippet1>
