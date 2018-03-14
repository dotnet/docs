' This sample demonstrates how to call each member of the StringBuilder class.
'<Snippet2>
Imports System
Imports System.Text

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Event handler for Run button.
    Private Sub Button1_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        ConstructorWithNothing()
        ConstructorWithCapacity()
        ConstructorWithString()
        ConstructorWithCapacityAndMax()
        ConstructorWithSubstring()
        ConstructorWithStringAndMax()

        ' Align interface and conclude application.
        tbxOutput.AppendText(vbCrLf + "This sample completed " + _
            "successfully; press Exit to continue.")

        tbxOutput.Cursor = Cursors.Default
    End Sub
    Private Sub ConstructorWithNothing()
        ' Initialize an new stringBuilder object.
        '<Snippet1>
        Dim stringBuilder As New StringBuilder
        '</Snippet1>
    End Sub

    Private Sub ConstructorWithCapacity()
        ' Initialize a stringBuilder object with the specified capacity.
        '<Snippet3>
        Dim capacity As Integer = 255
        Dim stringBuilder As New StringBuilder(capacity)
        '</Snippet3>
    End Sub

    Private Sub ConstructorWithString()
        ' Initialize a stringBuilder object with the specified string.
        '<Snippet4>
        Dim initialString As String = "Initial string."
        Dim stringBuilder As New StringBuilder(initialString)
        '</Snippet4>
    End Sub

    Private Sub ConstructorWithCapacityAndMax()
        ' Initialize a stringBuilder object with the specified capacity 
        ' and maximum capacity.
        '<Snippet5>
        Dim capacity As Integer = 255
        Dim maxCapacity As Integer = 1024
        Dim stringBuilder As New StringBuilder(capacity, maxCapacity)
        '</Snippet5>
    End Sub

    Private Sub ConstructorWithSubstring()
        ' Initialize a stringBuilder object with the specified substring.
        '<Snippet6>
        Dim initialString As String = "Initial string for stringbuilder."
        Dim startIndex As Integer = 0
        Dim substringLength As Integer = 14
        Dim capacity As Integer = 255
        Dim stringBuilder As New StringBuilder(initialString, _
            startIndex, substringLength, capacity)
        '</Snippet6>
    End Sub

    Private Sub ConstructorWithStringAndMax()
        ' Initialize a stringBuilder object with the specified string
        ' and maximum capacity.
        '<Snippet7>
        Dim initialString As String = "Initial string. "
        Dim capacity As Integer = 255
        Dim stringBuilder As New StringBuilder(initialString, capacity)
        '</Snippet7>

        ' Ensure appending the specified string will not exceed the
        ' maximum capacity.
        '<Snippet8>
        Dim phraseToAdd As String = "Sentence to be appended."
        If ((stringBuilder.Length + phraseToAdd.Length) _
                 <= stringBuilder.MaxCapacity) Then
            stringBuilder.Append(phraseToAdd)
        End If
        '</Snippet8>

        ' Retrieve the string value of the stringBuilder object.
        '<Snippet9>
        Dim builderResults As String = stringBuilder.ToString()
        '</Snippet9>

        '<Snippet10>
        ' Retrieve the last 10 characters of the stringBuilder object.
        Dim sentenceLength As Integer = 10
        Dim startPosition As Integer = stringBuilder.Length - sentenceLength
        Dim endPhrase As String
        endPhrase = stringBuilder.ToString(startPosition, sentenceLength)
        '</Snippet10>

        '<Snippet11>
        ' Retrieve the last character of the stringBuilder object.
        Dim lastCharacterPosition As Integer = stringBuilder.Length - 1
        Dim lastCharacter As Char = stringBuilder(lastCharacterPosition)
        '</Snippet11>
    End Sub
    ' Event handler for Exit button.
    Private Sub Button2_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click

        Application.Exit()
    End Sub
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
            If Not (components Is Nothing) Then
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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tbxOutput As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tbxOutput = New System.Windows.Forms.RichTextBox
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.DockPadding.All = 20
        Me.Panel2.Location = New System.Drawing.Point(0, 320)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(616, 64)
        Me.Panel2.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Font = New System.Drawing.Font( _
            "Microsoft Sans Serif", _
            9.0!, _
            System.Drawing.FontStyle.Regular, _
            System.Drawing.GraphicsUnit.Point, _
            CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(446, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 24)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "&Run"
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.Font = New System.Drawing.Font( _
            "Microsoft Sans Serif", _
            9.0!, _
            System.Drawing.FontStyle.Regular, _
            System.Drawing.GraphicsUnit.Point, _
            CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(521, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 24)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "E&xit"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tbxOutput)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.DockPadding.All = 20
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(616, 320)
        Me.Panel1.TabIndex = 2
        '
        'tbxOutput
        '
        Me.tbxOutput.AccessibleDescription = _
            "Displays output from application."
        Me.tbxOutput.AccessibleName = "Output textbox."
        Me.tbxOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbxOutput.Location = New System.Drawing.Point(20, 20)
        Me.tbxOutput.Name = "tbxOutput"
        Me.tbxOutput.Size = New System.Drawing.Size(576, 280)
        Me.tbxOutput.TabIndex = 1
        Me.tbxOutput.Text = "Click the Run button to run the application."
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(616, 384)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Form1"
        Me.Text = "StringBuilder"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
' This sample completed successfully; press Exit to continue.
'</Snippet2>