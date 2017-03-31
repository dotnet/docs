Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class AuctionItem
    Implements INotifyPropertyChanged

    Private DescriptionValue As String
    Private StartPriceValue As Integer
    Private StartDateValue As DateTime
    Private CategoryValue As ProductCategory
    Private OwnerValue As User
    Private BidsValue As ObservableCollection(Of Bid)
    Private SpecialFeaturesValue As SpecialFeatures

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

#Region "Property Getters and Setters"
    Public Property Description() As String
        Get
            Return DescriptionValue
        End Get
        Set(ByVal value As String)
            DescriptionValue = value
            OnPropertyChanged("Description")
        End Set
    End Property

    Public Property StartPrice() As Integer
        Get
            Return StartPriceValue
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("Price must be positive")
            End If
            StartPriceValue = value
            OnPropertyChanged("StartPrice")
            OnPropertyChanged("CurrentPrice")
        End Set
    End Property

    Public Property StartDate() As DateTime
        Get
            Return StartDateValue
        End Get
        Set(ByVal value As DateTime)
            StartDateValue = value
            OnPropertyChanged("StartDate")
        End Set
    End Property

    Public Property Category() As ProductCategory
        Get
            Return CategoryValue
        End Get
        Set(ByVal value As ProductCategory)
            CategoryValue = value
            OnPropertyChanged("Category")
        End Set
    End Property

    Public ReadOnly Property Owner() As User
        Get
            Return OwnerValue
        End Get
    End Property

    Public Property SpecialFeatures() As SpecialFeatures
        Get
            Return SpecialFeaturesValue
        End Get
        Set(ByVal value As SpecialFeatures)
            SpecialFeaturesValue = value
            OnPropertyChanged("SpecialFeatures")
        End Set
    End Property

    Public ReadOnly Property Bids() As ReadOnlyObservableCollection(Of Bid)
        Get
            Return New ReadOnlyObservableCollection(Of Bid)(Me.BidsValue)
        End Get
    End Property

    Public ReadOnly Property CurrentPrice() As Integer
        Get
            Dim Price As Integer = 0

            If (Me.Bids.Count > 0) Then
                Dim LastBid As Bid
                LastBid = Me.Bids(Me.Bids.Count - 1)
                Price = LastBid.Amount
            Else
                Price = Me.StartPrice
            End If

            Return Price
        End Get
    End Property
#End Region

    Sub New(ByVal Description As String, ByVal Category As ProductCategory, ByVal StartPrice As Integer, ByVal StartDate As DateTime, ByVal Owner As User, ByVal SpecialFeatures As SpecialFeatures)
        Me.DescriptionValue = Description
        Me.CategoryValue = Category
        Me.StartPriceValue = StartPrice
        Me.StartDateValue = StartDate
        Me.OwnerValue = Owner
        Me.SpecialFeaturesValue = SpecialFeatures
        Me.BidsValue = New ObservableCollection(Of Bid)
    End Sub

    Public Sub AddBid(ByVal BidVal As Bid)
        Me.BidsValue.Add(BidVal)
        OnPropertyChanged("CurrentPrice")
    End Sub

    Protected Sub OnPropertyChanged(ByVal name As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub

End Class

Public Enum ProductCategory As Integer
    Books
    Computers
    DVDs
    Electronics
    Home
    Sports
End Enum

Public Enum SpecialFeatures As Integer
    None
    Color
    Highlight
End Enum

