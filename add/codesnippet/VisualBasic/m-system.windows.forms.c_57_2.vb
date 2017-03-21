    ' This example creates a PictureBox control on the form and draws to it. 
    ' This example assumes that the Form_Load event handler method is connected 
    ' to the Load event of the form.
    Private pictureBox1 As New PictureBox()

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Dock the PictureBox to the form and set its background to white.
        pictureBox1.Dock = DockStyle.Fill
        pictureBox1.BackColor = Color.White
        ' Connect the Paint event of the PictureBox to the event handler method.
        AddHandler pictureBox1.Paint, AddressOf Me.pictureBox1_Paint

        ' Add the PictureBox control to the Form.
        Me.Controls.Add(pictureBox1)
    End Sub 'Form1_Load


    Private Sub pictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        ' Create a local version of the graphics object for the PictureBox.
        Dim g As Graphics = e.Graphics

        ' Draw a string on the PictureBox.
        g.DrawString("This is a diagonal line drawn on the control", _
            New Font("Arial", 10), Brushes.Red, New PointF(30.0F, 30.0F))
        ' Draw a line in the PictureBox.
        g.DrawLine(System.Drawing.Pens.Red, pictureBox1.Left, _ 
            pictureBox1.Top, pictureBox1.Right, pictureBox1.Bottom)
    End Sub 'pictureBox1_Paint