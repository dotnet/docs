'------------------------------------------------------------------------------

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Data
Imports System.Windows.Input

Namespace SDKSample
  '<Snippet1>
  Partial Public Class CollectionViewSample
	Public myCollectionView As CollectionView
	Public o As Order

	Public Sub StartHere(ByVal sender As Object, ByVal args As DependencyPropertyChangedEventArgs)
	  '<Snippet2>
	  myCollectionView = CType(CollectionViewSource.GetDefaultView(rootElem.DataContext), CollectionView)
	  '</Snippet2>
	End Sub

	'<SnippetOnButton>
	'OnButton is called whenever the Next or Previous buttons
	'are clicked to change the currency
	  Private Sub OnButton(ByVal sender As Object, ByVal args As RoutedEventArgs)
		  Dim b As Button = TryCast(sender, Button)

		  Select Case b.Name
			  '<SnippetCollectionViewPrevious>
			  Case "Previous"
				  myCollectionView.MoveCurrentToPrevious()

				  If myCollectionView.IsCurrentBeforeFirst Then
					  myCollectionView.MoveCurrentToLast()
				  End If
			  '</SnippetCollectionViewPrevious>

			  '<SnippetCollectionViewNext>
			  Case "Next"
				  myCollectionView.MoveCurrentToNext()
				  If myCollectionView.IsCurrentAfterLast Then
					  myCollectionView.MoveCurrentToFirst()
				  End If
				  Exit Select
			  '</SnippetCollectionViewNext>

			  o = TryCast(myCollectionView.CurrentItem, Order)
			  ' TODO: do something with the current Order o 
		  End Select
	  End Sub
	'</SnippetOnButton>

  End Class
  '</Snippet1>
End Namespace
