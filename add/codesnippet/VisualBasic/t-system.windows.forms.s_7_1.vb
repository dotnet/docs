    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' For each screen, add the screen properties to a list box.
        For Each screen In System.Windows.Forms.Screen.AllScreens
            With ListBox1.Items
                .Add("Device Name: " + screen.DeviceName)
                .Add("Bounds: " + screen.Bounds.ToString())
                .Add("Type: " + screen.GetType().ToString())
                .Add("Working Area: " + screen.WorkingArea.ToString())
                .Add("Primary Screen: " + screen.Primary.ToString())
            End With
        Next
    End Sub