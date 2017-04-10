' The following code example enumerates the elements of a HybridDictionary.

' <snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class SamplesHybridDictionary   

   Public Shared Sub Main()

      ' Creates and initializes a new HybridDictionary.
      Dim myCol As New HybridDictionary()
      myCol.Add("Braeburn Apples", "1.49")
      myCol.Add("Fuji Apples", "1.29")
      myCol.Add("Gala Apples", "1.49")
      myCol.Add("Golden Delicious Apples", "1.29")
      myCol.Add("Granny Smith Apples", "0.89")
      myCol.Add("Red Delicious Apples", "0.99")
      myCol.Add("Plantain Bananas", "1.49")
      myCol.Add("Yellow Bananas", "0.79")
      myCol.Add("Strawberries", "3.33")
      myCol.Add("Cranberries", "5.98")
      myCol.Add("Navel Oranges", "1.29")
      myCol.Add("Grapes", "1.99")
      myCol.Add("Honeydew Melon", "0.59")
      myCol.Add("Seedless Watermelon", "0.49")
      myCol.Add("Pineapple", "1.49")
      myCol.Add("Nectarine", "1.99")
      myCol.Add("Plums", "1.69")
      myCol.Add("Peaches", "1.99")

      ' Display the contents of the collection using For Each. This is the preferred method.
      Console.WriteLine("Displays the elements using For Each:")
      PrintKeysAndValues1(myCol)

      ' Display the contents of the collection using the enumerator.
      Console.WriteLine("Displays the elements using the IDictionaryEnumerator:")
      PrintKeysAndValues2(myCol)

      ' Display the contents of the collection using the Keys, Values, Count, and Item properties.
      Console.WriteLine("Displays the elements using the Keys, Values, Count, and Item properties:")
      PrintKeysAndValues3(myCol)

   End Sub 'Main


   ' Uses the For Each statement which hides the complexity of the enumerator.
   ' NOTE: The For Each statement is the preferred way of enumerating the contents of a collection.
   Public Shared Sub PrintKeysAndValues1(myCol As IDictionary)

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
   Public Shared Sub PrintKeysAndValues3(myCol As HybridDictionary)
      Dim myKeys(myCol.Count) As [String]
      myCol.Keys.CopyTo(myKeys, 0)

      Console.WriteLine("   INDEX KEY                       VALUE")
      Dim i As Integer
      For i = 0 To myCol.Count - 1
         Console.WriteLine("   {0,-5} {1,-25} {2}", i, myKeys(i), myCol(myKeys(i)))
      Next i
      Console.WriteLine()

   End Sub 'PrintKeysAndValues3

End Class 'SamplesHybridDictionary 


'This code produces the following output.
'
'Displays the elements using For Each:
'   KEY                       VALUE
'   Seedless Watermelon       0.49
'   Nectarine                 1.99
'   Cranberries               5.98
'   Plantain Bananas          1.49
'   Honeydew Melon            0.59
'   Pineapple                 1.49
'   Strawberries              3.33
'   Grapes                    1.99
'   Braeburn Apples           1.49
'   Peaches                   1.99
'   Red Delicious Apples      0.99
'   Golden Delicious Apples   1.29
'   Yellow Bananas            0.79
'   Granny Smith Apples       0.89
'   Gala Apples               1.49
'   Plums                     1.69
'   Navel Oranges             1.29
'   Fuji Apples               1.29
'
'Displays the elements using the IDictionaryEnumerator:
'   KEY                       VALUE
'   Seedless Watermelon       0.49
'   Nectarine                 1.99
'   Cranberries               5.98
'   Plantain Bananas          1.49
'   Honeydew Melon            0.59
'   Pineapple                 1.49
'   Strawberries              3.33
'   Grapes                    1.99
'   Braeburn Apples           1.49
'   Peaches                   1.99
'   Red Delicious Apples      0.99
'   Golden Delicious Apples   1.29
'   Yellow Bananas            0.79
'   Granny Smith Apples       0.89
'   Gala Apples               1.49
'   Plums                     1.69
'   Navel Oranges             1.29
'   Fuji Apples               1.29
'
'Displays the elements using the Keys, Values, Count, and Item properties:
'   INDEX KEY                       VALUE
'   0     Seedless Watermelon       0.49
'   1     Nectarine                 1.99
'   2     Cranberries               5.98
'   3     Plantain Bananas          1.49
'   4     Honeydew Melon            0.59
'   5     Pineapple                 1.49
'   6     Strawberries              3.33
'   7     Grapes                    1.99
'   8     Braeburn Apples           1.49
'   9     Peaches                   1.99
'   10    Red Delicious Apples      0.99
'   11    Golden Delicious Apples   1.29
'   12    Yellow Bananas            0.79
'   13    Granny Smith Apples       0.89
'   14    Gala Apples               1.49
'   15    Plums                     1.69
'   16    Navel Oranges             1.29
'   17    Fuji Apples               1.29

' </snippet1>
