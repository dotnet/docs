'<snippet1>
Imports System.Drawing
Imports System.Windows.Forms
Imports System
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        InitializeComponent()
        AddHandlers()
        InitializeFormHelp()

    End Sub

    
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents withdrawal As System.Windows.Forms.TextBox
    Friend WithEvents deposit As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents balance As System.Windows.Forms.Label
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider

   <System.Diagnostics.DebuggerStepThrough()> Private Sub     InitializeComponent()
        Me.withdrawal = New System.Windows.Forms.TextBox
        Me.deposit = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.balance = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.SuspendLayout()
        
        Me.withdrawal.Location = New System.Drawing.Point(32, 200)
        Me.withdrawal.Name = "withdrawal"
        Me.withdrawal.Size = New System.Drawing.Size(88, 20)
        Me.withdrawal.TabIndex = 0
        Me.withdrawal.Text = ""
       
        Me.deposit.Location = New System.Drawing.Point(168, 200)
        Me.deposit.Name = "deposit"
        Me.deposit.TabIndex = 1
        Me.deposit.Text = ""
       
        Me.Label1.Location = New System.Drawing.Point(56, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Account Balance:"
       
        Me.Label2.Location = New System.Drawing.Point(168, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 24)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Deposit:"
        
        Me.Label3.Location = New System.Drawing.Point(32, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 24)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Withdrawal:"
        
        Me.ErrorProvider1.ContainerControl = Me
        
        Me.balance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.balance.Location = New System.Drawing.Point(152, 88)
        Me.balance.Name = "balance"
        Me.balance.TabIndex = 6
        Me.balance.Text = "345.65"
        Me.balance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.balance)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.deposit)
        Me.Controls.Add(Me.withdrawal)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
 
   
    
    Private Sub AddHandlers()

        'Add the event-handler delegates to handle the KeyDown events.
        AddHandler deposit.KeyDown, _
            New KeyEventHandler(AddressOf ProcessEntry)
        AddHandler withdrawal.KeyDown, _
            New KeyEventHandler(AddressOf ProcessEntry)

        'Add the event-handler delegates to handled the KeyPress events.
        AddHandler deposit.KeyPress, _
            New KeyPressEventHandler(AddressOf CheckForDigits)
        AddHandler withdrawal.KeyPress, _
            New KeyPressEventHandler(AddressOf CheckForDigits)

    End Sub
    '<snippet2>
    Private Sub InitializeFormHelp()

        ' Set the form's border to the FixedDialog style.
        Me.FormBorderStyle = FormBorderStyle.FixedDialog

        ' Remove the Maximize and Minimize buttons from the form.
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        ' Add the Help button to the form.
        Me.HelpButton = True

        ' Set the Help string for the deposit textBox.
        HelpProvider1.SetHelpString(deposit, _
            "Enter an amount in the format xxx.xx" _
                & "and press Enter to deposit.")

        ' Set the Help string for the withdrawal textBox.
        HelpProvider1.SetHelpString(withdrawal, _
            "Enter an amount in the format xxx.xx" _
            & "and press Enter to withdraw.")

    End Sub
    '</snippet2>

    Private Sub ProcessEntry(ByVal sender As Object, _
        ByVal e As KeyEventArgs)

        ' Cast the sender back to a TextBox.
        Dim textBoxSender As Control = CType(sender, TextBox)

        ' Set the error description to an empty string ().
        ErrorProvider1.SetError(textBoxSender, "")

        ' Declare the variable to hold the new balance.
        Dim newBalance As Double

        ' Wrap the code in a Try/Catch block to catch 
        ' errors that can occur when converting the string 
        ' to a double.

        Try
            If (e.KeyCode = Keys.Enter) Then

                ' Switch on the text box that received
                ' the KeyPress event. Convert the text to type double,
                ' and compute the new balance.
                Select Case textBoxSender.Name
                    Case "withdrawal"
                        newBalance = Double.Parse(balance.Text) _
                            - Double.Parse(withdrawal.Text)
                        withdrawal.Text = ""
                    Case "deposit"
                        newBalance = Double.Parse(balance.Text) _
                            + Double.Parse(deposit.Text)
                        deposit.Text = ""
                End Select

                ' Check the value of new balance and set the
                ' Forecolor property accordingly.
                If (newBalance < 0) Then
                    balance.ForeColor = Color.Red
                Else
                    balance.ForeColor = Color.Black
                End If

                ' Set the text of the balance text box
                ' to the newBalance value.
                balance.Text = newBalance.ToString
            End If

        Catch ex As FormatException

            ' If a FormatException is thrown, set the
            ' error string to the HelpString message for 
            ' the control.
            ErrorProvider1.SetError(textBoxSender, _
                HelpProvider1.GetHelpString(textBoxSender))
        End Try
    End Sub


    Private Sub CheckForDigits(ByVal sender As Object, ByVal e _
        As KeyPressEventArgs)

        ' If the character is not a digit, period, or backspace then
        ' ignore it by setting the KeyPressEventArgs.Handled
        ' property to true.
        If Not (Char.IsDigit(e.KeyChar) _
            Or e.KeyChar = "." Or e.KeyChar = ChrW(Keys.Back)) Then
            e.Handled = True
        End If
    End Sub
   

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class
 '</snippet1>

