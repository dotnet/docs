' The following code example searches for an element in a StringDictionary.

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

      ' Searches for a key.
      If myCol.ContainsKey("red") Then
         Console.WriteLine("The collection contains the key ""red"".")
      Else
         Console.WriteLine("The collection does not contain the key ""red"".")
      End If
      Console.WriteLine()

      ' Searches for a value.
      If myCol.ContainsValue("amarillo") Then
         Console.WriteLine("The collection contains the value ""amarillo"".")
      Else
         Console.WriteLine("The collection does not contain the value ""amarillo"".")
      End If
      Console.WriteLine()

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
'The collection contains the key "red".
'
'The collection does not contain the value "amarillo".

' </snippet1>
