Imports System
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Reflection

Namespace Samples.AspNet.VB

    ' <summary>
    ' This example demonstrates the following overloads of
    ' the HtmlTextWriter.WriteLine method: WriteLine(String, Object),
    ' WriteLine(String, Object[]), WriteLine(String, Object, Object),
    ' and WriteLine(Char[], Int32, Int32).
    ' </summary>
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class RenderObjectsWriteLine
        Inherits Control

' <snippet6>
        Private testChars() As Char = _
            {"h"c, "e"c, "l"c, "l"c, "o"c, _
            HtmlTextWriter.SpaceChar, "w"c, "o"c, "r"c, "l"c, "d"c}
' </snippet6>
        Private numOrdered As Integer = 80
' <snippet7>
        Private curPriceTime() As Object = {4.25, DateTime.Now}
' </snippet7>
        protected Overrides Sub Render(writer As HtmlTextWriter)

' <snippet1>
            ' Render a formatted string and the
            ' text representation of a variable, int0,
            ' as the contents of a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.WriteLine("Thanks for buying {0} widgets.", numOrdered)
            writer.RenderEndTag()
' </snippet1>
            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()

' <snippet2>
            ' Render a formatted string and the
            ' text representation of an object array,
            ' myObjectArray, as the contents of
            ' a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.WriteLine("The trade value at {1} is ${0}.", curPriceTime)
            writer.RenderEndTag()
' </snippet2>

            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()
' <snippet3>
            ' Render a formatted string and the
            ' text representation of two variables,
            ' int0 and int1, as the contents of
            ' a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.WriteLine("The winning numbers are {0} and {1}.", 47, 825)
            writer.RenderEndTag()
' </snippet3>

            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()
' <snippet4>
            ' Render a subarray of a character array
            ' as the contents of a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.WriteLine(testChars, 0, 5)
            writer.RenderEndTag()
' </snippet4>
            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()
' <snippet5>
            ' Render a character array as the 
            ' contents of a <label> element.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.WriteLine(testChars)
            writer.RenderEndTag()
' </snippet5>
        End Sub 
    End Class 
End Namespace
