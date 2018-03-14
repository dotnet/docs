' This sample can go in CheckBoxRenderer class overview. 
' - Snippet2 can go in GetGlyphSize
' - Snippet4 can go in DrawCheckBox
' - Snippet4 can also go in the VisualStyles.CheckBoxState enum, if necessary.

' The sample defines a simple custom Control that uses CheckBoxRenderer to
' simulate a CheckBox control. 
' Might want to think of a better, more realistic/solution-oriented example. 


'<Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace CheckBoxRendererSample

    Class Form1
        Inherits Form

        Public Sub New()
            Dim CheckBox1 As New CustomCheckBox()
            Controls.Add(CheckBox1)

            If Application.RenderWithVisualStyles Then
                Me.Text = "Visual Styles Enabled"
            Else
                Me.Text = "Visual Styles Disabled"
            End If
        End Sub

        <STAThread()> _
        Shared Sub Main()
            ' If you do not call EnableVisualStyles below, then 
            ' CheckBoxRenderer.DrawCheckBox automatically detects   
            ' this and draws the check box without visual styles.
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub
    End Class

    Public Class CustomCheckBox
        Inherits Control

        Private textRectangleValue As New Rectangle()
        Private clickedLocationValue As New Point()
        Private clicked As Boolean = False
        Private state As CheckBoxState = CheckBoxState.UncheckedNormal

        Public Sub New()
            With Me
                .Location = New Point(50, 50)
                .Size = New Size(100, 20)
                .Text = "Click here"
                .Font = SystemFonts.IconTitleFont
            End With
        End Sub

        '<Snippet2>
        ' Calculate the text bounds, exluding the check box.
        Public ReadOnly Property TextRectangle() As Rectangle
            Get
                Using g As Graphics = Me.CreateGraphics()
                    With textRectangleValue
                        .X = Me.ClientRectangle.X + _
                            CheckBoxRenderer.GetGlyphSize(g, _
                            CheckBoxState.UncheckedNormal).Width
                        .Y = Me.ClientRectangle.Y
                        .Width = Me.ClientRectangle.Width - _
                            CheckBoxRenderer.GetGlyphSize(g, _
                            CheckBoxState.UncheckedNormal).Width
                        .Height = Me.ClientRectangle.Height
                    End With
                End Using
                Return textRectangleValue
            End Get
        End Property
        '</Snippet2>

        '<Snippet4>
        ' Draw the check box in the current state.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            CheckBoxRenderer.DrawCheckBox(e.Graphics, _
                Me.ClientRectangle.Location, TextRectangle, Me.Text, _
                Me.Font, TextFormatFlags.HorizontalCenter, _
                clicked, state)
        End Sub

        ' Draw the check box in the checked or unchecked state, alternately.
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If Not clicked Then
                With Me
                    .clicked = True
                    .Text = "Clicked!"
                    .state = CheckBoxState.CheckedPressed
                End With
                Invalidate()
            Else
                With Me
                    .clicked = False
                    .Text = "Click here"
                    .state = CheckBoxState.UncheckedNormal
                End With
                Invalidate()
            End If
        End Sub

        '</Snippet4>
        ' Draw the check box in the hot state. 
        Protected Overrides Sub OnMouseHover(ByVal e As EventArgs)
            MyBase.OnMouseHover(e)
            If clicked Then
                state = CheckBoxState.CheckedHot
            Else
                state = CheckBoxState.UncheckedHot
            End If
            Invalidate()
        End Sub

        ' Draw the check box in the hot state. 
        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            MyBase.OnMouseUp(e)
            Me.OnMouseHover(e)
        End Sub

        ' Draw the check box in the unpressed state.
        Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
            MyBase.OnMouseLeave(e)
            If clicked Then
                state = CheckBoxState.CheckedNormal
            Else
                state = CheckBoxState.UncheckedNormal
            End If
            Invalidate()
        End Sub

    End Class
End Namespace
'</Snippet0>

