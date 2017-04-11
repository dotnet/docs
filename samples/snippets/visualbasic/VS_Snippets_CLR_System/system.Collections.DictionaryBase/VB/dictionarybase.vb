' The following code example implements the DictionaryBase class and uses that implementation to create a dictionary of String keys and values that have a Length of 5 or less.

' <Snippet1>
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

      ' Creates and initializes a new DictionaryBase.
      Dim mySSC As New ShortStringDictionary()

      ' Adds elements to the collection.
      mySSC.Add("One", "a")
      mySSC.Add("Two", "ab")
      mySSC.Add("Three", "abc")
      mySSC.Add("Four", "abcd")
      mySSC.Add("Five", "abcde")

      ' Display the contents of the collection using For Each. This is the preferred method.
      Console.WriteLine("Contents of the collection (using For Each):")
      PrintKeysAndValues1(mySSC)

      ' Display the contents of the collection using the enumerator.
      Console.WriteLine("Contents of the collection (using enumerator):")
      PrintKeysAndValues2(mySSC)

      ' Display the contents of the collection using the Keys property and the Item property.
      Console.WriteLine("Initial contents of the collection (using Keys and Item):")
      PrintKeysAndValues3(mySSC)

      ' Tries to add a value that is too long.
      Try
          mySSC.Add("Ten", "abcdefghij")
      Catch e As ArgumentException
          Console.WriteLine(e.ToString())
      End Try

      ' Tries to add a key that is too long.
      Try
          mySSC.Add("Eleven", "ijk")
      Catch e As ArgumentException
          Console.WriteLine(e.ToString())
      End Try

      Console.WriteLine()

      ' Searches the collection with Contains.
      Console.WriteLine("Contains ""Three"": {0}", mySSC.Contains("Three"))
      Console.WriteLine("Contains ""Twelve"": {0}", mySSC.Contains("Twelve"))
      Console.WriteLine()

      ' Removes an element from the collection.
      mySSC.Remove("Two")

      ' Displays the contents of the collection.
      Console.WriteLine("After removing ""Two"":")
      PrintKeysAndValues1(mySSC)

    End Sub 'Main


    ' Uses the For Each statement which hides the complexity of the enumerator.
    ' NOTE: The For Each statement is the preferred way of enumerating the contents of a collection.
    Public Shared Sub PrintKeysAndValues1(myCol As ShortStringDictionary)
      Dim myDE As DictionaryEntry
      For Each myDE In  myCol
          Console.WriteLine("   {0,-5} : {1}", myDE.Key, myDE.Value)
      Next myDE
      Console.WriteLine()
    End Sub 'PrintKeysAndValues1


    ' Uses the enumerator. 
    ' NOTE: The For Each statement is the preferred way of enumerating the contents of a collection.
    Public Shared Sub PrintKeysAndValues2(myCol As ShortStringDictionary)
      Dim myDE As DictionaryEntry
      Dim myEnumerator As System.Collections.IEnumerator = myCol.GetEnumerator()
      While myEnumerator.MoveNext()
          If Not (myEnumerator.Current Is Nothing) Then
            myDE = CType(myEnumerator.Current, DictionaryEntry)
            Console.WriteLine("   {0,-5} : {1}", myDE.Key, myDE.Value)
          End If
      End While
      Console.WriteLine()
    End Sub 'PrintKeysAndValues2


    ' Uses the Keys property and the Item property.
    Public Shared Sub PrintKeysAndValues3(myCol As ShortStringDictionary)
      Dim myKeys As ICollection = myCol.Keys
      Dim k As String
      For Each k In  myKeys
          Console.WriteLine("   {0,-5} : {1}", k, myCol(k))
      Next k
      Console.WriteLine()
    End Sub 'PrintKeysAndValues3

End Class 'SamplesDictionaryBase 


'This code produces the following output.
'
'Contents of the collection (using For Each):
'   Three : abc
'   Five  : abcde
'   Two   : ab
'   One   : a
'   Four  : abcd
'
'Contents of the collection (using enumerator):
'   Three : abc
'   Five  : abcde
'   Two   : ab
'   One   : a
'   Four  : abcd
'
'Initial contents of the collection (using Keys and Item):
'   Three : abc
'   Five  : abcde
'   Two   : ab
'   One   : a
'   Four  : abcd
'
'System.ArgumentException: value must be no more than 5 characters in length.
'Parameter name: value
'   at ShortStringDictionary.OnValidate(Object key, Object value)
'   at System.Collections.DictionaryBase.System.Collections.IDictionary.Add(Object key, Object value)
'   at SamplesDictionaryBase.Main()
'System.ArgumentException: key must be no more than 5 characters in length.
'Parameter name: key
'   at ShortStringDictionary.OnValidate(Object key, Object value)
'   at System.Collections.DictionaryBase.System.Collections.IDictionary.Add(Object key, Object value)
'   at SamplesDictionaryBase.Main()
'
'Contains "Three": True
'Contains "Twelve": False
'
'After removing "Two":
'   Three : abc
'   Five  : abcde
'   One   : a
'   Four  : abcd

' </Snippet1>