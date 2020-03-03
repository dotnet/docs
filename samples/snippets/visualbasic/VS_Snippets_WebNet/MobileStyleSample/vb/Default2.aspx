<%@ Page Language="VB" Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<script runat="server">
    '<Snippet2>
    Public Class CustomStyle
        Inherits System.Web.UI.MobileControls.Style
        Private themeNameKey As String

        Public Sub New(ByVal name As String)
            themeNameKey = _
                RegisterStyle(name, GetType(String), _
                    String.Empty, True).ToString()
        End Sub
        
        Public Property ThemeName() As String
            Get
                Return Me(themeNameKey).ToString()
            End Get
            Set(ByVal value As String)
                Me(themeNameKey) = value
            End Set
        End Property
    End Class
    '</Snippet2>
</script>

<html xmlns="http:'www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">

    </mobile:form>
</body>
</html>
