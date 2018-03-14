' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesHashtable

    Public Shared Sub Main()

        ' Creates and initializes a new Hashtable.
        Dim myHT As New Hashtable()
        myHT.Add(0, "zero")
        myHT.Add(1, "one")
        myHT.Add(2, "two")
        myHT.Add(3, "three")
        myHT.Add(4, "four")

        ' Displays the values of the Hashtable.
        Console.WriteLine("The Hashtable contains the following values:")
        PrintIndexAndKeysAndValues(myHT)

        ' Searches for a specific key.
        Dim myKey As Integer = 2
        Console.Write("The key ""{0}"" is ", myKey)
        If(myHT.ContainsKey(myKey))
           Console.WriteLine("in the Hashtable.")
        Else
           Console.WriteLine("NOT in the Hashtable.")
        End If

        myKey = 6
        Console.Write("The key ""{0}"" is ", myKey)
        If(myHT.ContainsKey(myKey))
           Console.WriteLine(" in the Hashtable.")
        Else
           Console.WriteLine(" NOT in the Hashtable.")
        End If

        ' Searches for a specific value.
        Dim myValue As String = "three"
        Console.Write("The value ""{0}"" is ", myValue)
        If(myHT.ContainsValue(myValue))
           Console.WriteLine(" in the Hashtable.")
        Else
           Console.WriteLine(" NOT in the Hashtable.")
        End If

        myValue = "nine"
        Console.Write("The value ""{0}"" is ", myValue)
        If(myHT.ContainsValue(myValue))
           Console.WriteLine(" in the Hashtable.")
        Else
           Console.WriteLine(" NOT in the Hashtable.")
        End If

    End Sub 'Main

    Public Shared Sub PrintIndexAndKeysAndValues(myHT As Hashtable)
        Dim i As Integer = 0
        Console.WriteLine(vbTab + "-INDEX-" + vbTab + "-KEY-" + vbTab + "-VALUE-")
        Dim de As DictionaryEntry
        For Each de In  myHT
            Console.WriteLine(vbTab + "[{0}]:" + vbTab + "{1}" + vbTab + "{2}", i, de.Key, de.Value)
            i = i + 1
        Next de
        Console.WriteLine()
    End Sub 'PrintIndexAndKeysAndValues

End Class 'SamplesHashtable 


' This code produces the following output.
' 
' The Hashtable contains the following values:
'         -INDEX- -KEY-   -VALUE-
'         [0]:    4       four
'         [1]:    3       three
'         [2]:    2       two
'         [3]:    1       one
'         [4]:    0       zero
'
' The key "2" is in the Hashtable.
' The key "6" is NOT in the Hashtable.
' The value "three" is in the Hashtable.
' The value "nine" is NOT in the Hashtable.

' </Snippet1>