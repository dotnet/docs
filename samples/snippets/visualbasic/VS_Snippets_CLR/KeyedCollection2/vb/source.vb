' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

' This class derives from KeyedCollection and shows how to override
' the protected ClearItems, InsertItem, RemoveItem, and SetItem 
' methods in order to change the behavior of the default Item 
' property and the Add, Clear, Insert, and Remove methods. The
' class implements a Changed event, which is raised by all the
' protected methods.
'
' SimpleOrder is a collection of OrderItem objects, and its key
' is the PartNumber field of OrderItem. PartNumber is an Integer,
' so SimpleOrder inherits KeyedCollection(Of Integer, OrderItem).
' (Note that the key of OrderItem cannot be changed; if it could 
' be changed, SimpleOrder would have to override ChangeItemKey.)
'
Public Class SimpleOrder
    Inherits KeyedCollection(Of Integer, OrderItem)

    Public Event Changed As EventHandler(Of SimpleOrderChangedEventArgs)

    ' This parameterless constructor calls the base class constructor
    ' that specifies a dictionary threshold of 0, so that the internal
    ' dictionary is created as soon as an item is added to the 
    ' collection.
    '
    Public Sub New()
        MyBase.New(Nothing, 0)
    End Sub
    
    ' This is the only method that absolutely must be overridden,
    ' because without it the KeyedCollection cannot extract the
    ' keys from the items. 
    '
    Protected Overrides Function GetKeyForItem( _
        ByVal item As OrderItem) As Integer

        ' In this example, the key is the part number.
        Return item.PartNumber   
    End Function

    Protected Overrides Sub InsertItem( _
        ByVal index As Integer, ByVal newItem As OrderItem)

        MyBase.InsertItem(index, newItem)

        RaiseEvent Changed(Me, New SimpleOrderChangedEventArgs( _
            ChangeType.Added, newItem, Nothing))
    End Sub

    '<Snippet3>
    Protected Overrides Sub SetItem(ByVal index As Integer, _
        ByVal newItem As OrderItem)

        Dim replaced As OrderItem = Items(index)
        MyBase.SetItem(index, newItem)

        RaiseEvent Changed(Me, New SimpleOrderChangedEventArgs( _
            ChangeType.Replaced, replaced, newItem))
    End Sub
    '</Snippet3>

    Protected Overrides Sub RemoveItem(ByVal index As Integer)

        Dim removedItem As OrderItem = Items(index)
        MyBase.RemoveItem(index)

        RaiseEvent Changed(Me, New SimpleOrderChangedEventArgs( _
            ChangeType.Removed, removedItem, Nothing))
    End Sub

    Protected Overrides Sub ClearItems()
        MyBase.ClearItems()

        RaiseEvent Changed(Me, New SimpleOrderChangedEventArgs( _
            ChangeType.Cleared, Nothing, Nothing))
    End Sub

End Class

' Event argument for the Changed event.
'
Public Class SimpleOrderChangedEventArgs
    Inherits EventArgs

    Private _changedItem As OrderItem
    Private _changeType As ChangeType
    Private _replacedWith As OrderItem

    Public ReadOnly Property ChangedItem As OrderItem
        Get
            Return _changedItem
        End Get
    End Property

    Public ReadOnly Property ChangeType As ChangeType
        Get
            Return _changeType
        End Get
    End Property

    Public ReadOnly Property ReplacedWith As OrderItem
        Get
            Return _replacedWith
        End Get
    End Property

    Public Sub New(ByVal change As ChangeType, ByVal item As OrderItem, _
        ByVal replacement As OrderItem)

        _changeType = change
        _changedItem = item
        _replacedWith = replacement
    End Sub
End Class

Public Enum ChangeType
    Added
    Removed
    Replaced
    Cleared
End Enum

Public Class Demo
    
    Public Shared Sub Main() 
        Dim weekly As New SimpleOrder()
        AddHandler weekly.Changed, AddressOf ChangedHandler

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
        ' type, Integer. The property is read-only.
        '
        Console.WriteLine(vbLf & "weekly(101030411).Description: {0}", _
            weekly(101030411).Description)

        ' The Remove method of KeyedCollection takes a key.
        '
        Console.WriteLine(vbLf & "Remove(101030411)")
        weekly.Remove(101030411)

        ' The Insert method, inherited from Collection, takes an 
        ' index and an OrderItem.
        '
        Console.WriteLine(vbLf & "Insert(2, New OrderItem(...))")
        weekly.Insert(2, New OrderItem(111033401, "Nut", 10, .5))
         
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

        Console.WriteLine(vbLf & "RemoveAt(0)")
        weekly.RemoveAt(0)

        ' Increase the quantity for a line item.
        Console.WriteLine(vbLf & "coweekly(1) = New OrderItem(...)")
        coweekly(1) = New OrderItem(coweekly(1).PartNumber, _
            coweekly(1).Description, coweekly(1).Quantity + 1000, _
            coweekly(1).UnitPrice)

        Display(weekly)

        Console.WriteLine()
        weekly.Clear()
    End Sub
    
    Private Shared Sub Display(ByVal order As SimpleOrder) 
        Console.WriteLine()
        For Each item As OrderItem In  order
            Console.WriteLine(item)
        Next item
    End Sub

    Private Shared Sub ChangedHandler(ByVal source As Object, _
        ByVal e As SimpleOrderChangedEventArgs)

        Dim item As OrderItem = e.ChangedItem

        If e.ChangeType = ChangeType.Replaced Then
            Dim replacement As OrderItem = e.ReplacedWith

            Console.WriteLine("{0} (quantity {1}) was replaced " & _
                "by {2}, (quantity {3}).", item.Description, _
                item.Quantity, replacement.Description, replacement.Quantity)

        ElseIf e.ChangeType = ChangeType.Cleared Then
            Console.WriteLine("The order list was cleared.")

        Else
            Console.WriteLine("{0} (quantity {1}) was {2}.", _
                item.Description, item.Quantity, e.ChangeType)
        End If
    End Sub
End Class

' This class represents a simple line item in an order. All the 
' values are immutable except quantity.
' 
Public Class OrderItem
    
    Private _partNumber As Integer
    Private _description As String
    Private _unitPrice As Double
    Private _quantity As Integer

    Public ReadOnly Property PartNumber As Integer
        Get
            Return _partNumber
        End Get
    End Property

    Public ReadOnly Property Description As String
        Get
            Return _description
        End Get
    End Property

    Public ReadOnly Property UnitPrice As Double
        Get
            Return _unitPrice
        End Get
    End Property
    
    Public ReadOnly Property Quantity() As Integer 
        Get
            Return _quantity
        End Get
    End Property
    
    Public Sub New(ByVal partNumber As Integer, _
                   ByVal description As String, _
                   ByVal quantity As Integer, _
                   ByVal unitPrice As Double) 
        _partNumber = partNumber
        _description = description
        _quantity = quantity
        _unitPrice = unitPrice
    End Sub 'New
        
    Public Overrides Function ToString() As String 
        Return String.Format( _
            "{0,9} {1,6} {2,-12} at {3,8:#,###.00} = {4,10:###,###.00}", _
            PartNumber, _quantity, Description, UnitPrice, _
            UnitPrice * _quantity)
    End Function
End Class

' This code example produces the following output:
'
'Widget (quantity 400) was Added.
'Sprocket (quantity 27) was Added.
'Motor (quantity 10) was Added.
'Gear (quantity 175) was Added.
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
'Motor (quantity 10) was Removed.
'
'Insert(2, New OrderItem(...))
'Nut (quantity 10) was Added.
'
'coweekly(2).Description: Nut
'
'coweekly(2) = New OrderItem(...)
'Nut (quantity 10) was replaced by Crank, (quantity 27).
'
'IndexOf(temp): 2
'
'Remove(temp)
'Crank (quantity 27) was Removed.
'
'RemoveAt(0)
'Widget (quantity 400) was Removed.
'
'coweekly(1) = New OrderItem(...)
'Gear (quantity 175) was replaced by Gear, (quantity 1175).
'
'110072675     27 Sprocket     at     5.30 =     143.10
'110072684   1175 Gear         at     5.17 =   6,074.75
'
'The order list was cleared.
'</Snippet1>