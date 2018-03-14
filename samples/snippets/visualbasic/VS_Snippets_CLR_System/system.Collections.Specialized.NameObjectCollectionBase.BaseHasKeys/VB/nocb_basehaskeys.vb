' The following example uses BaseHasKeys to determine if the collection contains keys that are not a null reference.
' For an expanded version of this example, see the NameObjectCollectionBase class topic.

' <snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class MyCollection
   Inherits NameObjectCollectionBase

   Private _de As New DictionaryEntry()

   ' Gets a key-and-value pair (DictionaryEntry) using an index.
   Default Public ReadOnly Property Item(index As Integer) As DictionaryEntry
      Get
         _de.Key = Me.BaseGetKey(index)
         _de.Value = Me.BaseGet(index)
         Return _de
      End Get
   End Property

   ' Creates an empty collection.
   Public Sub New()
   End Sub 'New

   ' Adds an entry to the collection.
   Public Sub Add(key As [String], value As [Object])
      Me.BaseAdd(key, value)
   End Sub 'Add

   ' Gets a value indicating whether the collection contains keys that are not a null reference.
   Public ReadOnly Property HasKeys() As [Boolean]
      Get
         Return Me.BaseHasKeys()
      End Get
   End Property

End Class 'MyCollection


Public Class SamplesNameObjectCollectionBase   

   Public Shared Sub Main()

      ' Creates an empty MyCollection instance.
      Dim myCol As New MyCollection()
      Console.WriteLine("Initial state of the collection (Count = {0}):", myCol.Count)
      PrintKeysAndValues(myCol)
      Console.WriteLine("HasKeys? {0}", myCol.HasKeys)

      Console.WriteLine()

      ' Adds an item to the collection.
      myCol.Add("blue", "sky")
      Console.WriteLine("Initial state of the collection (Count = {0}):", myCol.Count)
      PrintKeysAndValues(myCol)
      Console.WriteLine("HasKeys? {0}", myCol.HasKeys)

   End Sub 'Main

   Public Shared Sub PrintKeysAndValues(myCol As MyCollection)
      Dim i As Integer
      For i = 0 To myCol.Count - 1
         Console.WriteLine("[{0}] : {1}, {2}", i, myCol(i).Key, myCol(i).Value)
      Next i
   End Sub 'PrintKeysAndValues

End Class 'SamplesNameObjectCollectionBase 


'This code produces the following output.
'
'Initial state of the collection (Count = 0):
'HasKeys? False
'
'Initial state of the collection (Count = 1):
'[0] : blue, sky
'HasKeys? True

' </snippet1>
