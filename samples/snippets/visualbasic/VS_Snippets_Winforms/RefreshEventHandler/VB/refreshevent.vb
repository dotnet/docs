Imports System

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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    'Friend WithEvents UserControl11 As WindowsControlLibrary3.UserControl1

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container


    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "TextBox1"
        '
        'UserControl11
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {TextBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '<snippet1>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = "changed"
        AddHandler System.ComponentModel.TypeDescriptor.Refreshed, AddressOf OnRefreshed
        System.ComponentModel.TypeDescriptor.GetProperties(TextBox1)
        System.ComponentModel.TypeDescriptor.Refresh(TextBox1)
    End Sub

    Private Sub OnRefreshed(ByVal e As System.ComponentModel.RefreshEventArgs)
        Console.WriteLine(e.ComponentChanged.ToString())
    End Sub
    '</snippet1>

End Class
