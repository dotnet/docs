' <Snippet1>
Imports System
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
        Console.WriteLine("  Count:    {0}", myHT.Count)
        Console.WriteLine("  Keys and Values:")
        PrintKeysAndValues(myHT)

    End Sub 'Main

    Public Shared Sub PrintKeysAndValues(myHT As Hashtable)
        Console.WriteLine(vbTab + "-KEY-" + vbTab + "-VALUE-")
        Dim de As DictionaryEntry
        For Each de In  myHT
            Console.WriteLine(vbTab + "{0}:" + vbTab + "{1}", de.Key, de.Value)
        Next de
        Console.WriteLine()
    End Sub 'PrintKeysAndValues

End Class 'SamplesHashtable 


' This code produces the following output.
' 
' myHT
'  Count:    3
'  Keys and Values:
'        -KEY-   -VALUE-
'        Second: World
'        Third:  !
'        First:  Hello
'

' </Snippet1>