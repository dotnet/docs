'<Snippet1>
Imports System
Imports System.Web
Imports System.Web.SessionState
Imports System.Collections
Imports System.Collections.Specialized


Namespace Samples.AspNet.Session

  Public Class MySessionStateItemCollection
    Implements ISessionStateItemCollection
  
    Private pItems As SortedList = New SortedList()
'<Snippet2>
    Private pDirty As Boolean = False

    Public Property Dirty As Boolean Implements ISessionStateItemCollection.Dirty    
      Get
        Return pDirty
      End Get
      Set
        pDirty = value
      End Set
    End Property
'</Snippet2>

'<Snippet3>
    Public Property Item(index As Integer) As Object Implements ISessionStateItemCollection.Item
      Get
        Return pItems(index)
      End Get
      Set
        pItems(index) = value
        pDirty = True
      End Set
    End Property
'</Snippet3>

'<Snippet4>
    Public Property Item(name As String) As Object Implements ISessionStateItemCollection.Item
      Get
        Return pItems(name)
      End Get
      Set
        pItems(name) = value
        pDirty = True
      End Set
    End Property
'</Snippet4>

'<Snippet5>
    Public ReadOnly Property Keys As NameObjectCollectionBase.KeysCollection _
      Implements ISessionStateItemCollection.Keys
      Get
        Return CType(pItems.Keys, NameObjectCollectionBase.KeysCollection)
      End Get
    End Property
'</Snippet5>

    Public ReadOnly Property Count As Integer Implements ICollection.Count    
      Get
        Return pItems.Count
      End Get
    End Property

    Public ReadOnly Property SyncRoot As Object Implements ICollection.SyncRoot    
      Get
        Return Me
      End Get
    End Property

    Public ReadOnly Property IsSynchronized As Boolean Implements ICollection.IsSynchronized
      Get
        Return False
      End Get
    End Property

    Public Function GetEnumerator() As IEnumerator Implements ICollection.GetEnumerator    
      Return pItems.GetEnumerator() 
    End Function

'<Snippet6>
    Public Sub Clear() Implements ISessionStateItemCollection.Clear
      pItems.Clear()
      pDirty = True
    End Sub
'</Snippet6>

'<Snippet7>
    Public Sub Remove(name As String) Implements ISessionStateItemCollection.Remove
      pItems.Remove(name)
      pDirty = True
    End Sub
'</Snippet7>

'<Snippet8>
    Public Sub RemoveAt(index As Integer) Implements ISessionStateItemCollection.RemoveAt 
      If index < 0 OrElse index >= Me.Count Then _
        Throw New ArgumentOutOfRangeException("The specified index is not within the acceptable range.")
   
      pItems.RemoveAt(index)
      pDirty = True
    End Sub
'</Snippet8>

    Public Sub CopyTo(array As Array, index As Integer) Implements ICollection.CopyTo
      pItems.CopyTo(array, index)
    End Sub

  End Class

End Namespace
'</Snippet1>


