Imports System
Imports System.Web
Imports System.Web.SessionState
Imports System.Collections
Imports System.Collections.Specialized


Namespace Samples.AspNet.Session

  Public Class MySessionStateItemCollection
    Implements ISessionStateItemCollection
  
    Private pItems As SortedList = New SortedList()
    Private pDirty As Boolean = False

    Public Property Dirty As Boolean Implements ISessionStateItemCollection.Dirty    
      Get
        Return pDirty
      End Get
      Set
        pDirty = value
      End Set
    End Property

    Public Property Item(index As Integer) As Object Implements ISessionStateItemCollection.Item
      Get
        Return pItems(index)
      End Get
      Set
        pItems(index) = value
        pDirty = True
      End Set
    End Property

    Public Property Item(name As String) As Object Implements ISessionStateItemCollection.Item
      Get
        Return pItems(name)
      End Get
      Set
        pItems(name) = value
        pDirty = True
      End Set
    End Property

    Public ReadOnly Property Keys As NameObjectCollectionBase.KeysCollection _
      Implements ISessionStateItemCollection.Keys
      Get
        Return CType(pItems.Keys, NameObjectCollectionBase.KeysCollection)
      End Get
    End Property

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

    Public Sub Clear() Implements ISessionStateItemCollection.Clear
      pItems.Clear()
      pDirty = True
    End Sub

    Public Sub Remove(name As String) Implements ISessionStateItemCollection.Remove
      pItems.Remove(name)
      pDirty = True
    End Sub

    Public Sub RemoveAt(index As Integer) Implements ISessionStateItemCollection.RemoveAt 
      If index < 0 OrElse index >= Me.Count Then _
        Throw New ArgumentOutOfRangeException("The specified index is not within the acceptable range.")
   
      pItems.RemoveAt(index)
      pDirty = True
    End Sub

    Public Sub CopyTo(array As Array, index As Integer) Implements ICollection.CopyTo
      pItems.CopyTo(array, index)
    End Sub

  End Class

End Namespace