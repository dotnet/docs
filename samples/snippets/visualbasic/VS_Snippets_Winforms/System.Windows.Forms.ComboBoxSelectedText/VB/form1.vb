Option Strict On
Option Explicit On 


Imports System.Windows.Forms
Imports System.Drawing
Imports System

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitalizeComboBoxAndTextBoxes()
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
        'ComboBox1
        '

        '
        'TextBox1
        '

        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)


        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Friend WithEvents comboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents textbox1 As System.Windows.Forms.TextBox


    Private Sub InitalizeComboBoxAndTextBoxes()
        Me.comboBox1 = New System.Windows.Forms.ComboBox
        Me.comboBox1.Location = New Point(25, 150)
        Me.comboBox1.Width = 150

        Me.textbox1 = New System.Windows.Forms.TextBox
        textbox1.Location = New Point(25, 50)
        textbox1.Name = "selectedTextBox"
        textbox1.Size = New Size(25, 15)

        Dim namespaces() As String = New String() { _
            "System.Windows.Forms", "System.Net", "System.Reflection", _
            "System.Drawing"}

        Dim aNamespace As String
        For Each aNamespace In namespaces
            comboBox1.Items.Add(aNamespace & ", " & aNamespace.Length + 4)
        Next

        Me.Controls.Add(Me.textbox1)
        Me.Controls.Add(Me.comboBox1)
    End Sub

    ' The following code example demonstrates the handling of the 
    ' SelectionChangeCommitted event. This example uses the 
    ' SelectionLength property to set the width of a text box that 
    ' displays the SelectedText. Since the SelectionLength and
    ' SelectedText properties reflect the currently selected  
    ' (not newly selected) text, they will lag behind what is currently
    ' displayed in the text portion of the ComboBox control. To run  
    ' this example,paste the following code into a form that contains 
    ' a ComboBox named comboBox1 and is populated with strings. 
    ' The form should also contain a text box named textbox1.  
    ' Ensure the SelectionChangedEvent is associated with the  
    ' event-handling method in this example.

    '<snippet1>
    Private Sub comboBox1_SelectionChangeCommitted(ByVal sender _
    As Object, ByVal e As EventArgs) _
    Handles comboBox1.SelectionChangeCommitted

        Dim senderComboBox As ComboBox = CType(sender, ComboBox)

        ' Change the length of the text box depending on what the user has 
        ' selected and committed using the SelectionLength property.
        If (senderComboBox.SelectionLength > 0) Then
            textbox1.Width = _
                senderComboBox.SelectedItem.ToString().Length() * _
                CType(Me.textbox1.Font.SizeInPoints, Integer)
            textbox1.Text = senderComboBox.SelectedItem.ToString()
        End If
    End Sub
    '</snippet1>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
