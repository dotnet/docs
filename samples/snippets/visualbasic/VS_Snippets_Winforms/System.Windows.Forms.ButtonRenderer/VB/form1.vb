' This entire sample can go in the ButtonRenderer overview. 
'  - Snippet2 can be excerpted in ButtonRenderer.DrawBackground overload
'    and specific ButtonRenderer.DrawBackground that it uses.
'  - Snippet4 can be linked to in ButtonRenderer.DrawParentBackground
'  - Snippet2 could be excerpted in the VisualStyles.PushButtonState enum,
'    if necessary.

' The sample defines a simple custom Control that uses ButtonRenderer to
' simulate a real Button control. When clicked, it draws a smaller button
' and uses DrawParentBackground to erase the remainder of the unpressed
' button.

' Issue: to show using DrawParentBackground, I'm currently setting the BackColor
' of the custom control to something other than the parent form. There might be
' a better way of demonstrating this that makes more sense from a usability standpoint...


'<Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace ButtonRendererSample
    Class Form1
        Inherits Form

        Public Sub New()
            Dim Button1 As New CustomButton()
            Controls.Add(Button1)

            If Application.RenderWithVisualStyles Then
                Me.Text = "Visual Styles Enabled"
            Else
                Me.Text = "Visual Styles Disabled"
            End If
        End Sub

        <STAThread()> _
        Shared Sub Main()
            ' If you do not call EnableVisualStyles below, then  
            ' ButtonRenderer automatically detects this and draws
            ' the button without visual styles.
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub
    End Class

    Public Class CustomButton
        Inherits Control

        Private clickRectangleValue As New Rectangle()
        Private state As PushButtonState = PushButtonState.Normal

        Public Sub New()
            With Me
                Size = New Size(100, 40)
                Location = New Point(50, 50)
                Font = SystemFonts.IconTitleFont
                Text = "Click here"
            End With
        End Sub

        ' Define the bounds of the smaller pressed button.
        Public ReadOnly Property ClickRectangle() As Rectangle
            Get
                With clickRectangleValue
                    .X = Me.ClientRectangle.X + CInt(0.2 * _
                        Me.ClientRectangle.Width)
                    .Y = Me.ClientRectangle.Y + CInt(0.2 * _
                        Me.ClientRectangle.Height)
                    .Width = Me.ClientRectangle.Width - _
                        CInt(0.4 * Me.ClientRectangle.Width)
                    .Height = Me.ClientRectangle.Height - _
                        CInt(0.4 * Me.ClientRectangle.Height)
                End With
                Return clickRectangleValue
            End Get
        End Property

        '<Snippet2>
        '<Snippet4>
        ' Draw the large or small button, depending on the current state.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            ' Draw the smaller pressed button image.
            If state = PushButtonState.Pressed Then
                ' Set the background color to the parent if visual styles  
                ' are disabled, because DrawParentBackground will only paint  
                ' over the control background if visual styles are enabled.
                If Application.RenderWithVisualStyles Then
                    Me.BackColor = Color.Azure
                Else
                    Me.BackColor = Me.Parent.BackColor
                End If

                ' If you comment out the call to DrawParentBackground,   
                ' the background of the control will still be visible 
                ' outside the pressed button, if visual styles are enabled.
                ButtonRenderer.DrawParentBackground(e.Graphics, _
                    Me.ClientRectangle, Me)
                ButtonRenderer.DrawButton(e.Graphics, ClickRectangle, _
                    Me.Text, Me.Font, True, state)

            ' Draw the bigger unpressed button image.
            Else
                ButtonRenderer.DrawButton(e.Graphics, Me.ClientRectangle, _
                    Me.Text, Me.Font, False, state)
            End If
        End Sub
        '</Snippet4>

        ' Draw the smaller pressed button image.
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            With Me
                .Text = "Clicked!"
                .state = PushButtonState.Pressed
            End With
            Invalidate()
        End Sub

        ' Draw the button in the hot state. 
        Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
            MyBase.OnMouseEnter(e)
            With Me
                .Text = "Click here"
                .state = PushButtonState.Hot
            End With
            Invalidate()
        End Sub

        ' Draw the button in the unpressed state.
        Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
            MyBase.OnMouseLeave(e)
            With Me
                .Text = "Click here"
                .state = PushButtonState.Normal
            End With
            Invalidate()
        End Sub
        '</Snippet2>

        ' Draw the button hot if the mouse is released on the button.
        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            MyBase.OnMouseUp(e)
            OnMouseEnter(e)
        End Sub

        ' Detect when the cursor leaves the button area while it 
        ' is pressed.
        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            MyBase.OnMouseMove(e)

            ' Detect when the left mouse button is down and   
            ' the cursor has left the pressed button area. 
            If (e.Button And MouseButtons.Left) = MouseButtons.Left And Not _
                Me.ClientRectangle.Contains(e.Location) And _
                state = PushButtonState.Pressed Then
                OnMouseLeave(e)
            End If
        End Sub

    End Class
End Namespace
'</Snippet0>