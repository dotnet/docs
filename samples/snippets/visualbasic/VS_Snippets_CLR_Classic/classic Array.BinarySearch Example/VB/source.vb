' <Snippet1>
Imports System

Public Class SamplesArray
    Public Shared Sub Main()
        ' Creates and initializes a new Array.
        Dim myIntArray As Array = Array.CreateInstance( GetType(Int32), 5 )

        myIntArray.SetValue( 8, 0 )
        myIntArray.SetValue( 2, 1 )
        myIntArray.SetValue( 6, 2 )
        myIntArray.SetValue( 3, 3 )
        myIntArray.SetValue( 7, 4 )

        ' Do the required sort first
        Array.Sort(myIntArray)

        ' Displays the values of the Array.
        Console.WriteLine("The Int32 array contains the following:")
        PrintValues(myIntArray)

        ' Locates a specific object that does not exist in the Array.
        Dim myObjectOdd As Object = 1
        FindMyObject(myIntArray, myObjectOdd)

        ' Locates an object that exists in the Array.
        Dim myObjectEven As Object = 6
        FindMyObject(myIntArray, myObjectEven)
    End Sub

    Public Shared Sub FindMyObject(myArr As Array, myObject As Object)
        Dim myIndex As Integer = Array.BinarySearch(myArr, myObject)
        If  myIndex < 0 Then
            Console.WriteLine("The object to search for ({0}) is not found. The next larger object is at index {1}.", myObject, Not(myIndex))
        Else
            Console.WriteLine("The object to search for ({0}) is at index {1}.", myObject, myIndex)
        End If
    End Sub

    Public Shared Sub PrintValues(myArr As Array)
        Dim i As Integer = 0
        Dim cols As Integer = myArr.GetLength( myArr.Rank - 1 )
        For Each o As Object In myArr
            If i < cols Then
                i += 1
            Else
                Console.WriteLine()
                i = 1
            End If
            Console.Write( vbTab + "{0}", o)
        Next o
        Console.WriteLine()
    End Sub
End Class
' This code produces the following output.
'
' The Int32 array contains the following:
'         2       3       6       7       8
' The object to search for (1) is not found. The next larger object is at index 0
'
' The object to search for (6) is at index 2.
' </Snippet1>

