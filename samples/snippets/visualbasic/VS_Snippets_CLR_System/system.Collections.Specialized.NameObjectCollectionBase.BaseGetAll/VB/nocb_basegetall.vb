' The following example uses BaseGetAllKeys and BaseGetAllValues to get an array of the keys or an array of the values.
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
         Me.BaseAdd(CType(de.Key, String), de.Value)
      Next de
   End Sub 'New

   ' Gets a String array that contains all the keys in the collection.
   Public ReadOnly Property AllKeys() As String()
      Get
         Return Me.BaseGetAllKeys()
      End Get
   End Property

   ' Gets an Object array that contains all the values in the collection.
   Public ReadOnly Property AllValues() As Array
      Get
         Return Me.BaseGetAllValues()
      End Get
   End Property

   ' Gets a String array that contains all the values in the collection.
   Public ReadOnly Property AllStringValues() As String()
      Get
         Return CType(Me.BaseGetAllValues(GetType(String)), String())
      End Get
   End Property

End Class 'MyCollection


Public Class SamplesNameObjectCollectionBase   

   Public Shared Sub Main()

      ' Creates and initializes a new MyCollection instance.
      Dim d As New ListDictionary()
      d.Add("red", "apple")
      d.Add("yellow", "banana")
      d.Add("green", "pear")
      Dim myCol As New MyCollection(d)
      Console.WriteLine("Initial state of the collection (Count = {0}):", myCol.Count)
      PrintKeysAndValues(myCol)

      ' Displays the list of keys.
      Console.WriteLine("The list of keys:")
      Dim s As String
      For Each s In  myCol.AllKeys
         Console.WriteLine("   {0}", s)
      Next s

      ' Displays the list of values of type Object.
      Console.WriteLine("The list of values (Object):")
      Dim o As Object
      For Each o In  myCol.AllValues
         Console.WriteLine("   {0}", o.ToString())
      Next o

      ' Displays the list of values of type String.
      Console.WriteLine("The list of values (String):")
      For Each s In  myCol.AllValues
         Console.WriteLine("   {0}", s)
      Next s

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
'The list of keys:
'   red
'   yellow
'   green
'The list of values (Object):
'   apple
'   banana
'   pear
'The list of values (String):
'   apple
'   banana
'   pear

' </snippet1>
