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
    Public Class MyPage
        Inherits Page

        Protected Overrides Function CreateHtmlTextWriter(ByVal writer As TextWriter) As HtmlTextWriter
            Return New htwFour(writer)
        End Function 'CreateHtmlTextWriter
    End Class 'MyPage


    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class htwFour
        Inherits HtmlTextWriter

        Public Sub New(ByVal writer As TextWriter)
            MyBase.New(writer)
        End Sub 'New


        Public Sub New(ByVal writer As TextWriter, ByVal tabString As String)
            MyBase.New(writer, tabString)
        End Sub 'New

        ' <Snippet1>
        ' Override the RenderBeforeTag method to add the 
        ' opening tag of a Font element before the 
        ' opening tag of any Label elements rendered by this 
        ' custom markup writer. 
        Protected Overrides Function RenderBeforeTag() As String
            ' Compare the TagName property value to the
            ' string label to determine whether the element to 
            ' be rendered is a Label. If it is a Label,
            ' the opening tag of the Font element, with a Color
            ' style attribute set to red, is added before
            ' the Label.
            If String.Compare(TagName, "label") = 0 Then
                Return "<font color=""red"">"
                ' If a Label is not being rendered, use 
                ' the base RenderBeforeTag method.
            Else
                Return MyBase.RenderBeforeTag()
            End If
        End Function 'RenderBeforeTag
        ' </snippet1>

        ' <Snippet2>
        ' Override the RenderAfterTag method to add the 
        ' closing tag of the Font element after the 
        ' closing tag of a Label element has been rendered.
        Protected Overrides Function RenderAfterTag() As String
            ' Compare the TagName property value to the
            ' string label to determine whether the element to 
            ' be rendered is a Label. If it is a Label,
            ' the closing tag of a Font element is rendered
            ' after the closing tag of the Label element.
            If String.Compare(TagName, "label") = 0 Then
                Return "</font>"
                ' If a Label is not being rendered, use 
                ' the base RenderAfterTag method.
            Else
                Return MyBase.RenderAfterTag()
            End If
        End Function 'RenderAfterTag
    End Class 'htwFour 
    ' </snippet2>



    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class ctlMessage
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


        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            ' Write the contents of the control.
            writer.RenderBeginTag(HtmlTextWriterTag.Label)
            writer.Write(Message)
            writer.RenderEndTag()
            writer.Write(("<br>" + "The time on the server: " & System.DateTime.Now.ToLongTimeString()))
        End Sub 'Render 
    End Class 'ctlMessage
End Namespace 'HTW_4