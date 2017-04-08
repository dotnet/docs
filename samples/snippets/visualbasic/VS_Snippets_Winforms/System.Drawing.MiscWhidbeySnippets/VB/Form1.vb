
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms


Class Form1
    Inherits Form
     
    Public Sub New() 

        CharacterRangeInequality()
    End Sub
     
    
    Sub Form1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) _
        Handles Me.Paint

        'DrawImageUnscaled(e);
        'OffsetPoint(e);
        'SubtractSizes(e);
        DrawWithAppWorkspacePen(e)

    End Sub
    
    
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub 'Main
    
    
    '<snippet1>
    Private Sub CharacterRangeEquality1() 
        
        ' Declare the string to draw.
        Dim message As String = "Strings or strings; that is the question."
        
        ' Compare the ranges for equality. The should not be equal.
        Dim range1 As New CharacterRange(message.IndexOf("Strings"), _
            "Strings".Length)
        Dim range2 As New CharacterRange(message.IndexOf("strings"), _
            "strings".Length)
        
        If range1 = range2 Then
            MessageBox.Show("The ranges are equal.")
        Else
            MessageBox.Show("The ranges are not equal.")
        End If
     
    End Sub
    
    '</snippet1>
    '<snippet2>
    Private Sub CharacterRangeEquality2() 
        
        ' Declare the string to draw.
        Dim message As String = "Strings or strings; that is the question."
        
        ' Compare the ranges for equality. The should not be equal.
        Dim range1 As New CharacterRange(message.IndexOf("Strings"), _
            "Strings".Length)
        Dim range2 As New CharacterRange(message.IndexOf("strings"), _
            "strings".Length)
        
        If range1.Equals(range2) Then
            MessageBox.Show("The ranges are equal.")
        Else
            MessageBox.Show("The ranges are not equal.")
        End If
     
    End Sub
    '</snippet2>

    '<snippet3>
    Private Sub CharacterRangeInequality() 
        
        ' Declare the string to draw.
        Dim message As String = "Strings or strings; that is the question."
        
        ' Compare the ranges for equality. The should not be equal.
        Dim range1 As New CharacterRange(message.IndexOf("Strings"), "Strings".Length)
        Dim range2 As New CharacterRange(message.IndexOf("string"), "strings".Length)
        
        If range1 <> range2 Then
            MessageBox.Show("The ranges are not equal.")
        Else
            MessageBox.Show("The ranges are equal.")
        End If
    End Sub
    '</snippet3>

    '<snippet4>
    Private Sub CopyPixels1(ByVal e As PaintEventArgs) 
        e.Graphics.CopyFromScreen(Me.Location, _
            New Point(40, 40), New Size(100, 100))
    
    End Sub
    '</snippet4>

    '<snippet5>
    Private Sub CopyPixels2(ByVal e As PaintEventArgs) 
        e.Graphics.CopyFromScreen(Me.Location, _
            New Point(40, 40), New Size(100, 100), _
            CopyPixelOperation.MergePaint)
    End Sub
    '</snippet5>

    '<snippet6>
    Private Sub CopyPixels3(ByVal e As PaintEventArgs) 
        e.Graphics.CopyFromScreen(0, 0, 20, 20, New Size(160, 160))
    End Sub
    '</snippet6>

    '<snippet7>
    Private Sub CopyPixels4(ByVal e As PaintEventArgs) 
        e.Graphics.CopyFromScreen(0, 0, 20, 20, _
            New Size(160, 160), CopyPixelOperation.SourceInvert)
    End Sub
    '</snippet7>

    '<snippet8>
    Private Sub DrawImageUnscaled(ByVal e As PaintEventArgs) 
        Dim filepath As String = "C:\Documents and Settings\All Users\Documents\" _
            & "My Pictures\Sample Pictures\Water Lilies.jpg"
        Dim bitmap1 As New Bitmap(filepath)
        e.Graphics.DrawImageUnscaledAndClipped(bitmap1, _
            New Rectangle(10, 10, 250, 250))
    End Sub
    '</snippet8>

    '<snippet9>
    Private Sub AddPoint(ByVal e As PaintEventArgs) 
        Dim point1 As New Point(10, 10)
        Dim point2 As Point = Point.Add(point1, New Size(250, 0))
        e.Graphics.DrawLine(Pens.Red, point1, point2)
    
    End Sub
    '</snippet9>

    '<snippet10>
    Private Sub OffsetPoint(ByVal e As PaintEventArgs) 
        Dim point1 As New Point(10, 10)
        point1.Offset(50, 0)
        Dim point2 As New Point(250, 10)
        e.Graphics.DrawLine(Pens.Red, point1, point2)
    End Sub
    '</snippet10>

    '<snippet11>
    Private Sub AddSizes(ByVal e As PaintEventArgs) 
        Dim size1 As New Size(100, 100)
        Dim size2 As New Size(50, 50)
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(New Point(10, 10), size1))
        size1 = System.Drawing.Size.Add(size1, size2)
        e.Graphics.DrawRectangle(Pens.Red, New Rectangle(New Point(10, 10), size1))
    
    End Sub
    '</snippet11>

    '<snippet12>
    Private Sub SubtractSizes(ByVal e As PaintEventArgs) 
        Dim size1 As New Size(100, 100)
        Dim size2 As New Size(50, 50)
        e.Graphics.DrawRectangle(Pens.Black, _
            New Rectangle(New Point(10, 10), size1))
        size1 = System.Drawing.Size.Subtract(size1, size2)
        e.Graphics.DrawRectangle(Pens.Red, _
            New Rectangle(New Point(10, 10), size1))
    
    End Sub
    '</snippet12>

    '<snippet13>
    Private Sub DrawWithActiveBorderPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.ActiveBorder, rectangle1)
    
    End Sub
    
    '</snippet13>
    '<snippet14>
    Private Sub DrawWithActiveCaptionPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.ActiveCaption, rectangle1)
    
    End Sub
    
    '</snippet14>
    '<snippet15>
    Private Sub DrawWithAppWorkspacePen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.AppWorkspace, rectangle1)
    
    End Sub
    '</snippet15>

    '<snippet16>
    Private Sub DrawWithButtonFacePen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.ButtonFace, rectangle1)
    
    End Sub
    
    '</snippet16>
    '<snippet17>
    Private Sub DrawWithButtonHighlightPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.ButtonHighlight, rectangle1)
    
    End Sub
    '</snippet17>
    '<snippet18>
    Private Sub DrawWithButtonShadowPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.ButtonShadow, rectangle1)
    
    End Sub
    
    '</snippet18>
    '<snippet19>
    Private Sub DrawWithControlPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.Control, rectangle1)
    
    End Sub
    
    '</snippet19>
    '<snippet20>
    Private Sub DrawWithControlDarkPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.ControlDark, rectangle1)
    
    End Sub
    
    '</snippet20>
    '<snippet21>
    Private Sub DrawWithControlDarkDarkPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.ControlDarkDark, rectangle1)
    
    End Sub
    
    '</snippet21>
    '<snippet22>
    Private Sub DrawWithControlLightPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.ControlLight, rectangle1)
    
    End Sub
    
    '</snippet22>
    '<snippet23>
    Private Sub DrawWithControlLightLightPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.ControlLightLight, rectangle1)
    
    End Sub
    
    '</snippet23>
    '<snippet24>
    Private Sub DrawWithControlTextPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.ControlText, rectangle1)
    
    End Sub
    
    '</snippet24>
    '<snippet25>
    Private Sub DrawWithControlDesktopPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.Desktop, rectangle1)
    
    End Sub
    
    '</snippet25>
    '<snippet26>
    Private Sub DrawWithGradientActiveCaptionPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.GradientActiveCaption, rectangle1)
    
    End Sub
    
    '</snippet26>
    '<snippet27>
    Private Sub DrawWithGradientInactiveCaptionPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.GradientInactiveCaption, rectangle1)
    
    End Sub
    
    '</snippet27>
    '<snippet28>
    Private Sub DrawWithGrayTextPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.GrayText, rectangle1)
    
    End Sub
    
    '</snippet28>
    '<snippet29>
    Private Sub DrawWithHighlightPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.Highlight, rectangle1)
    
    End Sub
    
    '</snippet29>
    '<snippet30>
    Private Sub DrawWithHighlightTextPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.HighlightText, rectangle1)
    
    End Sub
    
    '</snippet30>
    '<snippet31>
    Private Sub DrawWithHotTrackPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.HotTrack, rectangle1)
    
    End Sub
    
    '</snippet31>
    '<snippet32>
    Private Sub DrawWithInactiveBorderPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.InactiveBorder, rectangle1)
    
    End Sub
    
    '</snippet32>
    '<snippet33>
    Private Sub DrawWithInactiveCaptionPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.InactiveCaption, rectangle1)
    
    End Sub
    
    '</snippet33>
    '<snippet34>
    Private Sub DrawWithInactiveCaptionTextPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.InactiveCaptionText, rectangle1)
    
    End Sub
    
    '</snippet34>
    '<snippet35>
    Private Sub DrawWithInfoPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.Info, rectangle1)
    
    End Sub
    
    '</snippet35>
    '<snippet36>
    Private Sub DrawWithInfoTextPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.InfoText, rectangle1)
    
    End Sub
    
    '</snippet36>
    '<snippet37>
    Private Sub DrawWithMenuPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.Menu, rectangle1)
    
    End Sub
    
    '</snippet37>
    '<snippet38>
    Private Sub DrawWithMenuBarPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.MenuBar, rectangle1)
    
    End Sub
    
    '</snippet38>
    '<snippet39>
    Private Sub DrawWithMenuHighlightPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.MenuHighlight, rectangle1)
    
    End Sub
    
    '</snippet39>
    '<snippet40>
    Private Sub DrawWithMenuTextPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.MenuText, rectangle1)
    
    End Sub
    
    '</snippet40>
    '<snippet41>
    Private Sub DrawWithScrollBarPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.ScrollBar, rectangle1)
    
    End Sub
    
    '</snippet41>
    '<snippet42>
    Private Sub DrawWithWindowPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.Window, rectangle1)
    
    End Sub
    
    '</snippet42>
    '<snippet44>
    Private Sub DrawWithWindowFramePen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.WindowFrame, rectangle1)
    
    End Sub
    
    '</snippet44>
    '<snippet45>
    Private Sub DrawWithWindowTextPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.WindowText, rectangle1)
    
    End Sub
End Class
'</snippet45>

