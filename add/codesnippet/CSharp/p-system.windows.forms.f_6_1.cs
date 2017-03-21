public void CreateMyBorderlessWindow()
 {
    this.FormBorderStyle = FormBorderStyle.None;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.StartPosition = FormStartPosition.CenterScreen;
    // Remove the control box so the form will only display client area.
    this.ControlBox = false;
 }
 