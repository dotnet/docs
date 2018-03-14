' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

' This class demonstrates one way to use the ChangeItemKey
' method to store objects with keys that can be changed. The 
' ChangeItemKey method is used to keep the internal lookup
' Dictionary in sync with the keys of the stored objects. 
'
' MutableKeys stores MutableKey objects, which have an Integer
' Key property that can be set. Therefore, MutableKeys inherits
' KeyedCollection(Of Integer, MutableKey).
'
Public Class MutableKeys
    Inherits KeyedCollection(Of Integer, MutableKey)

    ' This parameterless constructor delegates to the base class 
    ' constructor that specifies a dictionary threshold. A
    ' threshold of 0 means the internal Dictionary is created
    ' the first time an object is added.
    '
    Public Sub New()
        MyBase.New(Nothing, 0)
    End Sub
    
    Protected Overrides Function GetKeyForItem( _
        ByVal item As MutableKey) As Integer

        ' The key is MutableKey.Key.
        Return item.Key   
    End Function

    Protected Overrides Sub InsertItem( _
        ByVal index As Integer, ByVal newItem As MutableKey)

        If newItem.Collection IsNot Nothing Then _
            Throw New ArgumentException("The item already belongs to a collection.")

        MyBase.InsertItem(index, newItem)
        newItem.Collection = Me
    End Sub

    Protected Overrides Sub SetItem(ByVal index As Integer, _
        ByVal newItem As MutableKey)

        Dim replaced As MutableKey = Items(index)

        If newItem.Collection IsNot Nothing Then _
            Throw New ArgumentException("The item already belongs to a collection.")

        MyBase.SetItem(index, newItem)
        newItem.Collection = Me
        replaced.Collection = Nothing
    End Sub

    Protected Overrides Sub RemoveItem(ByVal index As Integer)
        Dim removedItem As MutableKey = Items(index)

        MyBase.RemoveItem(index)
        removedItem.Collection = Nothing
    End Sub

    Protected Overrides Sub ClearItems()
        For Each mk As MutableKey In Items
            mk.Collection = Nothing
        Next
        
        MyBase.ClearItems()
    End Sub

    Friend Sub ChangeKey(ByVal item As MutableKey, _
        ByVal newKey As Integer)

        MyBase.ChangeItemKey(item, newKey)
    End Sub
    
    Public Sub Dump()
        Console.WriteLine(vbLf & "DUMP:")
        If Dictionary Is Nothing Then
            Console.WriteLine("    The dictionary has not been created.")
        Else
            Console.WriteLine("    Dictionary entries")
            Console.WriteLine("    ------------------")

            For Each kvp As KeyValuePair(Of Integer, MutableKey) In Dictionary
                Console.WriteLine("    {0} : {1}", kvp.Key, kvp.Value)
            Next
        End If

        Console.WriteLine(vbLf & "    List of items")
        Console.WriteLine("    -------------")

        For Each mk As MutableKey In Items
            Console.WriteLine("    {0}", mk)
        Next
    End Sub

End Class

Public Class Demo
    
    Public Shared Sub Main() 

        Dim mkeys As New MutableKeys()

        ' The Add method is inherited from Collection.
        '
        mkeys.Add(New MutableKey(110072674, "Widget"))
        mkeys.Add(New MutableKey(110072675, "Sprocket"))

        mkeys.Dump() 
    
        Console.WriteLine(vbLf & "Create and insert a new item:")
        Dim test As New MutableKey(110072684, "Gear")
        mkeys.Insert(1, test)

        mkeys.Dump()

        Try
            Console.WriteLine(vbLf & "Try to insert the item again:")
            mkeys.Insert(1, test)
        Catch ex As ArgumentException
            Console.WriteLine("Error: {0}", ex.Message)
        End Try

        Console.WriteLine(vbLf & "Change the Key property of the item:")
        test.Key = 100000072

        mkeys.Dump()

        Try
            Console.WriteLine(vbLf & "Try to set the Key property to an existing key:")
            test.Key = 110072674
        Catch ex As ArgumentException
            Console.WriteLine("Error: {0}", ex.Message)
        End Try

        mkeys.Dump()

    End Sub
    
    Private Shared Sub Display(ByVal order As MutableKeys) 
        Console.WriteLine()
        For Each item As MutableKey In  order
            Console.WriteLine(item)
        Next item
    End Sub
End Class

' This class has a key that can be changed.
' 
Public Class MutableKey

    Public Sub New(ByVal newKey As Integer, ByVal newValue As String)
        _key = newKey
        Value = newValue
    End Sub 'New
    
    Public Value As String
    Friend Collection As MutableKeys
    
    Private _key As Integer
    Public Property Key As Integer 
        Get
            Return _key
        End Get
        Set
            If Collection IsNot Nothing Then
                Collection.ChangeKey(Me, value)
            End If

            _key = value
        End Set
    End Property

    Public Overrides Function ToString() As String 
        Return String.Format("{0,9} {1}", _key, Value)
    End Function
        
End Class

' This code example produces the following output:
'
'DUMP:
'    Dictionary entries
'    ------------------
'    110072674 : 110072674 Widget
'    110072675 : 110072675 Sprocket
'
'    List of items
'    -------------
'    110072674 Widget
'    110072675 Sprocket
'
'Create and insert a new item:
'
'DUMP:
'    Dictionary entries
'    ------------------
'    110072674 : 110072674 Widget
'    110072675 : 110072675 Sprocket
'    110072684 : 110072684 Gear
'
'    List of items
'    -------------
'    110072674 Widget
'    110072684 Gear
'    110072675 Sprocket
'
'Try to insert the item again:
'Error: The item already belongs to a collection.
'
'Change the Key property of the item:
'
'DUMP:
'    Dictionary entries
'    ------------------
'    110072674 : 110072674 Widget
'    110072675 : 110072675 Sprocket
'    100000072 : 100000072 Gear
'
'    List of items
'    -------------
'    110072674 Widget
'    100000072 Gear
'    110072675 Sprocket
'
'Try to set the Key property to an existing key:
'Error: An item with the same key has already been added.
'
'DUMP:
'    Dictionary entries
'    ------------------
'    110072674 : 110072674 Widget
'    110072675 : 110072675 Sprocket
'    100000072 : 100000072 Gear
'
'    List of items
'    -------------
'    110072674 Widget
'    100000072 Gear
'    110072675 Sprocket
'</Snippet1>