

' Snippet for: M:System.Drawing.ImageAnimator.Animate(System.Drawing.Image,System.EventHandler)
' <snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class animateImage
    Inherits Form

    'Create a Bitmpap Object.
    Private animatedImage As New Bitmap("SampleAnimation.gif")
    Private currentlyAnimating As Boolean = False

    'This method begins the animation.
    Public Sub AnimateImage()
        If Not currentlyAnimating Then

            'Begin the animation only once.
            ImageAnimator.Animate(animatedImage, _
            New EventHandler(AddressOf Me.OnFrameChanged))
            currentlyAnimating = True
        End If
    End Sub

    Private Sub OnFrameChanged(ByVal o As Object, ByVal e As EventArgs)

        'Force a call to the Paint event handler.
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        'Begin the animation.
        AnimateImage()

        'Get the next frame ready for rendering.
        ImageAnimator.UpdateFrames()

        'Draw the next frame in the animation.
        e.Graphics.DrawImage(Me.animatedImage, New Point(0, 0))
    End Sub

    Public Shared Sub Main()
        Application.Run(New AnimateImage)
    End Sub
End Class
' </snippet1>

