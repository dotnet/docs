' The following code example implements the DictionaryBase class and uses that implementation to create a dictionary of String keys and values that have a Length of 5 or less.

Imports System
Imports System.Collections

Public Class ShortStringDictionary
   Inherits DictionaryBase

   Default Public Property Item(key As String) As String
      Get
         Return CType(Dictionary(key), String)
      End Get
      Set
         Dictionary(key) = value
      End Set
   End Property

   Public ReadOnly Property Keys() As ICollection
      Get
         Return Dictionary.Keys
      End Get
   End Property

   Public ReadOnly Property Values() As ICollection
      Get
         Return Dictionary.Values
      End Get
   End Property

   Public Sub Add(key As String, value As String)
      Dictionary.Add(key, value)
   End Sub 'Add

   Public Function Contains(key As String) As Boolean
      Return Dictionary.Contains(key)
   End Function 'Contains

   Public Sub Remove(key As String)
      Dictionary.Remove(key)
   End Sub 'Remove

   Protected Overrides Sub OnInsert(key As Object, value As Object)
      If Not GetType(System.String).IsAssignableFrom(key.GetType()) Then
         Throw New ArgumentException("key must be of type String.", "key")
      Else
         Dim strKey As String = CType(key, String)
         If strKey.Length > 5 Then
            Throw New ArgumentException("key must be no more than 5 characters in length.", "key")
         End If
      End If 
      If Not GetType(System.String).IsAssignableFrom(value.GetType()) Then
         Throw New ArgumentException("value must be of type String.", "value")
      Else
         Dim strValue As String = CType(value, String)
         If strValue.Length > 5 Then
            Throw New ArgumentException("value must be no more than 5 characters in length.", "value")
         End If
      End If
   End Sub 'OnInsert

   Protected Overrides Sub OnRemove(key As Object, value As Object)
      If Not GetType(System.String).IsAssignableFrom(key.GetType()) Then
         Throw New ArgumentException("key must be of type String.", "key")
      Else
         Dim strKey As String = CType(key, String)
         If strKey.Length > 5 Then
            Throw New ArgumentException("key must be no more than 5 characters in length.", "key")
         End If
      End If
   End Sub 'OnRemove

   Protected Overrides Sub OnSet(key As Object, oldValue As Object, newValue As Object)
      If Not GetType(System.String).IsAssignableFrom(key.GetType()) Then
         Throw New ArgumentException("key must be of type String.", "key")
      Else
         Dim strKey As String = CType(key, String)
         If strKey.Length > 5 Then
            Throw New ArgumentException("key must be no more than 5 characters in length.", "key")
         End If
      End If 
      If Not GetType(System.String).IsAssignableFrom(newValue.GetType()) Then
         Throw New ArgumentException("newValue must be of type String.", "newValue")
      Else
         Dim strValue As String = CType(newValue, String)
         If strValue.Length > 5 Then
            Throw New ArgumentException("newValue must be no more than 5 characters in length.", "newValue")
         End If
      End If
   End Sub 'OnSet

   Protected Overrides Sub OnValidate(key As Object, value As Object)
      If Not GetType(System.String).IsAssignableFrom(key.GetType()) Then
         Throw New ArgumentException("key must be of type String.", "key")
      Else
         Dim strKey As String = CType(key, String)
         If strKey.Length > 5 Then
            Throw New ArgumentException("key must be no more than 5 characters in length.", "key")
         End If
      End If 
      If Not GetType(System.String).IsAssignableFrom(value.GetType()) Then
         Throw New ArgumentException("value must be of type String.", "value")
      Else
         Dim strValue As String = CType(value, String)
         If strValue.Length > 5 Then
            Throw New ArgumentException("value must be no more than 5 characters in length.", "value")
         End If
      End If
   End Sub 'OnValidate 

End Class 'ShortStringDictionary

Public Class SamplesDictionaryBase
    Public Shared Sub Main()
        Dim myDictionary As DictionaryBase = New ShortStringDictionary()

        ' <Snippet2>
        For Each de As DictionaryEntry In myDictionary
            '...
        Next de
        ' </Snippet2>

        ' <Snippet3>
        Dim myCollection As ICollection = New ShortStringDictionary()
        SyncLock myCollection.SyncRoot
            For Each item In myCollection
                ' Insert your code here.
            Next item
        End SyncLock
        ' </Snippet3>
    End Sub
End Class
