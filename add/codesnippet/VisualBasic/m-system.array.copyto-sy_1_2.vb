Public Class SamplesArray2    
    
    Public Shared Sub Main()
        ' Creates and initializes the source Array.
        Dim myArrayZero As Array = Array.CreateInstance(GetType(String), 3)
        myArrayZero.SetValue("zero", 0)
        myArrayZero.SetValue("one", 1)
        
        ' Displays the source Array.
        Console.WriteLine("The array with lower bound=0 contains:")
        PrintIndexAndValues(myArrayZero)
        
        ' Creates and initializes the target Array.
        Dim myArrLen As Integer() = {4}
        Dim myArrLow As Integer() = {2}
        Dim myArrayTwo As Array = Array.CreateInstance(GetType(String), _
           myArrLen, myArrLow)
        myArrayTwo.SetValue("two", 2)
        myArrayTwo.SetValue("three", 3)
        myArrayTwo.SetValue("four", 4)
        myArrayTwo.SetValue("five", 5)
        
        ' Displays the target Array.
        Console.WriteLine("The array with lower bound=2 contains:")
        PrintIndexAndValues(myArrayTwo)
        
        ' Copies from the array with lower bound=0 to the array with lower bound=2.
        myArrayZero.CopyTo(myArrayTwo, 3)
        
        ' Displays the modified target Array.
        Console.WriteLine(ControlChars.Cr + "After copying to the target array from " _
           + "index 3:")
        PrintIndexAndValues(myArrayTwo)
    End Sub
    
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
' The array with lower bound=0 contains:
'     [0]:    zero
'     [1]:    one
'     [2]:    
' The array with lower bound=2 contains:
'     [2]:    two
'     [3]:    three
'     [4]:    four
'     [5]:    five
' 
' After copying to the target array from index 3:
'     [2]:    two
'     [3]:    zero
'     [4]:    one
'     [5]: 