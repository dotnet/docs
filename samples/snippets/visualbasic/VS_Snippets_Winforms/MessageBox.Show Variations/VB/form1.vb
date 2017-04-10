Imports System.Windows.Forms

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ServerName As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ServerName = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ServerName
        '
        Me.ServerName.Location = New System.Drawing.Point(64, 40)
        Me.ServerName.Name = "ServerName"
        Me.ServerName.TabIndex = 0
        Me.ServerName.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(104, 80)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(408, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.ServerName})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Shared Sub Main()
       System.Windows.Forms.Application.Run(New Form1())
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' Checks the value of the text.

        ValidateUserEntry()
        ValidateUserEntry2()
        ValidateUserEntry3()
        ValidateUserEntry4()
        ValidateUserEntry5()


        If ServerName.Text.Length = 0 Then

            ' Initializes variables to pass to the MessageBox.Show method.

            Dim Message As String = "You did not enter a server name. Cancel this operation?"
            Dim Caption As String = "No Server Name Specified"
            Dim Buttons As Integer = MessageBoxButtons.YesNo

            Dim Result As DialogResult

            'Displays a MessageBox using the Question icon and specifying the No button as the default.

            Result = MessageBox.Show(Me, Message, Caption, _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, _
                MessageBoxOptions.RightAlign)

            ' Gets the result of the MessageBox display.

            If Result = System.Windows.Forms.DialogResult.Yes Then

                ' Closes the parent form.

                Me.Close()

            End If

        End If


    End Sub
    '<snippet1>
    Private Sub ValidateUserEntry()

        ' Checks the value of the text.

        If ServerName.Text.Length = 0 Then

            ' Initializes variables to pass to the MessageBox.Show method.

            Dim Message As String = "You did not enter a server name. Cancel this operation?"
            Dim Caption As String = "Error Detected in Input"
            Dim Buttons As MessageBoxButtons = MessageBoxButtons.YesNo

            Dim Result As DialogResult

            'Displays the MessageBox

            Result = MessageBox.Show(Message, Caption, Buttons)

            ' Gets the result of the MessageBox display.

            If Result = System.Windows.Forms.DialogResult.Yes Then

                ' Closes the parent form.

                Me.Close()

            End If

        End If

    End Sub
    '</snippet1>

    '<snippet2>
    Private Sub ValidateUserEntry2()


        ' Checks the value of the text.

        If ServerName.Text.Length = 0 Then

            ' Initializes variables to pass to the MessageBox.Show method.

            Dim Message As String = "You did not enter a server name. Cancel this operation?"
            Dim Caption As String = "No Server Name Specified"
            Dim Buttons As Integer = MessageBoxButtons.YesNo

            Dim Result As DialogResult

            'Displays a MessageBox using the Question icon and specifying the No button as the default.

            Result = MessageBox.Show(Me, Message, Caption, MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)


            ' Gets the result of the MessageBox display.

            If Result = System.Windows.Forms.DialogResult.Yes Then

                ' Closes the parent form.

                Me.Close()

            End If

        End If

    End Sub
    '</snippet2>

    '<snippet3>
    Private Sub ValidateUserEntry3()

        ' Checks the value of the text.

        If ServerName.Text.Length = 0 Then

            ' Initializes variables to pass to the MessageBox.Show method.

            Dim Message As String = "You did not enter a server name. Cancel this operation?"
            Dim Caption As String = "No Server Name Specified"
            Dim Buttons As Integer = MessageBoxButtons.YesNo

            Dim Result As DialogResult

            'Displays a MessageBox using the Question icon and specifying the No button as the default.

            Result = MessageBox.Show(Me, Message, Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                MessageBoxDefaultButton.Button1)

            ' Gets the result of the MessageBox display.

            If Result = System.Windows.Forms.DialogResult.Yes Then

                ' Closes the parent form.

                Me.Close()

            End If

        End If
    End Sub
    '</snippet3>

    '<snippet4>
    Private Sub ValidateUserEntry4()

        ' Checks the value of the text.

        If ServerName.Text.Length = 0 Then

            ' Initializes variables to pass to the MessageBox.Show method.

            Dim Message As String = "You did not enter a server name. Cancel this operation?"
            Dim Caption As String = "No Server Name Specified"
            Dim Buttons As Integer = MessageBoxButtons.YesNo

            Dim Result As DialogResult

            'Displays a MessageBox using the Question icon and specifying the No button as the default.

            Result = MessageBox.Show(Me, Message, Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            ' Gets the result of the MessageBox display.

            If Result = System.Windows.Forms.DialogResult.Yes Then

                ' Closes the parent form.

                Me.Close()

            End If

        End If

    End Sub
    '</snippet4>

    '<snippet5>
    Private Sub ValidateUserEntry5()

        ' Checks the value of the text.

        If ServerName.Text.Length = 0 Then

            ' Initializes variables to pass to the MessageBox.Show method.

            Dim Message As String = "You did not enter a server name. Cancel this operation?"
            Dim Caption As String = "No Server Name Specified"
            Dim Buttons As Integer = MessageBoxButtons.YesNo

            Dim Result As DialogResult

            'Displays a MessageBox using the Question icon and specifying the No button as the default.

            Result = MessageBox.Show(Me, Message, Caption, MessageBoxButtons.YesNo)

            ' Gets the result of the MessageBox display.

            If Result = System.Windows.Forms.DialogResult.Yes Then

                ' Closes the parent form.

                Me.Close()

            End If

        End If

    End Sub
    '</snippet5>

    '<Snippet6>
    Private Sub DisplayMessageBoxText()
        MessageBox.Show("Hello, world.")
    End Sub
    '</Snippet6>







End Class
