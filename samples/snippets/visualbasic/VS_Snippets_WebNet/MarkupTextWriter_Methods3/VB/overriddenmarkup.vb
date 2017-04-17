Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB

    ' Create a custom MarkupTextWriter class that 
    ' overrides the OnTagRender, OnAttributeRender, and
    ' OnStyleAttributeRender methods.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class SimpleHtmlTextWriter
        Inherits HtmlTextWriter
' <snippet1>
         ' Create a markup class constructor that uses the
         ' DefaultTabString property to establish indent settings
         ' for the writer.
         Public Sub New(writer As TextWriter)
             me.New(writer, DefaultTabString)
         End Sub
' </snippet1>

' <snippet3>
        ' Create a constructor that calls the base class's constructor.
        Public Sub New(writer As TextWriter, tabString As String)
            MyBase.New(writer, tabString)
        End Sub
' </snippet3>


' <snippet4>
        ' If a <font> element is to be rendered, check whether it contains
        ' a size attribute. If it does not, add one and set its value to
        ' 20 points, then return true.
        Protected Overrides Function OnTagRender( _
            name As String, _
            key As HtmlTextWriterTag) _
        As Boolean

            If (key = HtmlTextWriterTag.Font) Then
                If Not (IsAttributeDefined(HtmlTextWriterAttribute.Size)) Then
                    AddAttribute(HtmlTextWriterAttribute.Size, "20pt")
                    Return True
                End If
            End If

            ' If the element is not a <font> element, use
            ' the base functionality of the OnTagRenderMethod.
            Return MyBase.OnTagRender(name, key)
        End Function
' </snippet4>

' <snippet5>
        ' If a size attribute is to be rendered, compare its value to 30 point.
        ' If it is not set to 30 point, add the attribute and set the value to 30
        ' then return false.
        Protected Overrides Function OnAttributeRender(name As String, _
            value As String, _
            key As HtmlTextWriterAttribute) _
        As Boolean

            If key = HtmlTextWriterAttribute.Size Then
                If [String].Compare(value, "30pt") <> 0 Then
                    AddAttribute("size", "30pt")
                    Return False
                End If
            End If

            ' If the attribute is not a size attribute, use
            ' the base functionality of the OnAttributeRender method.
            Return MyBase.OnAttributeRender(name, value, key)
        End Function 'OnAttributeRender
' </snippet5>

' <snippet6>
        ' If a color style attribute is to be rendered,
        ' compare its value to purple. If it is not set to
        ' purple, add the style attribute and set the value
        ' to purple, then return false.
        Protected Overrides Function OnStyleAttributeRender(name As String, _
            value As String, _
            key As HtmlTextWriterStyle) _
        As Boolean

            If key = HtmlTextWriterStyle.Color Then
                If [String].Compare(value, "purple") <> 0 Then
                    AddStyleAttribute("color", "purple")
                    Return False
                End If
            End If

            ' If the style attribute is not a color attribute,
            ' use the base functionality of the
            ' OnStyleAttributeRender method.
            Return MyBase.OnStyleAttributeRender(name, value, key)
        End Function 'OnStyleAttributeRender
' </snippet6>
    End Class

End Namespace


