' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesSortedList    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new SortedList.
        Dim mySL As New SortedList()
        mySL.Add("one", "The")
        mySL.Add("two", "quick")
        mySL.Add("three", "brown")
        mySL.Add("four", "fox")
        mySL.Add("five", "jumped")
        
        ' Displays the count, capacity and values of the SortedList.
        Console.WriteLine("Initially,")
        Console.WriteLine("   Count    : {0}", mySL.Count)
        Console.WriteLine("   Capacity : {0}", mySL.Capacity)
        Console.WriteLine("   Values:")
        PrintKeysAndValues(mySL)
        
        ' Trims the SortedList.
        mySL.TrimToSize()
        
        ' Displays the count, capacity and values of the SortedList.
        Console.WriteLine("After TrimToSize,")
        Console.WriteLine("   Count    : {0}", mySL.Count)
        Console.WriteLine("   Capacity : {0}", mySL.Capacity)
        Console.WriteLine("   Values:")
        PrintKeysAndValues(mySL)
        
        ' Clears the SortedList.
        mySL.Clear()
        
        ' Displays the count, capacity and values of the SortedList.
        Console.WriteLine("After Clear,")
        Console.WriteLine("   Count    : {0}", mySL.Count)
        Console.WriteLine("   Capacity : {0}", mySL.Capacity)
        Console.WriteLine("   Values:")
        PrintKeysAndValues(mySL)
        
        ' Trims the SortedList again.
        mySL.TrimToSize()
        
        ' Displays the count, capacity and values of the SortedList.
        Console.WriteLine("After the second TrimToSize,")
        Console.WriteLine("   Count    : {0}", mySL.Count)
        Console.WriteLine("   Capacity : {0}", mySL.Capacity)
        Console.WriteLine("   Values:")
        PrintKeysAndValues(mySL)
    End Sub   
    
    
    Public Shared Sub PrintKeysAndValues(myList As SortedList)
        Console.WriteLine(ControlChars.Tab & "-KEY-" & ControlChars.Tab & _
           "-VALUE-")
        Dim i As Integer
        For i = 0 To myList.Count - 1
            Console.WriteLine(ControlChars.Tab & "{0}:" & ControlChars.Tab & _
               "{1}", myList.GetKey(i), myList.GetByIndex(i))
        Next i
        Console.WriteLine()
    End Sub
End Class

' This code produces the following output.
' 
' Initially,
'    Count    : 5
'    Capacity : 16
'    Values:
'     -KEY-    -VALUE-
'     five:    jumped
'     four:    fox
'     one:    The
'     three:    brown
'     two:    quick
'
' After TrimToSize,
'    Count    : 5
'    Capacity : 5
'    Values:
'     -KEY-    -VALUE-
'     five:    jumped
'     four:    fox
'     one:    The
'     three:    brown
'     two:    quick
' 
' After Clear,
'    Count    : 0
'    Capacity : 16
'    Values:
'     -KEY-    -VALUE-
' '
' After the second TrimToSize,
'    Count    : 0
'    Capacity : 16
'    Values:
'     -KEY-    -VALUE-
 
' </Snippet1>
