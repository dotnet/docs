' The following example creates a read-only collection.
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

   ' Adds elements from an IDictionary into the new collection.
   Public Sub New(d As IDictionary, bReadOnly As [Boolean])
      Dim de As DictionaryEntry
      For Each de In  d
         Me.BaseAdd(CType(de.Key, [String]), de.Value)
      Next de
      Me.IsReadOnly = bReadOnly
   End Sub 'New

   ' Adds an entry to the collection.
   Public Sub Add(key As [String], value As [Object])
      Me.BaseAdd(key, value)
   End Sub 'Add

End Class 'MyCollection


Public Class SamplesNameObjectCollectionBase   

   Public Shared Sub Main()

      ' Creates and initializes a new MyCollection that is read-only.
      Dim d = New ListDictionary()
      d.Add("red", "apple")
      d.Add("yellow", "banana")
      d.Add("green", "pear")
      Dim myROCol As New MyCollection(d, True)

      ' Tries to add a new item.
      Try
         myROCol.Add("blue", "sky")
      Catch e As NotSupportedException
         Console.WriteLine(e.ToString())
      End Try

      ' Displays the keys and values of the MyCollection.
      Console.WriteLine("Read-Only Collection:")
      PrintKeysAndValues(myROCol)

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
'System.NotSupportedException: Collection is read-only.
'   at System.Collections.Specialized.NameObjectCollectionBase.BaseAdd(String name, Object value)
'   at SamplesNameObjectCollectionBase.Main()
'Read-Only Collection:
'[0] : red, apple
'[1] : yellow, banana
'[2] : green, pear

' </snippet1>
