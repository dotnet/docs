Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports WPFAquariumObjects


Namespace WPFAquarium
  ''' <summary>
  ''' Interaction logic for Window1.xaml
  ''' </summary>

  Partial Public Class Window1
	  Inherits Window

	Public Sub New()
	  InitializeComponent()

	End Sub
	  Private Sub WashMe(ByVal sender As Object, ByVal e As RoutedEventArgs)
		  Dim aq As Aquarium = TryCast(sender, Aquarium)
		  MessageBox.Show("Dirty!")
	  End Sub
	  Private Sub FireClean(ByVal sender As Object, ByVal e As RoutedEventArgs)
		  Dim aq As Aquarium = CType(Me.FindName("theAquarium"), Aquarium)
		  aq.RaiseEvent(New RoutedEventArgs(AquariumFilter.NeedsCleaningEvent))
	  End Sub
  End Class
End Namespace