   ' This code example demonstrates using the Padding property to 
   ' create a border around a RichTextBox control.
   Public Sub New()
        InitializeComponent()

        Me.panel1.BackColor = System.Drawing.Color.Blue
        Me.panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill

        Me.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
    End Sub