' The following code example copies the elements of a ListDictionary to an array.

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

      ' Displays the values in the ListDictionary in three different ways.
      Console.WriteLine("Initial contents of the ListDictionary:")
      PrintKeysAndValues(myCol)

      ' Copies the ListDictionary to an array with DictionaryEntry elements.
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

   End Sub 'Main

   Public Shared Sub PrintKeysAndValues(myCol As IDictionary)

      Console.WriteLine("   KEY                       VALUE")
      Dim de As DictionaryEntry
      For Each de In  myCol
         Console.WriteLine("   {0,-25} {1}", de.Key, de.Value)
      Next de
      Console.WriteLine()

   End Sub 'PrintKeysAndValues

End Class 'SamplesListDictionary 


'This code produces the following output.
'
'Initial contents of the ListDictionary:
'   KEY                       VALUE
'   Braeburn Apples           1.49
'   Fuji Apples               1.29
'   Gala Apples               1.49
'   Golden Delicious Apples   1.29
'   Granny Smith Apples       0.89
'   Red Delicious Apples      0.99
'
'Displays the elements in the array:
'   KEY                       VALUE
'   Braeburn Apples           1.49
'   Fuji Apples               1.29
'   Gala Apples               1.49
'   Golden Delicious Apples   1.29
'   Granny Smith Apples       0.89
'   Red Delicious Apples      0.99

' </snippet1>
