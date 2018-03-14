 ' <Snippet2> 
Imports System
Imports System.Security.Permissions
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Namespace Samples.AspNet.VB.Controls
    ' Define a type of child control for the custom HtmlSelect control.
    Public Class MyOption1
        Private _id As String
        Private _value As String
        Private _text As String


        Public Property optionid() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property

        Public Property value() As String
            Get
                Return _value
            End Get
            Set(ByVal value As String)
                _value = value
            End Set
        End Property

        Public Property [text]() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property
    End Class 

    ' Define a type of child control for the custom HtmlSelect control.
    Public Class MyOption2
        Private _id As String
        Private _value As String
        Private _text As String


        Public Property optionid() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property

        Public Property value() As String
            Get
                Return _value
            End Get
            Set(ByVal value As String)
                _value = value
            End Set
        End Property

        Public Property [text]() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property
    End Class 

    ' Define a custom HtmlSelectBuilder control.
    Public Class MyHtmlSelectBuilder
        Inherits HtmlSelectBuilder

        ' <Snippet3>
        <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
        Public Overrides Function GetChildControlType(ByVal tagName As String, ByVal attribs As IDictionary) As Type

            ' Distinguish between two possible types of child controls.
            If tagName.ToLower().EndsWith("myoption1") Then
                Return GetType(MyOption1)
            ElseIf tagName.ToLower().EndsWith("myoption2") Then
                Return GetType(MyOption2)
            End If
            Return Nothing

        End Function 
        ' </Snippet3>
    End Class 

    <ControlBuilderAttribute(GetType(MyHtmlSelectBuilder))> _
    Public Class CustomHtmlSelect
        Inherits HtmlSelect

        ' Override AddParsedSubObject to treat the two types
        ' of child controls differently.
        Protected Overrides Sub AddParsedSubObject(ByVal obj As Object)
            Dim _outputtext As String
            If TypeOf obj Is MyOption1 Then
                _outputtext = "option group 1: " + CType(obj, MyOption1).text
                Dim li As New ListItem(_outputtext, CType(obj, MyOption1).value)
                MyBase.Items.Add(li)
            End If
            If TypeOf obj Is MyOption2 Then
                _outputtext = "option group 2: " + CType(obj, MyOption2).text
                Dim li As New ListItem(_outputtext, CType(obj, MyOption2).value)
                MyBase.Items.Add(li)
            End If

        End Sub 
    End Class 
End Namespace
' </Snippet2> 