' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

' This class represents a very simple keyed list of OrderItems,
' inheriting most of its behavior from the KeyedCollection and 
' Collection classes. The immediate base class is the constructed
' type KeyedCollection(Of Integer, OrderItem). When you inherit
' from KeyedCollection, the second generic type argument is the 
' type that you want to store in the collection -- in this case
' OrderItem. The first generic argument is the type that you want
' to use as a key. Its values must be calculated from OrderItem; 
' in this case it is the Integer field PartNumber, so SimpleOrder
' inherits KeyedCollection(Of Integer, OrderItem).
'
Public Class SimpleOrder
    Inherits KeyedCollection(Of Integer, OrderItem)


    ' This is the only method that absolutely must be overridden,
    ' because without it the KeyedCollection cannot extract the
    ' keys from the items. The input parameter type is the 
    ' second generic type argument, in this case OrderItem, and 
    ' the return value type is the first generic type argument,
    ' in this case Integer.
    '
    Protected Overrides Function GetKeyForItem( _
        ByVal item As OrderItem) As Integer

        ' In this example, the key is the part number.
        Return item.PartNumber   
    End Function

End Class

Public Class Demo
    
    Public Shared Sub Main() 
        Dim weekly As New SimpleOrder()

        ' The Add method, inherited from Collection, takes OrderItem.
        '
        weekly.Add(New OrderItem(110072674, "Widget", 400, 45.17))
        weekly.Add(New OrderItem(110072675, "Sprocket", 27, 5.3))
        weekly.Add(New OrderItem(101030411, "Motor", 10, 237.5))
        weekly.Add(New OrderItem(110072684, "Gear", 175, 5.17))
        
        Display(weekly)
    
        ' The Contains method of KeyedCollection takes TKey.
        '
        Console.WriteLine(vbLf & "Contains(101030411): {0}", _
            weekly.Contains(101030411))

        ' The default Item property of KeyedCollection takes the key
        ' type, Integer.
        '
        Console.WriteLine(vbLf & "weekly(101030411).Description: {0}", _
            weekly(101030411).Description)

        ' The Remove method of KeyedCollection takes a key.
        '
        Console.WriteLine(vbLf & "Remove(101030411)")
        weekly.Remove(101030411)
        Display(weekly)

        ' The Insert method, inherited from Collection, takes an 
        ' index and an OrderItem.
        '
        Console.WriteLine(vbLf & "Insert(2, New OrderItem(...))")
        weekly.Insert(2, New OrderItem(111033401, "Nut", 10, .5))
        Display(weekly)

        ' The default Item property is overloaded. One overload comes
        ' from KeyedCollection(Of Integer, OrderItem); that overload
        ' is read-only, and takes Integer because it retrieves by key. 
        ' The other overload comes from Collection(Of OrderItem), the 
        ' base class of KeyedCollection(Of Integer, OrderItem); it 
        ' retrieves by index, so it also takes an Integer. The compiler
        ' uses the most-derived overload, from KeyedCollection, so the
        ' only way to access SimpleOrder by index is to cast it to
        ' Collection(Of OrderItem). Otherwise the index is interpreted
        ' as a key, and KeyNotFoundException is thrown.
        '
        Dim coweekly As Collection(Of OrderItem) = weekly
        Console.WriteLine(vbLf & "coweekly(2).Description: {0}", _
            coweekly(2).Description)
 
        Console.WriteLine(vbLf & "coweekly(2) = New OrderItem(...)")
        coweekly(2) = New OrderItem(127700026, "Crank", 27, 5.98)

        Dim temp As OrderItem = coweekly(2)

        ' The IndexOf method, inherited from Collection(Of OrderItem), 
        ' takes an OrderItem instead of a key.
        ' 
        Console.WriteLine(vbLf & "IndexOf(temp): {0}", _
            weekly.IndexOf(temp))

        ' The inherited Remove method also takes an OrderItem.
        '
        Console.WriteLine(vbLf & "Remove(temp)")
        weekly.Remove(temp)
        Display(weekly)

        Console.WriteLine(vbLf & "RemoveAt(0)")
        weekly.RemoveAt(0)
        Display(weekly)

    End Sub
    
    Private Shared Sub Display(ByVal order As SimpleOrder) 
        Console.WriteLine()
        For Each item As OrderItem In  order
            Console.WriteLine(item)
        Next item
    End Sub
End Class

' This class represents a simple line item in an order. All the 
' values are immutable except quantity.
' 
Public Class OrderItem
    Public ReadOnly PartNumber As Integer
    Public ReadOnly Description As String
    Public ReadOnly UnitPrice As Double
    
    Private _quantity As Integer = 0
    
    Public Sub New(ByVal partNumber As Integer, _
                   ByVal description As String, _
                   ByVal quantity As Integer, _
                   ByVal unitPrice As Double) 
        Me.PartNumber = partNumber
        Me.Description = description
        Me.Quantity = quantity
        Me.UnitPrice = unitPrice
    End Sub 'New
    
    Public Property Quantity() As Integer 
        Get
            Return _quantity
        End Get
        Set
            If value < 0 Then
                Throw New ArgumentException("Quantity cannot be negative.")
            End If
            _quantity = value
        End Set
    End Property
        
    Public Overrides Function ToString() As String 
        Return String.Format( _
            "{0,9} {1,6} {2,-12} at {3,8:#,###.00} = {4,10:###,###.00}", _
            PartNumber, _quantity, Description, UnitPrice, _
            UnitPrice * _quantity)
    End Function
End Class

' This code example produces the following output:
'
'110072674    400 Widget       at    45.17 =  18,068.00
'110072675     27 Sprocket     at     5.30 =     143.10
'101030411     10 Motor        at   237.50 =   2,375.00
'110072684    175 Gear         at     5.17 =     904.75
'
'Contains(101030411): True
'
'weekly(101030411).Description: Motor
'
'Remove(101030411)
'
'110072674    400 Widget       at    45.17 =  18,068.00
'110072675     27 Sprocket     at     5.30 =     143.10
'110072684    175 Gear         at     5.17 =     904.75
'
'Insert(2, New OrderItem(...))
'
'110072674    400 Widget       at    45.17 =  18,068.00
'110072675     27 Sprocket     at     5.30 =     143.10
'111033401     10 Nut          at      .50 =       5.00
'110072684    175 Gear         at     5.17 =     904.75
'
'coweekly(2).Description: Nut
'
'coweekly(2) = New OrderItem(...)
'
'IndexOf(temp): 2
'
'Remove(temp)
'
'110072674    400 Widget       at    45.17 =  18,068.00
'110072675     27 Sprocket     at     5.30 =     143.10
'110072684    175 Gear         at     5.17 =     904.75
'
'RemoveAt(0)
'
'110072675     27 Sprocket     at     5.30 =     143.10
'110072684    175 Gear         at     5.17 =     904.75
'</Snippet1>