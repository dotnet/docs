' <Snippet2>
Imports System.Web.UI
Imports System.Drawing
Imports System.Globalization

Public Class UpdatePanelAnimationWithClientResource
    Inherits Control

    Private _updatePanelID As String
    Private _borderColor As Color
    Private _animate As Boolean

    Public Property BorderColor() As Color
        Get
            Return _borderColor
        End Get
        Set(ByVal value As Color)
            _borderColor = value
        End Set
    End Property

    Public Property UpdatePanelID() As String
        Get
            Return _updatePanelID
        End Get
        Set(ByVal value As String)
            _updatePanelID = value
        End Set
    End Property

    Public Property Animate() As Boolean
        Get
            Return _animate
        End Get
        Set(ByVal value As Boolean)
            _animate = value
        End Set
    End Property

    Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
        MyBase.OnPreRender(e)
        If (Animate) Then

            Dim updatePanel As UpdatePanel = CType(Me.FindControl(UpdatePanelID), UpdatePanel)

            Dim script As String = String.Format( _
                   CultureInfo.InvariantCulture, _
                   "Sys.Application.add_load(function(sender, args) {{var {0}_borderAnimation = new BorderAnimation('{1}');var panelElement = document.getElementById('{0}');if (args.get_isPartialLoad()) {{{0}_borderAnimation.animate(panelElement);}}}});", _
                   updatePanel.ClientID, _
                   ColorTranslator.ToHtml(BorderColor))


            ScriptManager.RegisterStartupScript( _
                Me, _
                GetType(UpdatePanelAnimationWithClientResource), _
                ClientID, _
                script, _
                True)
        End If
    End Sub
End Class
' </Snippet2>
