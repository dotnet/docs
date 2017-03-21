        ' Override the OnPreRender method to set _message to
        ' a default value if it is null.
        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            MyBase.OnPreRender(e)
            If _message Is Nothing Then
                _message = "Here is some default text."
            End If
        End Sub