' <Snippet1>
Imports System.Collections

Public Class SamplesHashtable

    Public Shared Sub Main()

        ' Creates and initializes a new Hashtable.
        Dim myHT As New Hashtable()
        myHT.Add("First", "Hello")
        myHT.Add("Second", "World")
        myHT.Add("Third", "!")

        ' Displays the properties and values of the Hashtable.
        Console.WriteLine("myHT")
        Console.WriteLine($"  Count:    {myHT.Count}")
        Console.WriteLine("  Keys and Values:")
        PrintKeysAndValues(myHT)

    End Sub

    Public Shared Sub PrintKeysAndValues(myHT As Hashtable)
        Console.WriteLine(vbTab + "-KEY-" + vbTab + "-VALUE-")
        For Each de As DictionaryEntry In myHT
            Console.WriteLine(vbTab + "{0}:" + vbTab + "{1}", de.Key, de.Value)
        Next
        Console.WriteLine()
    End Sub

End Class


' This code produces the following output.
' 
' myHT
'  Count:    3
'  Keys and Values:
'        -KEY-   -VALUE-
'        Second: World
'        First:  Hello
'        Third:  !
'

' </Snippet1>
