Imports System.Collections.ObjectModel
Imports System.ComponentModel

Namespace SDKSample
	Public Class AuctionItem
		Implements INotifyPropertyChanged
        Private _description As String
        Private _images As ObservableCollection(Of String)
        Private _specialFeatures As SpecialFeatures
        Private _currentPrice As Integer


		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		#Region "Properties Getters and Setters"
		Public Property Description() As String
			Get
                Return Me._description
			End Get
			Set(ByVal value As String)
                Me._description = value
				OnPropertyChanged("Description")
			End Set
		End Property


		Public ReadOnly Property Images() As ObservableCollection(Of String)
			Get
                Return Me._images
			End Get
		End Property

		Public Property SpecialFeatures() As SpecialFeatures
			Get
                Return Me._specialFeatures
			End Get
			Set(ByVal value As SpecialFeatures)
                Me._specialFeatures = value
				OnPropertyChanged("SpecialFeatures")
			End Set
		End Property

		Public Property CurrentPrice() As Integer
			Get
                Return Me._currentPrice
			End Get
			Set(ByVal value As Integer)
                Me._currentPrice = value
				OnPropertyChanged("CurrentPrice")
			End Set
		End Property
		#End Region

		Public Sub New(ByVal description As String, ByVal specialFeatures As SpecialFeatures, ByVal currentPrice As Integer)
            Me._description = description
            Me._specialFeatures = specialFeatures
            Me._currentPrice = currentPrice
            Me._images = New ObservableCollection(Of String)()
		End Sub

		Public Sub New()
            Me._images = New ObservableCollection(Of String)()
		End Sub

		Protected Sub OnPropertyChanged(ByVal name As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
		End Sub
	End Class

	'<SnippetSpecialFeatureEnum>
	Public Enum SpecialFeatures
		None
		Color
	End Enum
	'</SnippetSpecialFeatureEnum>

End Namespace

