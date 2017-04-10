Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Input
Imports System.Windows.Media

Namespace BrushesIntroduction

	''' <summary>
	''' Implements the show/hide gradient stops functionlity for
	''' GradientBrushesExample.xaml.
	''' </summary>
	Partial Public Class GradientBrushesExample
		Inherits Page


	   Public Sub New()
			InitializeComponent()

	   End Sub

	   Private Sub pageLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
			AddHandler showHideGradientStopsCheckBox.Checked, AddressOf showGradientStops
			AddHandler showHideGradientStopsCheckBox.Unchecked, AddressOf hideGradientStops

	   End Sub

	   Private Sub showGradientStops(ByVal sender As Object, ByVal args As RoutedEventArgs)
			   gradientLine1.Opacity = 1.0
			   gradientLine2.Opacity = 1.0
			   gradientLine3.Opacity = 1.0
			   gradientLine4.Opacity = 1.0
			   gradientLine5.Opacity = 1.0
			   gradientPath1.Opacity = 1.0
			   gradientPath2.Opacity = 1.0
			   gradientPath3.Opacity = 1.0
			   gradientPath4.Opacity = 1.0
			   gradientPath5.Opacity = 1.0
	   End Sub

	   Private Sub hideGradientStops(ByVal sender As Object, ByVal args As RoutedEventArgs)

			   gradientLine1.Opacity = 0.0
			   gradientLine2.Opacity = 0.0
			   gradientLine3.Opacity = 0.0
			   gradientLine4.Opacity = 0.0
			   gradientLine5.Opacity = 0.0
			   gradientPath1.Opacity = 0.0
			   gradientPath2.Opacity = 0.0
			   gradientPath3.Opacity = 0.0
			   gradientPath4.Opacity = 0.0
			   gradientPath5.Opacity = 0.0
	   End Sub

	End Class

End Namespace