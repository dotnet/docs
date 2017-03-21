        ' Override the OnUnLoad method to set _text to
        ' a default value if it is null.
        Protected Overrides Sub OnUnload(ByVal e As EventArgs)
            MyBase.OnUnload(e)
            If _text Is Nothing Then
                _text = "Here is some default text."
            End If
        End Sub