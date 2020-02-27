' <Snippet1>
Imports System.Collections

Public Class SamplesHashtable    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new Hashtable.
        Dim myHT As New Hashtable()
        myHT.Add("1a", "The")
        myHT.Add("1b", "quick")
        myHT.Add("1c", "brown")
        myHT.Add("2a", "fox")
        myHT.Add("2b", "jumps")
        myHT.Add("2c", "over")
        myHT.Add("3a", "the")
        myHT.Add("3b", "lazy")
        myHT.Add("3c", "dog")
        
        ' Displays the Hashtable.
        Console.WriteLine("The Hashtable initially contains the following:")
        PrintKeysAndValues(myHT)
        
        ' Removes the element with the key "3b".
        myHT.Remove("3b")
        
        ' Displays the current state of the Hashtable.
        Console.WriteLine("After removing ""lazy"":")
        PrintKeysAndValues(myHT)
    End Sub    
    
    
    Public Shared Sub PrintKeysAndValues(myHT As Hashtable)
        For Each de As DictionaryEntry In myHT
            Console.WriteLine($"    {de.Key}:    {de.Value}")
        Next
        Console.WriteLine()
    End Sub
End Class


' This code produces the following output.
' 
'The Hashtable initially contains the following:
'    1a:    The
'    2c:    over
'    3c:    dog
'    1c:    brown
'    2b:    jumps
'    3b:    lazy
'    1b:    quick
'    2a:    fox
'    3a:    the

'After removing "lazy":
'    1a:    The
'    2c:    over
'    3c:    dog
'    1c:    brown
'    2b:    jumps
'    1b:    quick
'    2a:    fox
'    3a:    the

' </Snippet1>
