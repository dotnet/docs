Option Strict On
Option Explicit On 


Imports System
Imports System.Drawing
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
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
 Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.Items.AddRange(New Object() {"Smaller", "Bigger"})
        Me.ComboBox1.Location = New System.Drawing.Point(64, 32)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(48, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 88)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Some text to change."
 'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(192, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(200, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Button2"
        '
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
 Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' The following code example demonstrates how to use the Size, 
    ' SizeInPoints, and Unit properties. This example is designed to
    ' be used with a Windows Form that contains a ComboBox named 
    ' ComboBox1.  Paste the following code into the form and  
    ' associate the ComboBox1_SelectedIndexChange method with the 
    ' SelectedIndexChanged event of the ComboBox control.

    '<snippet1> 
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        ' Cast the sender object back to a ComboBox.
        Dim ComboBox1 As ComboBox = CType(sender, ComboBox)

        ' Retrieve the selected item.
        Dim selectedString As String = CType(ComboBox1.SelectedItem, String)

        ' Convert it to lowercase.
        selectedString = selectedString.ToLower()

        ' Declare the current size.
        Dim currentSize As Single

        ' Switch on the selected item. 
        Select Case selectedString

            ' If Bigger is selected, get the current size from the 
            ' Size property and increase it. Reset the font to the
            '  new size, using the current unit.
        Case "bigger"
                currentSize = Label1.Font.Size
                currentSize += 2.0F
                Label1.Font = New Font(Label1.Font.Name, currentSize, _
                    Label1.Font.Style, Label1.Font.Unit)

                ' If Smaller is selected, get the current size, in points,
                ' and decrease it by 1.  Reset the font with the new size
                ' in points.
            Case "smaller"
                currentSize = Label1.Font.SizeInPoints
                currentSize -= 1
                Label1.Font = New Font(Label1.Font.Name, currentSize, _
                    Label1.Font.Style)
        End Select
    End Sub
    '</snippet1> 
 ' The following code example demonstrates how to use the 
    ' Font.#ctor(Font, FontStyle) constructor. To run this example, paste this code into  
    ' a Windows Form that contains a button named Button1, and associate the 
    ' Button1_Click method with the Click event of the button.
    '<snippet2>
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Font = New Font(Me.Font, FontStyle.Italic)
    End Sub
    '</snippet2>

    ' The following code example demonstrates how to use 
    ' the Font.#ctor(FontFamily, Single, FontStyle, GraphicsUnit) constructor.
    ' This example is designed to be used with Windows
    ' Forms. To run this example paste this code into a form that contains a 
    ' button named Button2, and associate the Button2_Click method with
    ' the Click event of the button. 
    '<snippet3>

    Private Sub Button2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click

        Button2.Font = New Font(FontFamily.GenericMonospace, 12.0F, _
            FontStyle.Italic, GraphicsUnit.Pixel)

    End Sub
    '</snippet3>


    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class
