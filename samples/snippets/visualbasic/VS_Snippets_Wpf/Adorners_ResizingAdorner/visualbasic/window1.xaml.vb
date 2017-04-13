Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
  Partial Public Class Window1
	  Inherits Window
	Private adornerLayer As AdornerLayer

	Public Sub New()
	  InitializeComponent()
	End Sub

	' To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
	Private Sub WindowLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
	  adornerLayer = AdornerLayer.GetAdornerLayer(elementsGrid)

	  For Each toAdorn As Panel In elementsGrid.Children
		adornerLayer.Add(New ResizingAdorner(toAdorn.Children(0)))
	  Next toAdorn
	End Sub
  End Class
End Namespace