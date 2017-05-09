'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Public Module ToolTipExampleApp
    ' The main entry point for the application.
    <STAThread()> _
    Sub Main()
        Application.Run(New ToolTipExampleForm)
    End Sub
End Module

' Form for the ToolTip example.
Public Class ToolTipExampleForm
    Inherits System.Windows.Forms.Form

    Private WithEvents toolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button3 As System.Windows.Forms.Button

    Public Sub New()
        ' Create the ToolTip and set initial values.
        Me.toolTip1 = New System.Windows.Forms.ToolTip
        Me.toolTip1.AutoPopDelay = 5000
        Me.toolTip1.InitialDelay = 500
        Me.toolTip1.OwnerDraw = True
        Me.toolTip1.ReshowDelay = 10

        ' Create button1 and set initial values.
        Me.button1 = New System.Windows.Forms.Button
        Me.button1.Location = New System.Drawing.Point(8, 8)
        Me.button1.Text = "Button 1"
        Me.toolTip1.SetToolTip(Me.button1, "Button1 tip text")

        ' Create button2 and set initial values.
        Me.button2 = New System.Windows.Forms.Button
        Me.button2.Location = New System.Drawing.Point(8, 32)
        Me.button2.Text = "Button 2"
        Me.toolTip1.SetToolTip(Me.button2, "Button2 tip text")

        ' Create button3 and set initial values.
        Me.button3 = New System.Windows.Forms.Button
        Me.button3.Location = New System.Drawing.Point(8, 56)
        Me.button3.Text = "Button 3"
        Me.toolTip1.SetToolTip(Me.button3, "Button3 tip text")

        ' Set up the Form.
        Me.Controls.AddRange(New Control() {Me.button1, _
                                            Me.button2, _
                                            Me.button3})
        Me.Text = "owner drawn ToolTip example"
    End Sub

    ' Clean up any resources being used.        
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing) Then
            toolTip1.Dispose()
        End If

        MyBase.Dispose(disposing)
    End Sub

    ' Determines the correct size for the button2 ToolTip.
    Private Sub toolTip1_Popup(ByVal sender As System.Object, _
        ByVal e As PopupEventArgs) Handles toolTip1.Popup

        If e.AssociatedControl Is button2 Then

            Dim f As New Font("Tahoma", 9)
            Try
                e.ToolTipSize = TextRenderer.MeasureText( _
                    toolTip1.GetToolTip(e.AssociatedControl), f)
            Finally
                f.Dispose()
            End Try

        End If
    End Sub

    '<Snippet5>
    ' Handles drawing the ToolTip.
    Private Sub toolTip1_Draw(ByVal sender As System.Object, _
        ByVal e As DrawToolTipEventArgs) Handles toolTip1.Draw
        ' Draw the ToolTip differently depending on which 
        ' control this ToolTip is for.

        '<Snippet2>
        ' Draw a custom 3D border if the ToolTip is for button1.
        If (e.AssociatedControl Is button1) Then
            ' Draw the standard background.
            e.DrawBackground()

            ' Draw the custom border to appear 3-dimensional.
            e.Graphics.DrawLines( _
                SystemPens.ControlLightLight, New Point() { _
                New Point(0, e.Bounds.Height - 1), _
                New Point(0, 0), _
                New Point(e.Bounds.Width - 1, 0)})
            e.Graphics.DrawLines( _
                SystemPens.ControlDarkDark, New Point() { _
                New Point(0, e.Bounds.Height - 1), _
                New Point(e.Bounds.Width - 1, e.Bounds.Height - 1), _
                New Point(e.Bounds.Width - 1, 0)})

            ' Specify custom text formatting flags.
            Dim sf As TextFormatFlags = TextFormatFlags.VerticalCenter Or _
                                 TextFormatFlags.HorizontalCenter Or _
                                 TextFormatFlags.NoFullWidthCharacterBreak

            ' Draw standard text with customized formatting options.
            e.DrawText(sf)
            '</Snippet2>
            '<Snippet3>
        ElseIf (e.AssociatedControl Is button2) Then
            ' Draw a custom background and text if the ToolTip is for button2.

            ' Draw the custom background.
            e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds)

            ' Draw the standard border.
            e.DrawBorder()

            ' Draw the custom text.
            Dim sf As StringFormat = New StringFormat
            Try
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center
                sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None
                sf.FormatFlags = StringFormatFlags.NoWrap

                Dim f As Font = New Font("Tahoma", 9)
                Try
                    e.Graphics.DrawString(e.ToolTipText, f, _
                        SystemBrushes.ActiveCaptionText, _
                        RectangleF.op_Implicit(e.Bounds), sf)
                Finally
                    f.Dispose()
                End Try
            Finally
                sf.Dispose()
            End Try
            '</Snippet3>
            '<Snippet4>
        ElseIf (e.AssociatedControl Is button3) Then
            ' Draw the ToolTip using default values if the ToolTip is for button3.
            e.DrawBackground()
            e.DrawBorder()
            e.DrawText()
        End If
        '</Snippet4>
    End Sub
    '</Snippet5>
End Class
'</Snippet1>