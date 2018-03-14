' The following code example demonstrates several of the properties and methods of HybridDictionary.

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

      ' Copies the HybridDictionary to an array with DictionaryEntry elements.
      Dim myArr(myCol.Count) As DictionaryEntry
      myCol.CopyTo(myArr, 0)

      ' Displays the values in the array.
      Console.WriteLine("Displays the elements in the array:")
      Console.WriteLine("   KEY                       VALUE")
      Dim i As Integer
      For i = 0 To myArr.Length - 1
         Console.WriteLine("   {0,-25} {1}", myArr(i).Key, myArr(i).Value)
      Next i
      Console.WriteLine()

      ' Searches for a key.
      If myCol.Contains("Kiwis") Then
         Console.WriteLine("The collection contains the key ""Kiwis"".")
      Else
         Console.WriteLine("The collection does not contain the key ""Kiwis"".")
      End If
      Console.WriteLine()

      ' Deletes a key.
      myCol.Remove("Plums")
      Console.WriteLine("The collection contains the following elements after removing ""Plums"":")
      PrintKeysAndValues1(myCol)

      ' Clears the entire collection.
      myCol.Clear()
      Console.WriteLine("The collection contains the following elements after it is cleared:")
      PrintKeysAndValues1(myCol)

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
'   Strawberries              3.33
'   Yellow Bananas            0.79
'   Cranberries               5.98
'   Grapes                    1.99
'   Granny Smith Apples       0.89
'   Seedless Watermelon       0.49
'   Honeydew Melon            0.59
'   Red Delicious Apples      0.99
'   Navel Oranges             1.29
'   Fuji Apples               1.29
'   Plantain Bananas          1.49
'   Gala Apples               1.49
'   Pineapple                 1.49
'   Plums                     1.69
'   Braeburn Apples           1.49
'   Peaches                   1.99
'   Golden Delicious Apples   1.29
'   Nectarine                 1.99
'
'Displays the elements using the IDictionaryEnumerator:
'   KEY                       VALUE
'   Strawberries              3.33
'   Yellow Bananas            0.79
'   Cranberries               5.98
'   Grapes                    1.99
'   Granny Smith Apples       0.89
'   Seedless Watermelon       0.49
'   Honeydew Melon            0.59
'   Red Delicious Apples      0.99
'   Navel Oranges             1.29
'   Fuji Apples               1.29
'   Plantain Bananas          1.49
'   Gala Apples               1.49
'   Pineapple                 1.49
'   Plums                     1.69
'   Braeburn Apples           1.49
'   Peaches                   1.99
'   Golden Delicious Apples   1.29
'   Nectarine                 1.99
'
'Displays the elements using the Keys, Values, Count, and Item properties:
'   INDEX KEY                       VALUE
'   0     Strawberries              3.33
'   1     Yellow Bananas            0.79
'   2     Cranberries               5.98
'   3     Grapes                    1.99
'   4     Granny Smith Apples       0.89
'   5     Seedless Watermelon       0.49
'   6     Honeydew Melon            0.59
'   7     Red Delicious Apples      0.99
'   8     Navel Oranges             1.29
'   9     Fuji Apples               1.29
'   10    Plantain Bananas          1.49
'   11    Gala Apples               1.49
'   12    Pineapple                 1.49
'   13    Plums                     1.69
'   14    Braeburn Apples           1.49
'   15    Peaches                   1.99
'   16    Golden Delicious Apples   1.29
'   17    Nectarine                 1.99
'
'Displays the elements in the array:
'   KEY                       VALUE
'   Strawberries              3.33
'   Yellow Bananas            0.79
'   Cranberries               5.98
'   Grapes                    1.99
'   Granny Smith Apples       0.89
'   Seedless Watermelon       0.49
'   Honeydew Melon            0.59
'   Red Delicious Apples      0.99
'   Navel Oranges             1.29
'   Fuji Apples               1.29
'   Plantain Bananas          1.49
'   Gala Apples               1.49
'   Pineapple                 1.49
'   Plums                     1.69
'   Braeburn Apples           1.49
'   Peaches                   1.99
'   Golden Delicious Apples   1.29
'   Nectarine                 1.99
'
'The collection does not contain the key "Kiwis".
'
'The collection contains the following elements after removing "Plums":
'   KEY                       VALUE
'   Strawberries              3.33
'   Yellow Bananas            0.79
'   Cranberries               5.98
'   Grapes                    1.99
'   Granny Smith Apples       0.89
'   Seedless Watermelon       0.49
'   Honeydew Melon            0.59
'   Red Delicious Apples      0.99
'   Navel Oranges             1.29
'   Fuji Apples               1.29
'   Plantain Bananas          1.49
'   Gala Apples               1.49
'   Pineapple                 1.49
'   Braeburn Apples           1.49
'   Peaches                   1.99
'   Golden Delicious Apples   1.29
'   Nectarine                 1.99
'
'The collection contains the following elements after it is cleared:
'   KEY                       VALUE

' </snippet1>
