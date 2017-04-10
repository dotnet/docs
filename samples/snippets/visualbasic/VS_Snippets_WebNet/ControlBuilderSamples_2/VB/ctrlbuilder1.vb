Imports System
Imports System.ComponentModel
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace MS.ASPNET.Samples

    ' <snippet3>
    ' A custom ControlBuilder class that is designed
    ' for custom Label classes. It does not allow white
    ' space in the control to be interpreted as a LiteralControl,
    ' does not allow child controls, and allows literal strings
    ' to be HTML decoded.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CstmLabelBuilder
        Inherits ControlBuilder

        ' Override the AllowWhiteSpaceLiterals method
        ' so that white spaces in a control are not 
        ' converted to LiteralControl objects.
        Public Overrides Function AllowWhitespaceLiterals() As Boolean
            Return False
        End Function

        ' <snippet1>
        ' Override the AppendSubBuilder method to throw an
        ' exception if the class it is applied to attempts
        ' to include child controls. 
        Public Overrides Sub AppendSubBuilder(ByVal subBuilder As ControlBuilder)
            Throw New Exception( _
               "A custom label control cannot contain other objects.")
        End Sub
        ' </snippet1>

        ' <snippet2>
        ' Override the HtmlDecodeLiterals method to allow HTML
        ' decoding of literal strings in any controls this builder
        ' is applied to.
        Public Overrides Function HtmlDecodeLiterals() As Boolean
            Return True
        End Function
        ' </snippet2>

    End Class
    ' </snippet3>

    <ControlBuilder(GetType(CstmLabelBuilder)), _
       DefaultProperty("Text"), _
       ParseChildren(False)> _
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomLabel
        Inherits WebControl

        Protected Overrides ReadOnly Property TagKey() As HtmlTextWriterTag
            Get
                Return HtmlTextWriterTag.Label
            End Get
        End Property

        Public Property Text() As String
            Get
                Dim s As String = CStr(ViewState("Text"))
                If s Is Nothing Then
                    Return String.Empty
                Else
                    Return s
                End If
            End Get
            Set(ByVal value As String)
                ViewState("Text") = Value
            End Set
        End Property

        Protected Overrides Sub AddParsedSubObject(ByVal obj As Object)
            If TypeOf obj Is LiteralControl Then
                Text = (CType(obj, LiteralControl)).Text
            End If
        End Sub

        Protected Overrides Sub RenderContents(ByVal w As HtmlTextWriter)
            w.Write(HttpUtility.HtmlEncode(Text))
        End Sub

    End Class
End Namespace
