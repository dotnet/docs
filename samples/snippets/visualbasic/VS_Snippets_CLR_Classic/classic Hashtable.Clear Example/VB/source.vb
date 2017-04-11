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
        myHT.Add("five", "jumped")

        ' Displays the count and values of the Hashtable.
        Console.WriteLine("Initially,")
        Console.WriteLine("   Count    : {0}", myHT.Count)
        Console.WriteLine("   Values:")
        PrintKeysAndValues(myHT)

        ' Clears the Hashtable.
        myHT.Clear()

        ' Displays the count and values of the Hashtable.
        Console.WriteLine("After Clear,")
        Console.WriteLine("   Count    : {0}", myHT.Count)
        Console.WriteLine("   Values:")
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
' Initially,
'    Count    : 5
'    Values:
'         -KEY-   -VALUE-
'         two:    quick
'         three:  brown
'         four:   fox
'         five:   jumped
'         one:    The
'
' After Clear,
'    Count    : 0
'    Values:
'         -KEY-   -VALUE-
'

' </Snippet1>