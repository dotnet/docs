 ' <Snippet2> 
Imports System
Imports System.Security.Permissions
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Namespace Samples.AspNet.VB
    ' Define a child control for the custom HtmlSelect.
    Public Class MyCustomOption
        Private _id As String
        Private _value As String


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
    End Class

    ' Define a custom HtmlSelectBuilder.
    Public Class MyHtmlSelectBuilderWithparseException
        Inherits HtmlSelectBuilder

        <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
        Public Overrides Function GetChildControlType(ByVal tagName As String, ByVal attribs As IDictionary) As Type

            ' Distinguish between two possible types of child controls.
            If tagName.ToLower().EndsWith("mycustomoption") Then

                Return GetType(MyCustomOption)

            Else
                
                ' <Snippet3>
                Throw New HttpParseException("This custom HtmlSelect control" & _ 
                         "requires child elements of the form ""MyCustomOption""")
                ' </Snippet3>
            End If

        End Function

    End Class


    <ControlBuilderAttribute(GetType(MyHtmlSelectBuilderWithparseException))> _
    Public Class CustomHtmlSelectWithHttpParseException
        Inherits HtmlSelect

        ' Override the AddParsedSubObject method.
        Protected Overrides Sub AddParsedSubObject(ByVal obj As Object)

            Dim _outputtext As String
            If TypeOf obj Is MyCustomOption Then
                _outputtext = "custom select option : " + CType(obj, MyCustomOption).value
                Dim li As New ListItem(_outputtext, CType(obj, MyCustomOption).value)
                MyBase.Items.Add(li)
            End If

        End Sub

    End Class

End Namespace
' </Snippet2> 