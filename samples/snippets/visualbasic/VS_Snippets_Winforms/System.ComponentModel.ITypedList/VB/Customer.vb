' <snippet10>
Imports System.ComponentModel

Public Class Customer
    Implements INotifyPropertyChanged

    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal company As String, ByVal address As String, ByVal city As String, ByVal state As String, ByVal zip As String)
        Me._id = id
        Me._name = name
        Me._company = company
        Me._address = address
        Me._city = city
        Me._state = state
        Me._zip = zip

    End Sub

#Region "Public Properties"

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            If _id <> value Then
                _id = value
                OnPropertyChanged(New PropertyChangedEventArgs("ID"))
            End If
        End Set
    End Property

    Private _name As String

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            If _name <> value Then
                _name = value
                OnPropertyChanged(New PropertyChangedEventArgs("Name"))
            End If
        End Set
    End Property

    Private _company As String

    Public Property Company() As String
        Get
            Return _company
        End Get
        Set(ByVal value As String)
            If _company <> value Then
                _company = value
                OnPropertyChanged(New PropertyChangedEventArgs("Company"))
            End If
        End Set
    End Property


    Private _address As String

    Public Property Address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            If _address <> value Then
                _address = value
                OnPropertyChanged(New PropertyChangedEventArgs("Address"))
            End If
        End Set
    End Property


    Private _city As String

    Public Property City() As String
        Get
            Return _city
        End Get
        Set(ByVal value As String)
            If _city <> value Then
                _city = value
                OnPropertyChanged(New PropertyChangedEventArgs("City"))
            End If
        End Set
    End Property


    Private _state As String

    Public Property State() As String
        Get
            Return _state
        End Get
        Set(ByVal value As String)
            If _state <> value Then
                _state = value
                OnPropertyChanged(New PropertyChangedEventArgs("State"))
            End If
        End Set
    End Property

    Private _zip As String

    Public Property ZipCode() As String
        Get
            Return _zip
        End Get
        Set(ByVal value As String)
            If _zip <> value Then
                _zip = value
                OnPropertyChanged(New PropertyChangedEventArgs("ZipCode"))
            End If
        End Set
    End Property

#End Region


#Region "INotifyPropertyChanged Members"

    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

    Protected Overridable Sub OnPropertyChanged(ByVal e As PropertyChangedEventArgs)
        RaiseEvent PropertyChanged(Me, e)
    End Sub

#End Region

End Class
' </snippet10>