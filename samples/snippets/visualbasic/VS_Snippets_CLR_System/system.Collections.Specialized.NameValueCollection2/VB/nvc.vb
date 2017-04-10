' <snippet1>
' The following code example demonstrates several of the properties and methods of ListDictionary.

Imports System
Imports System.Collections
Imports System.Collections.Specialized


Public Class SamplesNameValueCollection

    Public Shared Sub Main()

        ' Creates and initializes a new NameValueCollection.
        Dim myCol As New NameValueCollection()
        myCol.Add("red", "rojo")
        myCol.Add("green", "verde")
        myCol.Add("blue", "azul")
        myCol.Add("red", "rouge")

        ' Displays the values in the NameValueCollection in two different ways.
        Console.WriteLine("Displays the elements using the AllKeys property and the Item (indexer) property:")
        PrintKeysAndValues(myCol)
        Console.WriteLine("Displays the elements using GetKey and Get:")
        PrintKeysAndValues2(myCol)

        ' Gets a value either by index or by key.
        Console.WriteLine("Index 1 contains the value {0}.", myCol(1))
        Console.WriteLine("Key ""red"" has the value {0}.", myCol("red"))
        Console.WriteLine()

        ' Copies the values to a string array and displays the string array.
        Dim myStrArr(myCol.Count) As String
        myCol.CopyTo(myStrArr, 0)
        Console.WriteLine("The string array contains:")
        Dim s As String
        For Each s In myStrArr
            Console.WriteLine("   {0}", s)
        Next s
        Console.WriteLine()

        ' Searches for a key and deletes it.
        myCol.Remove("green")
        Console.WriteLine("The collection contains the following elements after removing ""green"":")
        PrintKeysAndValues(myCol)

        ' Clears the entire collection.
        myCol.Clear()
        Console.WriteLine("The collection contains the following elements after it is cleared:")
        PrintKeysAndValues(myCol)

    End Sub 'Main

    Public Shared Sub PrintKeysAndValues(myCol As NameValueCollection)
        Console.WriteLine("   KEY        VALUE")
        Dim s As String
        For Each s In  myCol.AllKeys
            Console.WriteLine("   {0,-10} {1}", s, myCol(s))
        Next s
        Console.WriteLine()
    End Sub 'PrintKeysAndValues

    Public Shared Sub PrintKeysAndValues2(myCol As NameValueCollection)
        Console.WriteLine("   [INDEX] KEY        VALUE")
        Dim i As Integer
        For i = 0 To myCol.Count - 1
            Console.WriteLine("   [{0}]     {1,-10} {2}", i, myCol.GetKey(i), myCol.Get(i))
        Next i
        Console.WriteLine()
    End Sub 'PrintKeysAndValues2

End Class 'SamplesNameValueCollection 


'This code produces the following output.
'
'Displays the elements using the AllKeys property and the Item (indexer) property:
'   KEY        VALUE
'   red        rojo,rouge
'   green      verde
'   blue       azul
'
'Displays the elements using GetKey and Get:
'   [INDEX] KEY        VALUE
'   [0]     red        rojo,rouge
'   [1]     green      verde
'   [2]     blue       azul
'
'Index 1 contains the value verde.
'Key "red" has the value rojo,rouge.
'
'The string array contains:
'   red
'   green
'   blue
'
'
'The collection contains the following elements after removing "green":
'   KEY        VALUE
'   red        rojo,rouge
'   blue       azul
'
'The collection contains the following elements after it is cleared:
'   KEY        VALUE
'
'
' </snippet1>
