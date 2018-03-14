' The following code example demonstrates how to add and remove elements from a StringDictionary.

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

      ' Displays the values in the StringDictionary.
      Console.WriteLine("Initial contents of the StringDictionary:")
      PrintKeysAndValues(myCol)

      ' Deletes an element.
      myCol.Remove("green")
      Console.WriteLine("The collection contains the following elements after removing ""green"":")
      PrintKeysAndValues(myCol)

      ' Clears the entire collection.
      myCol.Clear()
      Console.WriteLine("The collection contains the following elements after it is cleared:")
      PrintKeysAndValues(myCol)

   End Sub 'Main

   Public Shared Sub PrintKeysAndValues(myCol As StringDictionary)
      Dim de As DictionaryEntry

      Console.WriteLine("   KEY        VALUE")
      For Each de In  myCol
         Console.WriteLine("   {0,-10} {1}", de.Key, de.Value)
      Next de
      Console.WriteLine()

   End Sub 'PrintKeysAndValues

End Class 'SamplesStringDictionary 


'This code produces the following output.
'
'Initial contents of the StringDictionary:
'   KEY        VALUE
'   green      verde
'   red        rojo
'   blue       azul
'
'The collection contains the following elements after removing "green":
'   KEY        VALUE
'   red        rojo
'   blue       azul
'
'The collection contains the following elements after it is cleared:
'   KEY        VALUE
'

' </snippet1>
