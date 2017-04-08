Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.CS1.Controls
    '<snippet1>   
    Public Class CustomHyperLinkControl
        Inherits WebControl

        Public Sub New()
        End Sub 'New

        ' The TargetUrl property represents the URL that 
        ' the custom hyperlink control navigates to.        
        <UrlProperty()> _
        Public Property TargetUrl() As String
            Get
                Dim s As String = CStr(ViewState("TargetUrl"))
                If (s Is Nothing) Then
                    Return String.Empty
                Else
                    Return s
                End If
            End Get
            Set(ByVal value As String)
                ViewState("TargetUrl") = value
            End Set
        End Property

        ' The Text property represents the visible text that 
        ' the custom hyperlink control is displayed with.        

        Public Overridable Property [Text]() As String
            Get
                Dim s As String = CStr(ViewState("Text"))
                If (s Is Nothing) Then
                    Return String.Empty
                Else
                    Return s
                End If
            End Get
            Set(ByVal value As String)
                ViewState("Text") = value
            End Set
        End Property

        ' Implement method to render the control.

    End Class 'CustomHyperLinkControl
    '</snippet1>    
End Namespace 'Samples.AspNet.CS1.Controls


Namespace Samples.AspNet.CS2.Controls
    '<snippet2>
    Public Class CustomHyperLinkControl
        Inherits WebControl

        Public Sub New()
        End Sub 'New

        ' The TargetUrl property represents the URL that 
        ' the custom hyperlink control navigates to.        
        <UrlProperty("*.aspx")> _
        Public Property TargetUrl() As String
            Get
                Dim s As String = CStr(ViewState("TargetUrl"))
                If (s Is Nothing) Then
                    Return String.Empty
                Else
                    Return s
                End If
            End Get
            Set(ByVal value As String)
                ViewState("TargetUrl") = value
            End Set
        End Property

        ' The Text property represents the visible text that 
        ' the custom hyperlink control is displayed with.                
        Public Overridable Property [Text]() As String
            Get
                Dim s As String = CStr(ViewState("Text"))
                If (s Is Nothing) Then
                    Return String.Empty
                Else
                    Return s
                End If
            End Get
            Set(ByVal value As String)
                ViewState("Text") = value
            End Set
        End Property

        ' Implement method to render the control.

    End Class 'CustomHyperLinkControl
    '</snippet2>    
End Namespace 'Samples.AspNet.CS2.Controls

Namespace Samples.AspNet.CS3.Controls
    '<snippet3>
    Public Class CustomHyperLinkControl
        Inherits WebControl

        Public Sub New()
        End Sub 'New

        ' The TargetUrl property represents the URL that 
        ' the custom hyperlink control navigates to.        
        <UrlProperty("*.aspx")> _
        Public Property TargetUrl() As String
            Get
                Dim s As String = CStr(ViewState("TargetUrl"))
                If (s Is Nothing) Then
                    Return String.Empty
                Else
                    Return s
                End If
            End Get
            Set(ByVal value As String)
                ViewState("TargetUrl") = value
            End Set
        End Property

        ' The Text property represents the visible text that 
        ' the custom hyperlink control is displayed with.                
        Public Overridable Property [Text]() As String
            Get
                Dim s As String = CStr(ViewState("Text"))
                If (s Is Nothing) Then
                    Return String.Empty
                Else
                    Return s
                End If
            End Get
            Set(ByVal value As String)
                ViewState("Text") = value
            End Set
        End Property

        ' Implement method to render the control.
    End Class 'CustomHyperLinkControl
    '</snippet3>    
End Namespace 'Samples.AspNet.CS3.Controls
