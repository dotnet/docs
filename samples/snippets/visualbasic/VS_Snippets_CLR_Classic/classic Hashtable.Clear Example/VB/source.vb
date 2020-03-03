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
        myHT.Add("five", "jumps")

        ' Displays the count and values of the Hashtable.
        Console.WriteLine("Initially,")
        Console.WriteLine($"   Count    : {myHT.Count}")
        Console.WriteLine("   Values:")
        PrintKeysAndValues(myHT)

        ' Clears the Hashtable.
        myHT.Clear()

        ' Displays the count and values of the Hashtable.
        Console.WriteLine("After Clear,")
        Console.WriteLine($"   Count    : {myHT.Count}")
        Console.WriteLine("   Values:")
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
' Initially,
'    Count    : 5
'    Values:
'         -KEY-   -VALUE-
'         two:    quick
'         five:   jumps
'         one:    The
'         three:  brown
'         four:   fox
'
' After Clear,
'    Count    : 0
'    Values:
'         -KEY-   -VALUE-
'

' </Snippet1>
