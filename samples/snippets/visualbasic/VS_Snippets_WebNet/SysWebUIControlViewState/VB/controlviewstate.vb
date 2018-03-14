' <snippet1>
' This control renders values stored in view state for Text and FontSize properties.

Imports System
Imports System.Web
Imports System.Web.UI

Namespace ViewStateControlSamples

    Public Class CustomLabel : Inherits Control
        Private Const defaultFontSize As Integer = 3

        ' <snippet2>
        ' Add property values to view state with set; 
        ' retrieve them from view state with get.
        Public Property [Text]() As String
            Get
                Dim o As Object = ViewState("Text")
                If (IsNothing(o)) Then
                    Return String.Empty
                Else
                    Return CStr(o)
                End If
            End Get
            Set(ByVal value As String)
                ViewState("Text") = value
            End Set
        End Property

        ' </snippet2>

        Public Property FontSize() As Integer
            Get
                Dim o As Object = ViewState("FontSize")
                If (IsNothing(o)) Then
                    Return defaultFontSize
                Else
                    Return CInt(ViewState("FontSize"))
                End If

            End Get
            Set(ByVal value As Integer)
                ViewState("FontSize") = value
            End Set
        End Property
        <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Sub Render(ByVal Output As HtmlTextWriter)
            Output.Write("<font size=" & Me.FontSize & ">" & Me.Text & "</font>")
        End Sub

    End Class

End Namespace
' </snippet1>