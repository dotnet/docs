Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace SimpleVisualStyleRendererSample

    Class Form1
        Inherits Form

        Public Sub New()
            Me.Size = New Size(400, 400)
            Me.BackColor = Color.WhiteSmoke
            Me.Controls.Add(New CustomControl())
        End Sub

        <STAThread()> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub
    End Class

    Public Class CustomControl
        Inherits Control

        ' <Snippet4>
        Private renderer As VisualStyleRenderer = Nothing
        Private element As VisualStyleElement = _
            VisualStyleElement.StartPanel.LogOffButtons.Normal

        Public Sub New()
            Me.Location = New Point(50, 50)
            Me.Size = New Size(200, 200)
            Me.BackColor = SystemColors.ActiveBorder

            If Application.RenderWithVisualStyles And _
                VisualStyleRenderer.IsElementDefined(element) Then
                    renderer = New VisualStyleRenderer(element)
            End If
        End Sub
        ' </Snippet4>

        ' <Snippet6>
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            ' Draw the element if the renderer has been set.
            If (renderer IsNot Nothing) Then
                renderer.DrawBackground(e.Graphics, Me.ClientRectangle)

            ' Visual styles are disabled or the element is undefined, 
            ' so just draw a message.
            Else
                Me.Text = "Visual styles are disabled."
                TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, _
                    New Point(0, 0), Me.ForeColor)
            End If
        End Sub
        ' </Snippet6>

    End Class
End Namespace