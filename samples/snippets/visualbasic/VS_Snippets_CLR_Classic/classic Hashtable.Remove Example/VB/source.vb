' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesHashtable    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new Hashtable.
        Dim myHT As New Hashtable()
        myHT.Add("1a", "The")
        myHT.Add("1b", "quick")
        myHT.Add("1c", "brown")
        myHT.Add("2a", "fox")
        myHT.Add("2b", "jumped")
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
        Dim de As DictionaryEntry
        For Each de In  myHT
            Console.WriteLine("    {0}:    {1}", de.Key, de.Value)
        Next de
        Console.WriteLine()
    End Sub
End Class


' This code produces the following output.
' 
'The Hashtable initially contains the following:
'    2c:    over
'    3a:    the
'    2b:    jumped
'    3b:    lazy
'    1b:    quick
'    3c:    dog
'    2a:    fox
'    1c:    brown
'    1a:    The
'
'After removing "lazy":
'    2c:    over
'    3a:    the
'    2b:    jumped
'    1b:    quick
'    3c:    dog
'    2a:    fox
'    1c:    brown
'    1a:    The

' </Snippet1>
