' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesArrayList    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new ArrayList. BinarySearch requires
        ' a sorted ArrayList.
        Dim myAL As New ArrayList()
        Dim i As Integer
        For i = 0 To 4
            myAL.Add(i * 2)
        Next i 

        ' Displays the ArrayList.
        Console.WriteLine("The Int32 ArrayList contains the following:")
        PrintValues(myAL)
        
        ' Locates a specific object that does not exist in the ArrayList.
        Dim myObjectOdd As Object = 3
        FindMyObject(myAL, myObjectOdd)
        
        ' Locates an object that exists in the ArrayList.
        Dim myObjectEven As Object = 6
        FindMyObject(myAL, myObjectEven)
    End Sub    
    
    Public Shared Sub FindMyObject(myList As ArrayList, myObject As Object)
        Dim myIndex As Integer = myList.BinarySearch(myObject)
        If myIndex < 0 Then
            Console.WriteLine("The object to search for ({0}) is not found. " _
               + "The next larger object is at index {1}.", myObject, _
               Not myIndex)
        Else
            Console.WriteLine("The object to search for ({0}) is at index " _
               + "{1}.", myObject, myIndex)
        End If
    End Sub
     
    Public Shared Sub PrintValues(myList As IEnumerable)
        Dim obj As [Object]
        For Each obj In  myList
            Console.Write("   {0}", obj)
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues
    
End Class

' This code produces the following output.
' 
' The Int32 ArrayList contains the following:
'     0    2    4    6    8
' The object to search for (3) is not found. The next larger object is at index 2.
' The object to search for (6) is at index 3. 
' </Snippet1>
