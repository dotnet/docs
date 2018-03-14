' This example demonstrates using the read-only fields DateTimePicker.MaxDateTime
' and DateTimePicker.MinDateTime.

Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitializeDateTimePicker()

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

    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container

        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'DateTimePicker1
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

    ' Declare the DateTimePicker.
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker


    Private Sub InitializeDateTimePicker()

        ' Construct the DateTimePicker.
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker

        'Set size and location.
        Me.DateTimePicker1.Location = New System.Drawing.Point(40, 88)
        Me.DateTimePicker1.Size = New Size(160, 21)
        
        ' Set the alignment of the drop-down MonthCalendar to right.
        Me.DateTimePicker1.DropDownAlign = LeftRightAlignment.Right

        ' Set the Value property to 50 years before today.
        DateTimePicker1.Value = (DateTime.Now.AddYears(-50))

        'Set a custom format containing the string "of the year"
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "MMM dd, 'of the year' yyyy "

        ' Add the DateTimePicker to the form.
        Me.Controls.Add(Me.DateTimePicker1)
    End Sub
    '</snippet1>

    '<snippet2>

    ' When the calendar drops down, display a MessageBox indicating 
    ' that DateTimePicker will not accept dates before MinDateTime or 
    ' after MaxDateTime. Use a StringBuilder object to build the string
    ' for efficiency.
    Private Sub DateTimePicker1_DropDown(ByVal sender As Object, _
        ByVal e As EventArgs) Handles DateTimePicker1.DropDown

        Dim messageBuilder As New System.Text.StringBuilder
        messageBuilder.Append("Choose a date after: ")
        messageBuilder.Append(DateTimePicker.MinDateTime.ToShortDateString)
        messageBuilder.Append(" and a date before: ")
        messageBuilder.Append(DateTimePicker.MaxDateTime.ToShortDateString)
        MessageBox.Show(messageBuilder.ToString())
    End Sub
    '</snippet2>

    
End Class
