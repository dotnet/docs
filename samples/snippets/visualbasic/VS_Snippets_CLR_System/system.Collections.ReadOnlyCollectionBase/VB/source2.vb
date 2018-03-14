' The following code example implements the ReadOnlyCollectionBase class.

Imports System
Imports System.Collections

Public Class ROCollection
    Inherits ReadOnlyCollectionBase


    Public Sub New(sourceList As IList)
        InnerList.AddRange(sourceList)
    End Sub 'New


    Default Public ReadOnly Property Item(index As Integer) As [Object]
        Get
            Return InnerList(index)
        End Get
    End Property


    Public Function IndexOf(value As [Object]) As Integer
        Return InnerList.IndexOf(value)
    End Function 'IndexOf


    Public Function Contains(value As [Object]) As Boolean
        Return InnerList.Contains(value)
    End Function 'Contains

End Class 'ROCollection 


Public Class SamplesCollectionBase

    Public Shared Sub Main()

        ' Create an ArrayList.
        Dim myAL As New ArrayList()
        myAL.Add("red")
        myAL.Add("blue")
        myAL.Add("yellow")
        myAL.Add("green")
        myAL.Add("orange")
        myAL.Add("purple")
        ' Create a new ROCollection that contains the elements in myAL.
        Dim myReadOnlyCollection As New ROCollection( myAL )

        ' <Snippet2>
        ' Get the ICollection interface from the ReadOnlyCollectionBase
        ' derived class.
        Dim myCollection As ICollection = myReadOnlyCollection
        SyncLock myCollection.SyncRoot
            For Each item As Object In myCollection
                ' Insert your code here.
            Next item
        End SyncLock
        ' </Snippet2>
    End Sub
End Class
