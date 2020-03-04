Public Class Form1
    ' firstClicked points to the first Label control 
    ' that the player clicks, but it will be Nothing 
    ' if the player hasn't clicked a label yet
    Private firstClicked As Label = Nothing

    ' secondClicked points to the second Label control 
    ' that the player clicks
    Private secondClicked As Label = Nothing

    ' <snippet10>
    ''' <summary>
    ''' Check every icon to see if it is matched, by 
    ''' comparing its foreground color to its background color. 
    ''' If all of the icons are matched, the player wins
    ''' </summary>
    Private Sub CheckForWinner()

        ' Go through all of the labels in the TableLayoutPanel, 
        ' checking each one to see if its icon is matched
        For Each control In TableLayoutPanel1.Controls
            Dim iconLabel = TryCast(control, Label)
            If iconLabel IsNot Nothing AndAlso 
               iconLabel.ForeColor = iconLabel.BackColor Then Exit Sub
        Next

        ' If the loop didn't return, it didn't find 
        ' any unmatched icons
        ' That means the user won. Show a message and close the form
        MessageBox.Show("You matched all the icons!", "Congratulations")
        Close()

    End Sub
    ' </snippet10>

    Sub PlaceHolder(ByVal sender As Object, ByVal e As EventArgs)
        Dim clickedLabel = TryCast(sender, Label)

        ' <snippet11>
        ' If the player gets this far, the timer isn't 
        ' running and firstClicked isn't Nothing, 
        ' so this must be the second icon the player clicked
        ' Set its color to black
        secondClicked = clickedLabel
        secondClicked.ForeColor = Color.Black

        ' Check to see if the player won
        CheckForWinner()

        ' If the player clicked two matching icons, keep them 
        ' black and reset firstClicked and secondClicked 
        ' so the player can click another icon
        If firstClicked.Text = secondClicked.Text Then
            firstClicked = Nothing
            secondClicked = Nothing
            Exit Sub
        End If
        ' </snippet11>

    End Sub

End Class




