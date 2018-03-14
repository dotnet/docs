Imports System
Imports System.Globalization
Imports System.Web
Imports System.Security.Permissions
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class WriteLineContent
       Inherits WebControl
       
             
        Public Overrides Sub RenderControl( _
        ByVal writer As HtmlTextWriter _
           )

            writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "Blue")
            writer.RenderBeginTag(HtmlTextWriterTag.Font)
            ' <snippet1>
            ' Use the WriteLine(string, object) method to
            ' render a formatted string and an object in it.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.WriteLine("The current cultural settings are {0}.", _
                CultureInfo.CurrentCulture)
            writer.RenderEndTag()
            ' </snippet1>


            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()

            ' <snippet2>
            ' Use the WriteLine(string,object,object) method to
            ' render a formatted string and two objects 
            ' in the string.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.WriteLine("The current cultural settings are {0}. Today's date is {1}.", _
                CultureInfo.CurrentCulture, DateTime.Today)
            writer.RenderEndTag()
            ' </snippet2>

            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()

            ' <snippet3>
            ' Use the WriteLine(Double) method to render
            ' the MaxValue field of the Double structure. 
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.WriteLine(Double.MaxValue)
            writer.RenderEndTag()
            ' </snippet3>

            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()

            ' <snippet4>
            ' Use the WriteLine method to render an arbitrary
            ' object, in this case a CutltureInfo object.
            writer.RenderBeginTag(HtmlTextWriterTag.B)
            writer.WriteLine(CultureInfo.CurrentCulture)
            writer.RenderEndTag()
            ' </snippet4>

            writer.RenderBeginTag(HtmlTextWriterTag.Br)
            writer.RenderEndTag()

            ' <snippet9>
            ' Use the WriteLine(Single) method to render the
            ' Epsilon field of the Single structure. 
            writer.RenderBeginTag(HtmlTextWriterTag.B)
            writer.WriteLine(Single.Epsilon)
            writer.RenderEndTag()
            ' </snippet9>


            writer.RenderEndTag()
            writer.WriteLine()

        End Sub
    End Class
End Namespace