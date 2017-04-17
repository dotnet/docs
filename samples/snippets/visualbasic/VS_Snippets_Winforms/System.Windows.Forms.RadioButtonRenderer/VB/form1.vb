' This sample can go in RadioButtonRenderer class overview
' - Snippet2 can go in GetGlyphSize
' - Snippet4 can go in DrawRadioButton.
' - Snippet4 can also go in RadioButtonState enum, if necessary.

' This sample mimics the RadioButton control. Might want to come up with a better
' customization sample that actually does something different from the RadioButton.


'<Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace RadioButtonRendererSample

    Class Form1
        Inherits Form

        Dim WithEvents button1 As Button

        Public Sub New()
            Dim RadioButton1 As New CustomRadioButton()
            button1 = New Button
            Me.button1.Location = New System.Drawing.Point(185, 231)
            Me.button1.Size = New System.Drawing.Size(105, 23)
            Me.button1.Text = "Toggle Styles"
            Controls.Add(RadioButton1)
            Controls.Add(button1)

            If Application.RenderWithVisualStyles Then
                Me.Text = "Visual Styles Enabled"
            Else
                Me.Text = "Visual Styles Disabled"
            End If
        End Sub

        <STAThread()> _
        Shared Sub Main()
            ' If you do not call EnableVisualStyles below, then 
            ' RadioButtonRenderer.DrawRadioButton automatically detects 
            ' this and draws the radio button without visual styles.
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub

        '<snippet3>
        ' Match application style and toggle visual styles off
        ' and on for the application.
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles button1.Click

            RadioButtonRenderer.RenderMatchingApplicationState = True

            Application.VisualStyleState = _
                Application.VisualStyleState Xor _
                VisualStyleState.ClientAndNonClientAreasEnabled

            If Application.RenderWithVisualStyles Then
                Me.Text = "Visual Styles Enabled"
            Else
                Me.Text = "Visual Styles Disabled"
            End If

        End Sub
        '</snippet3>
    End Class

    Public Class CustomRadioButton
        Inherits Control

        Private textRectangleValue As New Rectangle()
        Private clicked As Boolean = False
        Private state As RadioButtonState = RadioButtonState.UncheckedNormal

        Public Sub New()
            With Me
                .Location = New Point(50, 50)
                .Size = New Size(100, 20)
                .Text = "Click here"
                .Font = SystemFonts.IconTitleFont
            End With
        End Sub 'New

        '<Snippet2>
        ' Define the text bounds so that the text rectangle 
        ' does not include the radio button.
        Public ReadOnly Property TextRectangle() As Rectangle
            Get
                Using g As Graphics = Me.CreateGraphics()
                    With textRectangleValue
                        .X = Me.ClientRectangle.X + _
                            RadioButtonRenderer.GetGlyphSize(g, _
                            RadioButtonState.UncheckedNormal).Width
                        .Y = Me.ClientRectangle.Y
                        .Width = Me.ClientRectangle.Width - _
                            RadioButtonRenderer.GetGlyphSize(g, _
                            RadioButtonState.UncheckedNormal).Width
                        .Height = Me.ClientRectangle.Height
                    End With
                End Using
                Return textRectangleValue
            End Get
        End Property
        '</Snippet2>

        '<Snippet4>
        ' Draw the radio button in the current state.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            RadioButtonRenderer.DrawRadioButton(e.Graphics, _
                Me.ClientRectangle.Location, TextRectangle, Me.Text, _
                Me.Font, clicked, state)
        End Sub

        ' Draw the radio button in the checked or unchecked state.
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            If Not clicked Then
                clicked = True
                Me.Text = "Clicked!"
                state = RadioButtonState.CheckedPressed
                Invalidate()
            Else
                clicked = False
                Me.Text = "Click here"
                state = RadioButtonState.UncheckedNormal
                Invalidate()
            End If

        End Sub
        '</Snippet4>

        ' Draw the radio button in the hot state. 
        Protected Overrides Sub OnMouseHover(ByVal e As EventArgs)
            MyBase.OnMouseHover(e)

            If clicked Then
                state = RadioButtonState.CheckedHot
            Else
                state = RadioButtonState.UncheckedHot
            End If
            Invalidate()
        End Sub

        ' Draw the radio button in the hot state.
        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            MyBase.OnMouseUp(e)
            Me.OnMouseHover(e)
        End Sub

        ' Draw the radio button in the unpressed state.
        Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
            MyBase.OnMouseLeave(e)

            If clicked Then
                state = RadioButtonState.CheckedNormal
            Else
                state = RadioButtonState.UncheckedNormal
            End If
            Invalidate()
        End Sub

    End Class
End Namespace
'</Snippet0>

