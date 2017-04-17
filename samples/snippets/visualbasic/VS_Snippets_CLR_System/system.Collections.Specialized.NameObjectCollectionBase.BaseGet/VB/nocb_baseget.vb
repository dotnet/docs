' The following example uses BaseGetKey and BaseGet to get specific keys and values.
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

   ' Gets or sets the value associated with the specified key.
   Default Public Property Item(key As [String]) As [Object]
      Get
         Return Me.BaseGet(key)
      End Get
      Set
         Me.BaseSet(key, value)
      End Set
   End Property

   ' Adds elements from an IDictionary into the new collection.
   Public Sub New(d As IDictionary)
      Dim de As DictionaryEntry
      For Each de In  d
         Me.BaseAdd(CType(de.Key, [String]), de.Value)
      Next de
   End Sub 'New

End Class 'MyCollection


Public Class SamplesNameObjectCollectionBase   

   Public Shared Sub Main()

      ' Creates and initializes a new MyCollection instance.
      Dim d = New ListDictionary()
      d.Add("red", "apple")
      d.Add("yellow", "banana")
      d.Add("green", "pear")
      Dim myCol As New MyCollection(d)
      Console.WriteLine("Initial state of the collection (Count = {0}):", myCol.Count)
      PrintKeysAndValues(myCol)

      ' Gets specific keys and values.
      Console.WriteLine("The key at index 0 is {0}.", myCol(0).Key)
      Console.WriteLine("The value at index 0 is {0}.", myCol(0).Value)
      Console.WriteLine("The value associated with the key ""green"" is {0}.", myCol("green"))

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
'Initial state of the collection (Count = 3):
'[0] : red, apple
'[1] : yellow, banana
'[2] : green, pear
'The key at index 0 is red.
'The value at index 0 is apple.
'The value associated with the key "green" is pear.

' </snippet1>
