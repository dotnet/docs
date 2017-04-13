' The following code example enumerates the elements of a StringDictionary.

' <snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class SamplesStringDictionary

   Public Shared Sub Main()

      ' Creates and initializes a new StringDictionary.
      Dim myCol As New StringDictionary()
      myCol.Add("red", "rojo")
      myCol.Add("green", "verde")
      myCol.Add("blue", "azul")

      ' Display the contents of the collection using For Each. This is the preferred method.
      Console.WriteLine("Displays the elements using For Each:")
      PrintKeysAndValues1(myCol)

      ' Display the contents of the collection using the enumerator.
      Console.WriteLine("Displays the elements using the IEnumerator:")
      PrintKeysAndValues2(myCol)

      ' Display the contents of the collection using the Keys, Values, Count, and Item properties.
      Console.WriteLine("Displays the elements using the Keys, Values, Count, and Item properties:")
      PrintKeysAndValues3(myCol)

   End Sub 'Main


   ' Uses the For Each statement which hides the complexity of the enumerator.
   ' NOTE: The For Each statement is the preferred way of enumerating the contents of a collection.
   Public Shared Sub PrintKeysAndValues1(myCol As StringDictionary)
      Console.WriteLine("   KEY                       VALUE")
      Dim de As DictionaryEntry
      For Each de In  myCol
         Console.WriteLine("   {0,-25} {1}", de.Key, de.Value)
      Next de
      Console.WriteLine()
   End Sub 'PrintKeysAndValues1


   ' Uses the enumerator. 
   ' NOTE: The For Each statement is the preferred way of enumerating the contents of a collection.
   Public Shared Sub PrintKeysAndValues2(myCol As StringDictionary)
      Dim myEnumerator As IEnumerator = myCol.GetEnumerator()
      Dim de As DictionaryEntry
      Console.WriteLine("   KEY                       VALUE")
      While myEnumerator.MoveNext()
         de = CType(myEnumerator.Current, DictionaryEntry)
         Console.WriteLine("   {0,-25} {1}", de.Key, de.Value)
      End While
      Console.WriteLine()
   End Sub 'PrintKeysAndValues2


   ' Uses the Keys, Values, Count, and Item properties.
   Public Shared Sub PrintKeysAndValues3(myCol As StringDictionary)
      Dim myKeys(myCol.Count) As String
      myCol.Keys.CopyTo(myKeys, 0)

      Console.WriteLine("   INDEX KEY                       VALUE")
      Dim i As Integer
      For i = 0 To myCol.Count - 1
         Console.WriteLine("   {0,-5} {1,-25} {2}", i, myKeys(i), myCol(myKeys(i)))
      Next i
      Console.WriteLine()
   End Sub 'PrintKeysAndValues3

End Class 'SamplesStringDictionary 


'This code produces the following output.
'
'Displays the elements using For Each:
'   KEY                       VALUE
'   red                       rojo
'   blue                      azul
'   green                     verde
'
'Displays the elements using the IEnumerator:
'   KEY                       VALUE
'   red                       rojo
'   blue                      azul
'   green                     verde
'
'Displays the elements using the Keys, Values, Count, and Item properties:
'   INDEX KEY                       VALUE
'   0     red                       rojo
'   1     blue                      azul
'   2     green                     verde

' </snippet1>