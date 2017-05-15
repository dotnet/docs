Imports System
Imports System.Globalization
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class WriteContent
       Inherits WebControl

        Public Overrides Sub RenderControl( _
           ByVal writer As HtmlTextWriter _
           )

            writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "Blue")
            writer.RenderBeginTag(HtmlTextWriterTag.Font)

            ' <snippet5>
            ' Use the Write(string, object) method to
            ' render a formatted string and an object in it.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.Write("The current cultural settings are {0}.", _
                CultureInfo.CurrentCulture)
            writer.RenderEndTag()
            ' </snippet5>

            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()

            ' <snippet6>
            ' Use the Write(string,object,object) method to
            ' render a formatted string and two objects 
            ' in the string.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.Write("The current cultural settings are {0}. Today's date is {1}.", _
                CultureInfo.CurrentCulture, DateTime.Today)
            writer.RenderEndTag()
            ' </snippet6>

            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()

            ' <snippet7>
            ' Use the WriteLine(Double) method to render
            ' the MaxValue field of the Double structure. 
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.WriteLine(Double.MaxValue)
            writer.RenderEndTag()
            ' </snippet7>

            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()

            ' <snippet8>
            ' Use the Write method to render an arbitrary
            ' object, in this case a CultureInfo object.
            writer.Write("This is a rendered CultureInfo Object.")
            writer.RenderBeginTag(HtmlTextWriterTag.B)
            writer.Write(CultureInfo.CurrentCulture)
            writer.RenderEndTag()
            ' </snippet8>

            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()

            ' <snippet10>
            ' Use the Write(Single) method to render the
            ' Epsilon field of the Single structure. 
            writer.RenderBeginTag(HtmlTextWriterTag.B)
            writer.Write(Single.Epsilon)
            writer.RenderEndTag()
            ' </snippet10>
            writer.RenderEndTag()
            writer.WriteLine()

        End Sub
    End Class
End Namespace
