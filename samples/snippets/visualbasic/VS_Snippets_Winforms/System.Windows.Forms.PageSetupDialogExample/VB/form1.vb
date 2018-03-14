Imports System.Windows.Forms

Public Class Form1
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
        Me.Button1 = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(104, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Modify page settings"
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListBox1.Location = New System.Drawing.Point(0, 106)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(292, 160)
        Me.ListBox1.TabIndex = 1
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region
    '<snippet1>

    'This method displays a PageSetupDialog object. If the
    ' user clicks OK in the dialog, selected results of
    ' the dialog are displayed in ListBox1.
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Initialize the dialog's PrinterSettings property to hold user
        ' defined printer settings.
        PageSetupDialog1.PageSettings = _
            New System.Drawing.Printing.PageSettings

        ' Initialize dialog's PrinterSettings property to hold user
        ' set printer settings.
        PageSetupDialog1.PrinterSettings = _
            New System.Drawing.Printing.PrinterSettings

        'Do not show the network in the printer dialog.
        PageSetupDialog1.ShowNetwork = False

        'Show the dialog storing the result.
        Dim result As DialogResult = PageSetupDialog1.ShowDialog()

        ' If the result is OK, display selected settings in
        ' ListBox1. These values can be used when printing the
        ' document.
        If (result = DialogResult.OK) Then
            Dim results() As Object = New Object() _
                {PageSetupDialog1.PageSettings.Margins, _
                 PageSetupDialog1.PageSettings.PaperSize, _
                 PageSetupDialog1.PageSettings.Landscape, _
                 PageSetupDialog1.PrinterSettings.PrinterName, _
                 PageSetupDialog1.PrinterSettings.PrintRange}
            ListBox1.Items.AddRange(results)
        End If

    End Sub
    '</snippet1>

    <System.STAThreadAttribute()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
