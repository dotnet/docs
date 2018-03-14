' The following code example demonstrates using the FontDialog.MinSize, 
' FontDialog.MaxSize, and FontDialog.ShowEffects members, and 
' handling of Apply event.

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
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'FontDialog1
        '
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(72, 136)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 88)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Click for Font Dialog"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Shared Sub main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Set FontMustExist to true, which causes message box error
        ' if the user enters a font that does not exist. 
        FontDialog1.FontMustExist = True

        ' Set a minimum and maximum size to be
        ' shown in the FontDialog.
        FontDialog1.MaxSize = 32
        FontDialog1.MinSize = 18

        ' Show the Apply button in the dialog.
        FontDialog1.ShowApply = True

        ' Do not show effects such as Underline
        ' and Bold.
        FontDialog1.ShowEffects = False

        ' Save the existing font.
        Dim oldFont As System.Drawing.Font = Me.Font

        ' Show the dialog and save the result.
        Dim result As DialogResult = FontDialog1.ShowDialog()

        ' If The OK button in the Font dialog box is clicked, 
        ' set all the controls' fonts to the chosen font by
        ' calling the FontDialog1_Apply method.
        If result = DialogResult.OK Then
            FontDialog1_Apply(Me.Button1, New System.EventArgs)

            ' If the Cancel button is clicked, set the controls'
            ' fonts back to the original font.
        ElseIf (result = DialogResult.Cancel) Then
            Dim containedControl As Control
            For Each containedControl In Me.Controls
                containedControl.Font = oldFont
            Next

        End If
    End Sub

    ' Handle the Apply event by setting all controls' fonts to 
    ' the chosen font. 
    Private Sub FontDialog1_Apply(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles FontDialog1.Apply

        Me.Font = FontDialog1.Font
        Dim containedControl As Control
        For Each containedControl In Me.Controls
            containedControl.Font = FontDialog1.Font
        Next
    End Sub
    '</snippet1>
End Class
