' The following example demonstrates the 'AddStyleAttribute(string, string)' method 
' * of 'HtmlTextWriter' class.
' * 
' * In this program a custom web control called 'FirstControl' is shown. It has 
' * one property called the 'Message'. The 'Render' method has been overriden to
' * write the html contents with reference to this control. This contents are 
' * written to the final .aspx page in which this control is inserted. The 'Render'
' * method displays the contents of the 'Message' property followed by the current
' * time on the server were the corresponding .aspx page resides. 
' * 
' * Note : Follow the instructions in HtmlTextWriterReadme.txt for details on installing
' *        a site that uses custom controls.  

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace CustomControls

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class FirstControl
        Inherits WebControl
        'The message property.
        Private myMessage As String = "Hello"

        'Accessors for the message property.

        Public Overridable Property Message() As [String]
            Get
                Return myMessage
            End Get
            Set(ByVal Value As String)
                myMessage = Value
            End Set
        End Property


        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            ' <Snippet1>
            'Add style attribute for 'p'(paragraph) element.
            writer.AddStyleAttribute("font-size", "12pt")
            writer.AddStyleAttribute("color", "fuchsia")

            'Output the 'p' (paragraph) element with the style attributes.
            writer.RenderBeginTag("p")

            'Output the 'Message' property contents and the time on the server.
            writer.Write((Message & "<br>" & "The time on the server: " & _
               System.DateTime.Now.ToLongTimeString()))

            ' Close the element.
            writer.RenderEndTag()
            ' </Snippet1>
        End Sub 'Render
    End Class 'FirstControl

End Namespace 'CustomControls 