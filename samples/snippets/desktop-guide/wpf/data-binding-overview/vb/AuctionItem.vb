Imports System.ComponentModel

Public Class AuctionItem
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public CurrentPrice As Integer

End Class
