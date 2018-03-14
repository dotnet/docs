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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(360, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(360, 136)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(624, 526)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2, Me.Button1})
        Me.IsMdiContainer = True
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AddButtonsToMyChildren()
    End Sub

    '<Snippet1>
    Private Sub AddButtonsToMyChildren()
        ' If there are child forms in the parent form, add Button controls to them.
        Dim x As Integer
        For x = 0 To (Me.MdiChildren.Length) - 1
            ' Create a temporary Button control to add to the child form.
            Dim tempButton As New Button()
            ' Set the location and text of the Button control.
            tempButton.Location = New Point(10, 10)
            tempButton.Text = "OK"
            ' Create a temporary instance of a child form (Form 2 in this case).
            Dim tempChild As Form = CType(Me.MdiChildren(x), Form)
            ' Add the Button control to the control collection of the form.
            tempChild.Controls.Add(tempButton)
        Next x
    End Sub 'AddButtonsToMyChildren
    '</Snippet1>

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim form2 = New Form()

        form2.MDIParent = Me
        form2.Show()

    End Sub
End Class
