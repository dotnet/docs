' <Snippet1>
Imports System
Imports Microsoft.VisualBasic

Public Class SamplesArray    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new Array.
        Dim myArray As Array = Array.CreateInstance(GetType(String), 9)
        myArray.SetValue("The", 0)
        myArray.SetValue("quick", 1)
        myArray.SetValue("brown", 2)
        myArray.SetValue("fox", 3)
        myArray.SetValue("jumps", 4)
        myArray.SetValue("over", 5)
        myArray.SetValue("the", 6)
        myArray.SetValue("lazy", 7)
        myArray.SetValue("dog", 8)
        
        ' Displays the values of the Array.
        Console.WriteLine("The Array initially contains the " _
           + "following values:")
        PrintIndexAndValues(myArray)
        
        ' Reverses the sort of the values of the Array.
        Array.Reverse(myArray)
        
        ' Displays the values of the Array.
        Console.WriteLine("After reversing:")
        PrintIndexAndValues(myArray)
    End Sub 'Main
    
    
    
    Public Shared Sub PrintIndexAndValues(myArray As Array)
        Dim i As Integer
        For i = myArray.GetLowerBound(0) To myArray.GetUpperBound(0)
            Console.WriteLine(ControlChars.Tab + "[{0}]:" + ControlChars.Tab _
               + "{1}", i, myArray.GetValue(i))
        Next i
    End Sub
End Class

' This code produces the following output.
' 
' The Array initially contains the following values:
'     [0]:    The
'     [1]:    quick
'     [2]:    brown
'     [3]:    fox
'     [4]:    jumps
'     [5]:    over
'     [6]:    the
'     [7]:    lazy
'     [8]:    dog
' After reversing:
'     [0]:    dog
'     [1]:    lazy
'     [2]:    the
'     [3]:    over
'     [4]:    jumps
'     [5]:    fox
'     [6]:    brown
'     [7]:    quick
'     [8]:    The 
' </Snippet1>
