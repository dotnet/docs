 Public NotInheritable Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents BtnGetScreenInfo As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnGetScreenInfo = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnGetScreenInfo
        '
        Me.BtnGetScreenInfo.Location = New System.Drawing.Point(16, 16)
        Me.BtnGetScreenInfo.Name = "BtnGetScreenInfo"
        Me.BtnGetScreenInfo.Size = New System.Drawing.Size(256, 48)
        Me.BtnGetScreenInfo.TabIndex = 0
        Me.BtnGetScreenInfo.Text = "Get Screen Info"
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(16, 72)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(256, 186)
        Me.ListBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(88, 264)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 317)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.ListBox1, Me.BtnGetScreenInfo})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '<snippet1>
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
    '</snippet1>

    <STAThread()> _
    Shared Sub Main()
    End Sub
End Class
