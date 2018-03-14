Imports System
Imports System.ComponentModel
Imports System.Runtime.CompilerServices

    Public Class Order
        Implements INotifyPropertyChanged

        ' Events
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        ' Methods
        Public Sub New(ByVal _order As Integer, ByVal _customer As Integer, ByVal _name As String, ByVal _id As Integer, ByVal _filled As String, ByVal _orderdate As DateTime)
            Me.OrderItem = _order
            Me.Customer = _customer
            Me.Name = _name
            Me.Id = _id
            Me.Filled = _filled
            Me.OrderDate = _orderdate
        End Sub

        Public Sub New(ByVal _order As Integer, ByVal _customer As Integer, ByVal _name As String, ByVal _id As Integer, ByVal _filled As String, ByVal _orderdate As DateTime, ByVal _datefilled As DateTime)
            Me.OrderItem = _order
            Me.Customer = _customer
            Me.Name = _name
            Me.Id = _id
            Me.Filled = _filled
            Me.OrderDate = _orderdate
            Me.DateFilled = _datefilled
        End Sub

        Private Sub OnPropertyChanged(ByVal info As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
        End Sub


        ' Properties
        Public Property Customer As Integer
            Get
                Return Me._customer
            End Get
            Set(ByVal value As Integer)
                Me._customer = value
                Me.OnPropertyChanged("Customer")
            End Set
        End Property

        Public Property DateFilled As DateTime
            Get
                Return Me._datefilled
            End Get
            Set(ByVal value As DateTime)
                Me._datefilled = value
                Me.OnPropertyChanged("DateFilled")
            End Set
        End Property

        Public Property Filled As String
            Get
                Return Me._filled
            End Get
            Set(ByVal value As String)
                Me._filled = value
                Me.OnPropertyChanged("Filled")
            End Set
        End Property

        Public Property Id As Integer
            Get
                Return Me._id
            End Get
            Set(ByVal value As Integer)
                Me._id = value
                Me.OnPropertyChanged("Id")
            End Set
        End Property

        Public Property Name As String
            Get
                Return Me._name
            End Get
            Set(ByVal value As String)
                Me._name = value
                Me.OnPropertyChanged("Name")
            End Set
        End Property

        Public Property OrderDate As DateTime
            Get
                Return Me._orderdate
            End Get
            Set(ByVal value As DateTime)
                Me._orderdate = value
                Me.OnPropertyChanged("OrderDate")
            End Set
        End Property

        Public Property OrderItem As Integer
            Get
                Return Me._order
            End Get
            Set(ByVal value As Integer)
                Me._order = value
                Me.OnPropertyChanged("OrderItem")
            End Set
        End Property


        ' Fields
        Private _customer As Integer
        Private _datefilled As DateTime
        Private _filled As String
        Private _id As Integer
        Private _name As String
        Private _order As Integer
        Private _orderdate As DateTime
    End Class

