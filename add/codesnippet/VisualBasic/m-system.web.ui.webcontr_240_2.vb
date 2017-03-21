        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)
            ' Run the OnPreRender method on the base class.
            MyBase.OnPreRender(e)

            ' Always display the Ad with a border.
            Me.BorderWidth = System.Web.UI.WebControls.Unit.Point(1)
        End Sub