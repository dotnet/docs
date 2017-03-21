        ElseIf (e.AssociatedControl Is button3) Then
            ' Draw the ToolTip using default values if the ToolTip is for button3.
            e.DrawBackground()
            e.DrawBorder()
            e.DrawText()
        End If