'<Snippet1>
#Const CONTRACTS_FULL = True

Imports System.Diagnostics.Contracts


' An IArray is an ordered collection of objects.    
<ContractClass(GetType(IArrayContract))> _
Public Interface IArray
    ' The Item property provides methods to read and edit entries in the array.

    Default Property Item(ByVal index As Integer) As [Object]


    ReadOnly Property Count() As Integer


    ' Adds an item to the list.  
    ' The return value is the position the new element was inserted in.
    Function Add(ByVal value As Object) As Integer

    ' Removes all items from the list.
    Sub Clear()

    ' Inserts value into the array at position index.
    ' index must be non-negative and less than or equal to the 
    ' number of elements in the array.  If index equals the number
    ' of items in the array, then value is appended to the end.
    Sub Insert(ByVal index As Integer, ByVal value As [Object])


    ' Removes the item at position index.
    Sub RemoveAt(ByVal index As Integer)
End Interface 'IArray

<ContractClassFor(GetType(IArray))> _
Friend MustInherit Class IArrayContract
    Implements IArray

    '<Snippet3>
    Function Add(ByVal value As Object) As Integer Implements IArray.Add
        ' Returns the index in which an item was inserted.
        Contract.Ensures(Contract.Result(Of Integer)() >= -1) '
        Contract.Ensures(Contract.Result(Of Integer)() < CType(Me, IArray).Count) '
        Return 0

    End Function 'IArray.Add
    '</Snippet3>

    Default Property Item(ByVal index As Integer) As Object Implements IArray.Item
        Get
            Contract.Requires(index >= 0)
            Contract.Requires(index < CType(Me, IArray).Count)
            Return 0 '
        End Get
        Set(ByVal value As [Object])
            Contract.Requires(index >= 0)
            Contract.Requires(index < CType(Me, IArray).Count)
        End Set
    End Property
    '<Snippet2>

    Public ReadOnly Property Count() As Integer Implements IArray.Count
        Get
            Contract.Requires(Count >= 0)
            Contract.Requires(Count <= CType(Me, IArray).Count)
            Return 0 '
        End Get
    End Property

    '</Snippet2>
    Sub Clear() Implements IArray.Clear
        Contract.Ensures(CType(Me, IArray).Count = 0)

    End Sub


    '<Snippet5>
    Sub Insert(ByVal index As Integer, ByVal value As [Object]) Implements IArray.Insert
        Contract.Requires(index >= 0)
        Contract.Requires(index <= CType(Me, IArray).Count) ' For inserting immediately after the end.
        Contract.Ensures(CType(Me, IArray).Count = Contract.OldValue(CType(Me, IArray).Count) + 1)

    End Sub
    '</Snippet5>


    Sub RemoveAt(ByVal index As Integer) Implements IArray.RemoveAt
        Contract.Requires(index >= 0)
        Contract.Requires(index < CType(Me, IArray).Count)
        Contract.Ensures(CType(Me, IArray).Count = Contract.OldValue(CType(Me, IArray).Count) - 1)

    End Sub
End Class
'</Snippet1>
