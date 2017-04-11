Imports System
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Reflection

Namespace Samples.AspNet.VB

    ' <summary>
    ' This example demonstrates the following overloads
    ' of the HtmlTextWriter.Write method:
    ' Write(String, Object), Write(String, Object[]),
    ' Write(String, Object, Object), and Write(Char[], Int32, Int32).
    ' </summary>
    <AspNetHostingPermission(SecurityAction.Demand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class RenderObjectsWrite
        Inherits Control

        ' <snippet13>
        Private testChars() As Char = _
            {"h"c, "e"c, "l"c, "l"c, "o"c, _
            HtmlTextWriter.SpaceChar, "w"c, "o"c, "r"c, "l"c, "d"c}
        ' </snippet13>
        Private numOrdered As Integer = 80
        ' <snippet14>
        Private curPriceTime() As Object = {4.25, DateTime.Now}
        ' </snippet14>

        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)

            ' <snippet8>
            ' Render a formatted string and the
            ' text representation of a variable, int0,
            ' as the contents of a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.Write("Thanks for buying {0} widgets.", numOrdered)
            writer.RenderEndTag()
            ' </snippet8>
            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()
            ' <snippet9>
            ' Render a formatted string and the
            ' text representation of an object array,
            ' myObjectArray, as the contents of
            ' a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.Write("The trade value at {1} is ${0}.", curPriceTime)
            writer.RenderEndTag()
            ' </snippet9>
            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag() ' Br
            ' <snippet10>
            ' Render a formatted string and the
            ' text representation of two variables,
            ' int0 and int1, as the contents of
            ' a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.Write("The winning numbers are {0} and {1}.", 47, 825)
            writer.RenderEndTag()
            ' </snippet10>
            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()

            ' <snippet11>
            ' Render a subarray of a character array
            ' as the contents of a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.Write(testChars, 0, 5)
            writer.RenderEndTag()
            ' </snippet11>
            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()
            ' <snippet12>
            ' Render a character array as the 
            ' contents of a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.Write(testChars)
            writer.RenderEndTag()
            ' </snippet12>
        End Sub 'Render
    End Class 'RenderObjectsWrite
End Namespace
