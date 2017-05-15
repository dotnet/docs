' <snippet1>
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions
Imports System.Drawing

' Create a custom class, named TextSample, that renders
' its Text property with styles applied by the
' EnterStyle and ExitStyle methods. 
Namespace AspNet.Samples

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class TextSample
        Inherits Control

        ' Create an instance of the Style class.
        Private textStyle As Style = New Style()
        Private textMessage As String

        ' Create a Text property.
        Public Property Text() As String
            Get
                Return textMessage
            End Get
            Set(ByVal value As String)
                textMessage = value
            End Set
        End Property


        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            ' Set the value of the Text property.
            textMessage = "Hello, World!"

            ' Set the Style object's ForeColor
            ' property to Navy.
            textStyle.ForeColor = Color.Navy

            ' Render the Text property with the style.
            writer.WriteLine("The text property styled: ")
            writer.EnterStyle(textStyle)
            writer.Write(Text)
            writer.ExitStyle(textStyle)

            ' Use the WriteBreak method twice to render
            ' an empty line between the lines of rendered text.
            writer.WriteBreak()
            writer.WriteBreak()

            ' Render the Text property without the style.
            writer.WriteLine("The Text property unstyled: ")
            writer.Write(Text)
        End Sub
    End Class
End Namespace
' </snippet1>
