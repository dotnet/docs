    Friend WithEvents imageButton As ToolStripButton

    Private Sub InitializeImageButtonWithToolTip()

        ' Construct the button and set the image-related properties.
        imageButton = New ToolStripButton()
        imageButton.Image = New Bitmap(GetType(Timer), "Timer.bmp")
        imageButton.ImageScaling = ToolStripItemImageScaling.SizeToFit

        ' Set the background color of the image to be transparent.
        imageButton.ImageTransparentColor = Color.FromArgb(0, 255, 0)

        ' Show ToolTip text, set custom ToolTip text, and turn
        ' off the automatic ToolTips.
        toolStrip1.ShowItemToolTips = True
        imageButton.ToolTipText = "Click for the current time"
        imageButton.AutoToolTip = False

        ' Add the button to the ToolStrip.
        toolStrip1.Items.Add(imageButton)

    End Sub