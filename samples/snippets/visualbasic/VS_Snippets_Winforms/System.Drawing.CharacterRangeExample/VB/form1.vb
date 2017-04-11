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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(40, 208)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(152, 208)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' The following code example demonstrates how to create a CharacterRange 
    ' and use it to highlight part of a string. This sample is designed to be
    ' used with Windows Forms.  Paste the example into a form and
    ' call the HighlightACharacterRange method when handling the 
    ' form's Paint event, passing e as PaintEventArgs.
    ' 
    '<snippet1>
    Private Sub HighlightACharacterRange(ByVal e As PaintEventArgs)

        ' Declare the string to draw.
        Dim message As String = _
            "This is the string to highlight a word in."

        ' Declare the word to highlight.
        Dim searchWord As String = "string"

        ' Create a CharacterRange array with the searchWord 
        ' location and length.
        Dim ranges() As CharacterRange = _
            New CharacterRange() _
                {New CharacterRange(message.IndexOf(searchWord), _
                searchWord.Length)}

        ' Construct a StringFormat object.
        Dim stringFormat1 As New StringFormat

        ' Set the ranges on the StringFormat object.
        stringFormat1.SetMeasurableCharacterRanges(ranges)

        ' Declare the font to write the message in.
        Dim largeFont As Font = New Font(FontFamily.GenericSansSerif, _
            16.0F, GraphicsUnit.Pixel)

        ' Construct a new Rectangle.
        Dim displayRectangle As New Rectangle(20, 20, 200, 100)

        ' Convert the Rectangle to a RectangleF.
        Dim displayRectangleF As RectangleF = _
            RectangleF.op_Implicit(displayRectangle)

        ' Get the Region to highlight by calling the 
        ' MeasureCharacterRanges method.
        Dim charRegion() As Region = _
            e.Graphics.MeasureCharacterRanges(message, _
            largeFont, displayRectangleF, stringFormat1)

        ' Draw the message string on the form.
        e.Graphics.DrawString(message, largeFont, Brushes.Blue, _
            displayRectangleF)

        ' Fill in the region using a semi-transparent color.
        e.Graphics.FillRegion(New SolidBrush(Color.FromArgb(50, _
            Color.Fuchsia)), charRegion(0))

    End Sub
    '</snippet1>

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e _
        As PaintEventArgs) Handles MyBase.Paint

        HighlightACharacterRange(e)
    End Sub

    ' The following code example demonstrates the Color.op_Equality operator. 
    ' This example is designed to be used with a Windows Form that  
    ' contains a button named Button1.  Paste the following code into  
    ' your form and associate the Button1_Click method with the button's
    ' Click event.
    '<snippet2>    
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        If (Color.op_Equality(Me.BackColor, SystemColors.ControlDark)) Then
            Me.BackColor = SystemColors.Control
        End If
    End Sub
    '</snippet2>

    ' The following code example demonstrates the Color.op_Inequality 
    ' operator. This example is designed to be used with a Windows Form 
    ' that contains a button named Button2.  Paste the following code 
    ' into your form and associate the Button2_Click method with the
    '  button's Click event.
    '<snippet3>
    Private Sub Button2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click

        If (Color.op_Inequality(Me.BackColor, SystemColors.ControlDark)) Then
            Me.BackColor = SystemColors.ControlDark
        End If
        If Not (Me.Font.Bold) Then
            Me.Font = New Font(Me.Font, FontStyle.Bold)
        End If
    End Sub
    '</snippet3>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class

