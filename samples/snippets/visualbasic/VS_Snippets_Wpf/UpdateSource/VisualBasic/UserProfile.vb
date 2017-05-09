Imports System
Imports System.ComponentModel
Imports System.Runtime.CompilerServices

    Public Class UserProfile
        Implements INotifyPropertyChanged

        ' Events
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        ' Methods
        Public Sub New()
            Me.itemName = ""
            Me.bidPrice = ""
        End Sub

        Private Sub OnPropertyChanged(ByVal info As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
        End Sub


        ' Properties
        Public Property BidPrice As String
            Get
                Return Me._bidPrice
            End Get
            Set(ByVal value As String)
                Me._bidPrice = value
                Me.OnPropertyChanged("BidPrice")
            End Set
        End Property

        Public Property ItemName As String
            Get
                Return Me._itemName
            End Get
            Set(ByVal value As String)
                Me._itemName = value
                Me.OnPropertyChanged("ItemName")
            End Set
        End Property


        ' Fields
        Private _bidPrice As String
        Private _itemName As String
    End Class


