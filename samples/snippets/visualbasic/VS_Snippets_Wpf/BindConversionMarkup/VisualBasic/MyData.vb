Imports System
Imports System.ComponentModel

Public Class MyData
    Implements INotifyPropertyChanged

    Private _theDate As DateTime = DateTime.Now

    ' Events
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    ' Methods
    Public Sub New()

    End Sub

    Private Sub OnPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub

    ' Properties
    Public Property TheDate() As DateTime
        Get
            Return Me._theDate
        End Get
        Set(ByVal value As DateTime)
            Me._theDate = value
            Me.OnPropertyChanged("TheDate")
        End Set
    End Property

End Class


