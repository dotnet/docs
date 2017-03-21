        Private Sub showColorValueLabels()
            label1.Text = "Red value is : " & trackBar1.Value.ToString()
            label3.Text = "Green Value is : " & trackBar2.Value.ToString()
            label2.Text = "Blue Value is : " & trackBar3.Value.ToString()
        End Sub

        Private Sub trackBar_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles trackBar1.Scroll, trackBar2.Scroll, trackBar3.Scroll
            Dim myTB As System.Windows.Forms.TrackBar
            myTB = sender
            panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value)
            myTB.Text = "Value is " & myTB.Value.ToString()
            showColorValueLabels()
        End Sub