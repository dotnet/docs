    ' A custom class that overrides the CreateHtmlTextWriter method.
    ' This page uses the StyledLabelHtmlWriter to render its content.  
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class MyPage
        Inherits Page

        Protected Overrides Function CreateHtmlTextWriter(ByVal writer As TextWriter) As HtmlTextWriter
            Return New HtmlStyledLabelWriter(writer)
        End Function 'CreateHtmlTextWriter
    End Class 'MyPage