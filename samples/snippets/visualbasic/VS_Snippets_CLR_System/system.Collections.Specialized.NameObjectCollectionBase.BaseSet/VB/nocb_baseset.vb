' The following example uses BaseSet to set the value of a specific element.
' For an expanded version of this example, see the NameObjectCollectionBase class topic.

' <snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class MyCollection
   Inherits NameObjectCollectionBase

   ' Gets or sets the value at the specified index.
   Default Public Property Item(index As Integer) As [Object]
      Get
         Return Me.BaseGet(index)
      End Get
      Set
         Me.BaseSet(index, value)
      End Set
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

   ' Gets a String array that contains all the keys in the collection.
   Public ReadOnly Property AllKeys() As [String]()
      Get
         Return Me.BaseGetAllKeys()
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
      Console.WriteLine("Initial state of the collection:")
      PrintKeysAndValues2(myCol)
      Console.WriteLine()

      ' Sets the value at index 1.
      myCol(1) = "sunflower"
      Console.WriteLine("After setting the value at index 1:")
      PrintKeysAndValues2(myCol)
      Console.WriteLine()

      ' Sets the value associated with the key "red".
      myCol("red") = "tulip"
      Console.WriteLine("After setting the value associated with the key ""red"":")
      PrintKeysAndValues2(myCol)

   End Sub 'Main

   Public Shared Sub PrintKeysAndValues2(myCol As MyCollection)
      Dim s As [String]
      For Each s In  myCol.AllKeys
         Console.WriteLine("{0}, {1}", s, myCol(s))
      Next s
   End Sub 'PrintKeysAndValues2

End Class 'SamplesNameObjectCollectionBase 


'This code produces the following output.
'
'Initial state of the collection:
'red, apple
'yellow, banana
'green, pear
'
'After setting the value at index 1:
'red, apple
'yellow, sunflower
'green, pear
'
'After setting the value associated with the key "red":
'red, tulip
'yellow, sunflower
'green, pear

' </snippet1>
