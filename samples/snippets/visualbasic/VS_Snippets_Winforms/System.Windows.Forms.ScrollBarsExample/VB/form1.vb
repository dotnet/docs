Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'Me call is required by the Windows Form Designer.
        InitializeComponent()
        SetFourDifferentScrollBars()

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


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()



        Me.SuspendLayout()
        '
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)

        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region
   

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>

    ' Declare four textboxes.
    Friend WithEvents vertical As System.Windows.Forms.TextBox
    Friend WithEvents horizontal As System.Windows.Forms.TextBox
    Friend WithEvents both As System.Windows.Forms.TextBox
    Friend WithEvents none As System.Windows.Forms.TextBox
        
    Private Sub SetFourDifferentScrollBars()

        Me.vertical = New System.Windows.Forms.TextBox
        Me.horizontal = New System.Windows.Forms.TextBox
        Me.both = New System.Windows.Forms.TextBox
        Me.none = New System.Windows.Forms.TextBox

        ' Create a string for the Text property.
        Dim startString As String = _
            "The scroll bar style for my textbox is: "

        ' Set the location of the four textboxes.
        horizontal.Location = New Point(10, 10)
        vertical.Location = New Point(10, 70)
        none.Location = New Point(10, 170)
        both.Location = New Point(10, 110)

        ' For horizonal scroll bars, the Multiline property must
        ' be true and the WordWrap property must be false.
        ' Increase the size of the Height property to ensure the 
        ' scroll bar is visible.
        horizontal.ScrollBars = ScrollBars.Horizontal
        horizontal.Multiline = True
        horizontal.WordWrap = False
        horizontal.Height = 40
        horizontal.Text = startString & ScrollBars.Horizontal.ToString()

        ' For the vertical scroll bar, Multiline must be true.
        vertical.ScrollBars = ScrollBars.Vertical
        vertical.Multiline = True
        vertical.Text = startString & ScrollBars.Vertical.ToString()

        ' For both scroll bars, the Multiline property 
        ' must be true, and the WordWrap property must be false.
        ' Increase the size of the Height property to ensure the 
        ' scroll bar is visible.
        both.ScrollBars = ScrollBars.Both
        both.Multiline = True
        both.WordWrap = False
        both.Height = 40
        both.AcceptsReturn = True
        both.Text = startString & ScrollBars.Both.ToString()

        ' The none scroll bar does not require specific 
        ' property settings.
        none.ScrollBars = ScrollBars.None
        none.Text = startString & ScrollBars.None.ToString()

        ' Add the textboxes to the form.
        Me.Controls.Add(Me.vertical)
        Me.Controls.Add(Me.horizontal)
        Me.Controls.Add(Me.both)
        Me.Controls.Add(Me.none)

    End Sub
    '</snippet1>
End Class
