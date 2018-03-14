Imports System
Imports System.ComponentModel

Public Class Person
    Implements INotifyPropertyChanged

    ' Events
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    ' Methods
    Public Sub New()
    End Sub

    Public Sub New(ByVal first As String, ByVal last As String, ByVal town As String)
        Me._firstname = first
        Me._lastname = last
        Me._hometown = town
    End Sub

    Private Sub OnPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub

    Public Overrides Function ToString() As String
        Return Me._firstname.ToString
    End Function


    ' Properties
    Public Property FirstName() As String
        Get
            Return Me._firstname
        End Get
        Set(ByVal value As String)
            Me._firstname = value
            Me.OnPropertyChanged("FirstName")
        End Set
    End Property

    Public Property HomeTown() As String
        Get
            Return Me._hometown
        End Get
        Set(ByVal value As String)
            Me._hometown = value
            Me.OnPropertyChanged("HomeTown")
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return Me._lastname
        End Get
        Set(ByVal value As String)
            Me._lastname = value
            Me.OnPropertyChanged("LastName")
        End Set
    End Property


    ' Fields
    Private _firstname As String
    Private _hometown As String
    Private _lastname As String
End Class

