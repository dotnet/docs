
    'Declare a new TrackBar object.
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar

    ' Initalize the TrackBar and add it to the form.
    Private Sub InitializeTrackBar()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar

        ' Set the TickStyle property so there are ticks on both sides
        ' of the TrackBar.
        TrackBar1.TickStyle = TickStyle.Both

        ' Set the minimum and maximum number of ticks.
        TrackBar1.Minimum = 10
        TrackBar1.Maximum = 100

        ' Set the tick frequency to one tick every ten units.
        TrackBar1.TickFrequency = 10

        TrackBar1.Location = New System.Drawing.Point(75, 30)
        Me.Controls.Add(Me.TrackBar1)
    End Sub


    ' Handle the TrackBar.ValueChanged event by calculating a value for
    ' TextBox1 based on the TrackBar value.  
    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        TextBox1.Text = System.Math.Round(TrackBar1.Value / 10)
    End Sub