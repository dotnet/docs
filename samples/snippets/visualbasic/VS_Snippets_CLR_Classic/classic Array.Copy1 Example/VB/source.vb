' <Snippet1>
Imports System
Imports Microsoft.VisualBasic

Public Class SamplesArray    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new Array of type Int32.
        Dim myIntArray As Array = _
           Array.CreateInstance(GetType(System.Int32), 5)
        Dim i As Integer
        For i = myIntArray.GetLowerBound(0) To myIntArray.GetUpperBound(0)
            myIntArray.SetValue(i + 1, i)
        Next i 
        ' Creates and initializes a new Array of type Object.
        Dim myObjArray As Array = _
           Array.CreateInstance(GetType(System.Object), 5)
        For i = myObjArray.GetLowerBound(0) To myObjArray.GetUpperBound(0)
            myObjArray.SetValue(i + 26, i)
        Next i 
        ' Displays the initial values of both arrays.
        Console.WriteLine("Int32 array:")
        PrintValues(myIntArray)
        Console.WriteLine("Object array:")
        PrintValues(myObjArray)
        
        ' Copies the first element from the Int32 array to the Object array.
        Array.Copy(myIntArray, myIntArray.GetLowerBound(0), myObjArray, _
           myObjArray.GetLowerBound(0), 1)
        
        ' Copies the last two elements from the Object array to the Int32 array.
        Array.Copy(myObjArray, myObjArray.GetUpperBound(0) - 1, myIntArray, _
           myIntArray.GetUpperBound(0) - 1, 2)
        
        ' Displays the values of the modified arrays.
        Console.WriteLine("Int32 array - Last two elements should now be " _
           + "the same as Object array:")
        PrintValues(myIntArray)
        Console.WriteLine("Object array - First element should now be the " _
           + "same as Int32 array:")
        PrintValues(myObjArray)
    End Sub
    
    Public Shared Sub PrintValues(myArr As Array)
        Dim myEnumerator As System.Collections.IEnumerator = _
           myArr.GetEnumerator()
        Dim i As Integer = 0
        Dim cols As Integer = myArr.GetLength((myArr.Rank - 1))
        While myEnumerator.MoveNext()
            If i < cols Then
                i += 1
            Else
                Console.WriteLine()
                i = 1
            End If
            Console.Write(ControlChars.Tab + "{0}", myEnumerator.Current)
        End While
        Console.WriteLine()
    End Sub
End Class

' This code produces the following output.
' 
' Int32 array:
'     1    2    3    4    5
' Object array:
'     26    27    28    29    30
' Int32 array - Last two elements should now be the same as Object array:
'     1    2    3    29    30
' Object array - First element should now be the same as Int32 array:
'     1    27    28    29    30
' </Snippet1>
