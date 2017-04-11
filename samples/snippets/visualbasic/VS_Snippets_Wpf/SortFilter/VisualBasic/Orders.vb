Imports System
Imports System.Collections.ObjectModel

    Public Class Orders
        Inherits ObservableCollection(Of Order)

        ' Methods
        Public Sub New()
            Me.o1 = New Order(1001, 5682, "Blue Sweater", 44, "Yes", New DateTime(2003, 1, 23), New DateTime(2003, 2, 4))
            Me.o2 = New Order(1002, 2211, "Gray Jacket Long", 181, "No", New DateTime(2003, 2, 14))
            Me.o3 = New Order(1003, 5682, "Brown Pant W", 2, "Yes", New DateTime(2002, 12, 20), New DateTime(2003, 1, 13))
            Me.o4 = New Order(1004, 3143, "Orange T-shirt", 205, "No", New DateTime(2003, 1, 28))
            MyBase.Add(Me.o1)
            MyBase.Add(Me.o2)
            MyBase.Add(Me.o3)
            MyBase.Add(Me.o4)
        End Sub


        ' Fields
        Public o1 As Order
        Public o2 As Order
        Public o3 As Order
        Public o4 As Order
    End Class


