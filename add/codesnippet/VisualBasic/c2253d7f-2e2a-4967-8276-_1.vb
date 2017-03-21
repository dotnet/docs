    ' Create two RadioButtons to add to the Panel.
    Dim RadioAddButton As RadioButton = New RadioButton()
    Dim RadioAddRangeButton As RadioButton = New RadioButton()

    ' Add controls to the Panel using the AddRange method.
    Private Sub AddRangeButton_Click(ByVal sender As System.Object, _
		ByVal e As System.EventArgs) Handles AddRangeButton.Click
        ' Set the Text the RadioButtons will display.
        RadioAddButton.Text = "RadioAddButton"
        RadioAddRangeButton.Text = "RadioAddRangeButton"

        ' Set the appropriate location of RadioAddRangeButton.
        RadioAddRangeButton.Location = New System.Drawing.Point( _
        RadioAddButton.Location.X, _
        RadioAddButton.Location.Y + RadioAddButton.Height)

        ' Add the controls to the Panel.
        Panel1.Controls.AddRange(New Control() {RadioAddButton, RadioAddRangeButton})
    End Sub