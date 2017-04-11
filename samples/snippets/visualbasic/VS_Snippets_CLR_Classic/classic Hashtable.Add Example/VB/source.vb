' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesHashtable

    Public Shared Sub Main()

        ' Creates and initializes a new Hashtable.
        Dim myHT As New Hashtable()
        myHT.Add("one", "The")
        myHT.Add("two", "quick")
        myHT.Add("three", "brown")
        myHT.Add("four", "fox")

        ' Displays the Hashtable.
        Console.WriteLine("The Hashtable contains the following:")
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
' The Hashtable contains the following:
'         -KEY-   -VALUE-
'         two:    quick
'         three:  brown
'         four:   fox
'         one:    The
' 

' </Snippet1>