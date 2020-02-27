' <Snippet1>
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
' The Hashtable contains the following:
'         -KEY-   -VALUE-
'         two:    quick
'         one:    The
'         three:  brown
'         four:   fox
' 

' </Snippet1>
