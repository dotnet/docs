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