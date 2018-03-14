Imports System.ComponentModel
Imports System.Collections.ObjectModel

Namespace SDKSample
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnOdd(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Get the NumberList via the DataContext of the passed element.
			Dim fe As FrameworkElement = CType(sender, FrameworkElement)
			Dim nl As NumberList = CType(fe.DataContext, NumberList)

			' Tell the NumberList to set itself to odd values.
			nl.SetOdd()
		End Sub

		' UI Event handler for btnEven
		Private Sub btnEven(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Get the NumberList by finding its Data Source Object.
			Dim fe As FrameworkElement = CType(sender, FrameworkElement)
			Dim odp As ObjectDataProvider = CType(fe.FindResource("NumberListDSO"), ObjectDataProvider)
			Dim nl As NumberList = CType(odp.Data, NumberList)

			' Tell the NumberList to set itself to even values.
			nl.SetEven()
		End Sub

	End Class

End Namespace
