        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            If _text Is Nothing Then
                _text = "Here is some default text."
            End If
        End Sub