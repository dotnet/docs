        Public Sub SetScrollBarValues()

            'Set the following scrollbar properties:

            'Minimum: Set to 0

            'SmallChange and LargeChange: Per UI guidelines, these must be set
            '    relative to the size of the view that the user sees, not to
            '    the total size including the unseen part.  In this example,
            '    these must be set relative to the picture box, not to the image.

            'Maximum: Calculate in steps:
            'Step 1: The maximum to scroll is the size of the unseen part.
            'Step 2: Add the size of visible scrollbars if necessary.
            'Step 3: Add an adjustment factor of ScrollBar.LargeChange.


            'Configure the horizontal scrollbar
            '---------------------------------------------
            If (Me.hScrollBar1.Visible) Then

                Me.hScrollBar1.Minimum = 0
                Me.hScrollBar1.SmallChange = CInt(Me.pictureBox1.Width / 20)
                Me.hScrollBar1.LargeChange = CInt(Me.pictureBox1.Width / 10)

                Me.hScrollBar1.Maximum = Me.pictureBox1.Image.Size.Width - pictureBox1.ClientSize.Width  'step 1

                If (Me.vScrollBar1.Visible) Then 'step 2

                    Me.hScrollBar1.Maximum += Me.vScrollBar1.Width
                End If

                Me.hScrollBar1.Maximum += Me.hScrollBar1.LargeChange 'step 3
            End If

            'Configure the vertical scrollbar
            '---------------------------------------------
            If (Me.vScrollBar1.Visible) Then

                Me.vScrollBar1.Minimum = 0
                Me.vScrollBar1.SmallChange = CInt(Me.pictureBox1.Height / 20)
                Me.vScrollBar1.LargeChange = CInt(Me.pictureBox1.Height / 10)

                Me.vScrollBar1.Maximum = Me.pictureBox1.Image.Size.Height - pictureBox1.ClientSize.Height 'step 1

                If (Me.hScrollBar1.Visible) Then 'step 2

                    Me.vScrollBar1.Maximum += Me.hScrollBar1.Height
                End If

                Me.vScrollBar1.Maximum += Me.vScrollBar1.LargeChange 'step 3
            End If
         End Sub