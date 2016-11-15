        ' INCORRECT
        Protected Overrides Sub Button1_Click( 
            ByVal sender As System.Object, 
            ByVal e As System.EventArgs) Handles Button1.Click

            ' The Handles clause will cause all code
            ' in this block to be executed twice.
        End Sub