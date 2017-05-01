Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class FirstControl
        Inherits WebControl
        ' The message property.
        Private myMessage As String = "Hello"

        ' Accessors for the message property.   
        Public Overridable Property Message() As [String]
            Get
                Return myMessage
            End Get

            Set(ByVal value As [String])
                myMessage = value
            End Set
        End Property


        ' <snippet1>
        ' Override a control's Render method to determine what it
        ' displays when included in a Web Forms page.
        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            ' <snippet2>
            ' Get the value of the current markup writer's 
            ' Encoding property, convert it to a string, and 
            ' write it to the HtmlTextWriter stream.
            writer.Write(("Encoding : " + writer.Encoding.ToString() & "<br>"))
            ' </snippet2>      
            ' <snippet3>
            ' Write the opening tag of a Font element.
            writer.WriteBeginTag("font")
            ' Write a Color style attribute to the opening tag
            ' of the Font element and set its value to red.
            writer.WriteAttribute("color", "red")
            ' Write the closing character for the opening tag of
            ' the Font element.
            writer.Write(">")

            ' Use the InnerWriter property to create a TextWriter
            ' object that will write the content found between
            ' the opening and closing tags of the Font element.
            ' Message is a string property of the control that 
            ' overrides the Render method.
            Dim innerTextWriter As TextWriter = writer.InnerWriter
            innerTextWriter.Write((Message + "<br> The time on the server :" & _
               System.DateTime.Now.ToLongTimeString()))

            ' Write the closing tag of the Font element.
            writer.WriteEndTag("font")
        End Sub 'Render
    End Class 'FirstControl 
    ' </snippet3>
End Namespace 'htw_5
' </snippet1>