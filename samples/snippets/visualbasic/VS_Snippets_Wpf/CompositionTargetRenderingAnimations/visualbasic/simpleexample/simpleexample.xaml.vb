Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace Microsoft.Samples.PerFrameAnimations
	''' <summary>
	''' Interaction logic for Page1.xaml
	''' </summary>

	Partial Public Class SimpleExample
		Inherits Page
		Private rand As New Random()

		Public Sub New()
            MyBase.New()
            InitializeComponent()
			AddHandler CompositionTarget.Rendering, AddressOf UpdateColor
		End Sub

		Private Sub UpdateColor(ByVal sender As Object, ByVal e As EventArgs)
			' Set a random color
			animatedBrush.Color = Color.FromRgb(CByte(rand.Next(255)), CByte(rand.Next(255)), CByte(rand.Next(255)))
		End Sub
	End Class
End Namespace