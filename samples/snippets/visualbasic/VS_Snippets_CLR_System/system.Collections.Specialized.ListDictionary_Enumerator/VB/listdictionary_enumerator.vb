' The following code example enumerates the elements of a ListDictionary.

' <snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class SamplesListDictionary   

   Public Shared Sub Main()

      ' Creates and initializes a new ListDictionary.
      Dim myCol As New ListDictionary()
      myCol.Add("Braeburn Apples", "1.49")
      myCol.Add("Fuji Apples", "1.29")
      myCol.Add("Gala Apples", "1.49")
      myCol.Add("Golden Delicious Apples", "1.29")
      myCol.Add("Granny Smith Apples", "0.89")
      myCol.Add("Red Delicious Apples", "0.99")

      ' Display the contents of the collection using For Each. This is the preferred method.
      Console.WriteLine("Displays the elements using For Each:")
      PrintKeysAndValues(myCol)

      ' Display the contents of the collection using the enumerator.
      Console.WriteLine("Displays the elements using the IDictionaryEnumerator:")
      PrintKeysAndValues2(myCol)

      ' Display the contents of the collection using the Keys, Values, Count, and Item properties.
      Console.WriteLine("Displays the elements using the Keys, Values, Count, and Item properties:")
      PrintKeysAndValues3(myCol)

   End Sub 'Main


   ' Uses the For Each statement which hides the complexity of the enumerator.
   ' NOTE: The For Each statement is the preferred way of enumerating the contents of a collection.
   Public Shared Sub PrintKeysAndValues(myCol As IDictionary)

      Console.WriteLine("   KEY                       VALUE")
      Dim de As DictionaryEntry
      For Each de In  myCol
         Console.WriteLine("   {0,-25} {1}", de.Key, de.Value)
      Next de
      Console.WriteLine()

   End Sub 'PrintKeysAndValues


   ' Uses the enumerator. 
   ' NOTE: The For Each statement is the preferred way of enumerating the contents of a collection.
   Public Shared Sub PrintKeysAndValues2(myCol As IDictionary)
      Dim myEnumerator As IDictionaryEnumerator = myCol.GetEnumerator()

      Console.WriteLine("   KEY                       VALUE")
      While myEnumerator.MoveNext()
         Console.WriteLine("   {0,-25} {1}", myEnumerator.Key, myEnumerator.Value)
      End While
      Console.WriteLine()

   End Sub 'PrintKeysAndValues2


   ' Uses the Keys, Values, Count, and Item properties.
   Public Shared Sub PrintKeysAndValues3(myCol As ListDictionary)
      Dim myKeys(myCol.Count) As [String]
      myCol.Keys.CopyTo(myKeys, 0)

      Console.WriteLine("   INDEX KEY                       VALUE")
      Dim i As Integer
      For i = 0 To myCol.Count - 1
         Console.WriteLine("   {0,-5} {1,-25} {2}", i, myKeys(i), myCol(myKeys(i)))
      Next i
      Console.WriteLine()

   End Sub 'PrintKeysAndValues3

End Class 'SamplesListDictionary 


'This code produces the following output.
'
'Displays the elements using For Each:
'   KEY                       VALUE
'   Braeburn Apples           1.49
'   Fuji Apples               1.29
'   Gala Apples               1.49
'   Golden Delicious Apples   1.29
'   Granny Smith Apples       0.89
'   Red Delicious Apples      0.99
'
'Displays the elements using the IDictionaryEnumerator:
'   KEY                       VALUE
'   Braeburn Apples           1.49
'   Fuji Apples               1.29
'   Gala Apples               1.49
'   Golden Delicious Apples   1.29
'   Granny Smith Apples       0.89
'   Red Delicious Apples      0.99
'
'Displays the elements using the Keys, Values, Count, and Item properties:
'   INDEX KEY                       VALUE
'   0     Braeburn Apples           1.49
'   1     Fuji Apples               1.29
'   2     Gala Apples               1.49
'   3     Golden Delicious Apples   1.29
'   4     Granny Smith Apples       0.89
'   5     Red Delicious Apples      0.99

' </snippet1>
