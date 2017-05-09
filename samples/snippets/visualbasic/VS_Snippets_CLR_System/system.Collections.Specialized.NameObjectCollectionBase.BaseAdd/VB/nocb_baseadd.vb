' The following example uses BaseAdd to create a new NameObjectCollectionBase with elements from another dictionary.
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

      ' Displays the keys and values of the MyCollection instance.
      Dim i As Integer
      For i = 0 To myCol.Count - 1
         Console.WriteLine("[{0}] : {1}, {2}", i, myCol(i).Key, myCol(i).Value)
      Next i

   End Sub 'Main 

End Class 'SamplesNameObjectCollectionBase


'This code produces the following output.
'
'[0] : red, apple
'[1] : yellow, banana
'[2] : green, pear

' </snippet1>
