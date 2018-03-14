Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Data
Imports System.Windows.Input
Imports System.Collections.ObjectModel

Namespace SDKSample
	' Create the collection of Order objects
	Public Class Orders
		Inherits ObservableCollection(Of Order)
		Public o1 As New Order(1001, 5682, "Blue Sweater", 44, "Yes", New Date(2003, 1, 23), New Date(2003, 2, 4))
		Public o2 As New Order(1002, 2211, "Gray Jacket Long", 181, "No", New Date(2003, 2, 14))
		Public o3 As New Order(1003, 5682, "Brown Pant W", 02, "Yes", New Date(2002, 12, 20), New Date(2003, 1, 13))
		Public o4 As New Order(1004, 3143, "Orange T-shirt", 205, "No", New Date(2003, 1, 28))
		Public Sub New()
			MyBase.New()
			Add(o1)
			Add(o2)
			Add(o3)
			Add(o4)
		End Sub
	End Class

	Public Class Order
		Implements INotifyPropertyChanged
		Private _order As Integer
		Private _customer As Integer
		Private _name As String
		Private _id As Integer
		Private _filled As String
		Private _orderdate As Date
		Private _datefilled As Date

		Public Property OrderItem() As Integer
			Get
				Return _order
			End Get
			Set(ByVal value As Integer)
				_order = value
				OnPropertyChanged("OrderItem")
			End Set
		End Property
		Public Property Customer() As Integer
			Get
				Return _customer
			End Get
			Set(ByVal value As Integer)
				_customer = value
				OnPropertyChanged("Customer")
			End Set
		End Property
		Public Property Name() As String
			Get
				Return _name
			End Get
			Set(ByVal value As String)
				_name = value
				OnPropertyChanged("Name")
			End Set
		End Property
		Public Property Id() As Integer
			Get
				Return _id
			End Get
			Set(ByVal value As Integer)
				_id = value
				OnPropertyChanged("Id")
			End Set
		End Property
		Public Property Filled() As String
			Get
				Return _filled
			End Get
			Set(ByVal value As String)
				_filled = value
				OnPropertyChanged("Filled")
			End Set
		End Property
		Public Property OrderDate() As Date
			Get
				Return _orderdate
			End Get
			Set(ByVal value As Date)
				_orderdate = value
				OnPropertyChanged("OrderDate")
			End Set
		End Property
		Public Property DateFilled() As Date
			Get
				Return _datefilled
			End Get
			Set(ByVal value As Date)
				_datefilled = value
				OnPropertyChanged("DateFilled")
			End Set
		End Property
		Public Sub New(ByVal _order As Integer, ByVal _customer As Integer, ByVal _name As String, ByVal _id As Integer, ByVal _filled As String, ByVal _orderdate As Date, ByVal _datefilled As Date)
			Me.OrderItem = _order
			Me.Customer = _customer
			Me.Name = _name
			Me.Id = _id
			Me.Filled = _filled
			Me.OrderDate = _orderdate
			Me.DateFilled = _datefilled
		End Sub
		Public Sub New(ByVal _order As Integer, ByVal _customer As Integer, ByVal _name As String, ByVal _id As Integer, ByVal _filled As String, ByVal _orderdate As Date)
			Me.OrderItem = _order
			Me.Customer = _customer
			Me.Name = _name
			Me.Id = _id
			Me.Filled = _filled
			Me.OrderDate = _orderdate
		End Sub

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Private Sub OnPropertyChanged(ByVal info As String)
			Dim handler As PropertyChangedEventHandler = PropertyChangedEvent
			If handler IsNot Nothing Then
				handler(Me, New PropertyChangedEventArgs(info))
			End If
		End Sub
	End Class
End Namespace
