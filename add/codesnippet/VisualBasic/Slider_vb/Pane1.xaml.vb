Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media

Namespace Slider_vb
	
    Partial Public Class Pane1
        Inherits StackPanel
        Public Sub New()
            InitializeComponent()

            CreateBasicSlider()
            CreateSelectionRangeSlider()
        End Sub

        Private Sub CreateBasicSlider()
            '<SnippetBasic> 
            Dim hslider As New Slider()
            hslider.Width = 100
            hslider.Orientation = Orientation.Horizontal
            hslider.IsSnapToTickEnabled = True
            hslider.Minimum = 1
            hslider.Maximum = 20
            hslider.TickPlacement = TickPlacement.Both
            hslider.TickFrequency = 2
            hslider.AutoToolTipPlacement = AutoToolTipPlacement.BottomRight
            cv1.Children.Add(hslider)
            '</SnippetBasic> 
        End Sub

        Private Sub CreateSelectionRangeSlider()
            '<SnippetSelectionRange> 
            Dim hslider As New Slider()
            hslider.Orientation = Orientation.Horizontal
            hslider.Width = 100
            hslider.Minimum = 1
            hslider.Maximum = 10
            hslider.IsDirectionReversed = True
            hslider.IsMoveToPointEnabled = True
            hslider.AutoToolTipPrecision = 2
            hslider.AutoToolTipPlacement = AutoToolTipPlacement.BottomRight
            hslider.TickPlacement = TickPlacement.BottomRight
            Dim tickMarks As New DoubleCollection()
            tickMarks.Add(0.5)
            tickMarks.Add(1.5)
            tickMarks.Add(2.5)
            tickMarks.Add(3.5)
            tickMarks.Add(4.5)
            tickMarks.Add(5.5)
            tickMarks.Add(6.5)
            tickMarks.Add(7.5)
            tickMarks.Add(8.5)
            tickMarks.Add(9.5)
            hslider.Ticks = tickMarks
            hslider.IsSelectionRangeEnabled = True
            hslider.SelectionStart = 2.5
            hslider.SelectionEnd = 7.5
            cv2.Children.Add(hslider)
            '</SnippetSelectionRange> 
        End Sub
    End Class
End Namespace