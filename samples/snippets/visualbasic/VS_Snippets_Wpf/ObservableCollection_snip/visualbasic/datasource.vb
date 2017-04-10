Imports System.ComponentModel
Imports System.Collections.ObjectModel

Namespace SDKSample
	''' <summary>
	''' NumberListItem. This is the class that encapsulates each item
	''' in the numberlist.  The NLValue property is the property
	''' that is bound to by UI elements in the XAML markup.
	''' </summary>
	'<Snippet1>
	Public Class NumberListItem
		Implements INotifyPropertyChanged
		Private _NLValue As Integer

		Public Sub New()
		End Sub

		Public Property NLValue() As Integer
			Get
				Return _NLValue
			End Get

			Set(ByVal value As Integer)
				If _NLValue <> value Then
					_NLValue = value
					OnPropertyChanged("NLValue")
				End If
			End Set
		End Property

		' The following variable and method provide the support for
		' handling property changed events.
		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Private Sub OnPropertyChanged(ByVal info As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
		End Sub
	End Class
	'</Snippet1>

	''' <summary>
	''' NumberList. In addition to serving as the datasource for the
	''' binding in this program, this class also exposes the methods
	''' through which a change to the list content can be initiated.
	''' </summary>
	'<Snippet3>
	Public Class NumberList
		Inherits ObservableCollection(Of NumberListItem)
		Public Sub New()
			MyBase.New()
			Add(New NumberListItem())
			Add(New NumberListItem())
			Add(New NumberListItem())
		End Sub

		Public Sub SetOdd()
			' Each of these NLValue assignments causes an OnPropertyChanged event.
			For i As Integer = 0 To Count - 1
				Dim nli As NumberListItem = CType(Me(i), NumberListItem)
				nli.NLValue = 2 * i + 1
			Next i
		End Sub

		Public Sub SetEven()
			' Each of these NLValue assignments causes an OnPropertyChanged event.
			For i As Integer = 0 To Count - 1
				Dim nli As NumberListItem = CType(Me(i), NumberListItem)
				nli.NLValue = 2 * (i + 1)
			Next i
		End Sub
		Public Sub Snip()
			'<SnippetBlockReentrancy>
			Using BlockReentrancy()
				' OnCollectionChanged call
			End Using
			'</SnippetBlockReentrancy>
		End Sub
	End Class
	'</Snippet3>
End Namespace
