    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class CustomImageButtonOnPreRender
        Inherits ImageButton

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)

            ' Run the OnPreRender method on the base class.
            MyBase.OnPreRender(e)

            ' Always display the ImageButton with a thin border.
            Me.BorderWidth = Unit.Point(1)
        End Sub
    End Class