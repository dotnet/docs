         Dim MyDialog = New ColorDialog()
         ' Allows the user to select or edit a custom color.
         MyDialog.AllowFullOpen = True
         ' Assigns an array of custom colors to the CustomColors property.
         MyDialog.CustomColors = New Integer() {6916092, 15195440, 16107657, 1836924, _
            3758726, 12566463, 7526079, 7405793, 6945974, 241502, 2296476, 5130294, _
            3102017, 7324121, 14993507, 11730944}

         ' Allows the user to get help. (The default is false.)
         MyDialog.ShowHelp = True
         ' Sets the initial color select to the current text color,
         ' so that if the user cancels out, the original color is restored.
         MyDialog.Color = Me.BackColor
         MyDialog.ShowDialog()
         Me.BackColor = MyDialog.Color