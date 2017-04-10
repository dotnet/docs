' System.ArrayTypeMismatchException.ArrayTypeMismatchException

' The following example demonstrates the 'ArrayTypeMismatchException()' 
' constructor of class ArrayTypeMismatchException class.It creates a 
' function which takes two arrays as arguments. It checks whether the 
' two arrays are of same type or not. If two arrays are not of same type
' then a new 'ArrayTypeMismatchException' object is created and thrown. 
' That exception is caught in the calling method.
' <Snippet1>
Imports System

Public Class ArrayTypeMisMatchConst
   Public Sub CopyArray(myArray As Array, myArray1 As Array)
      
      Dim typeArray1 As String = myArray.GetType().ToString()
      Dim typeArray2 As String = myArray1.GetType().ToString()
      ' Check whether the two arrays are of same type or not.
      If typeArray1 = typeArray2 Then
         ' Copy the values from one array to another.
         myArray.SetValue("Name: " + myArray1.GetValue(0), 0)
         myArray.SetValue("Name: " + myArray1.GetValue(1), 1)
      Else
         ' Throw an exception of type 'ArrayTypeMismatchException'.
         Throw New ArrayTypeMismatchException()
      End If
   End Sub 'CopyArray

   Shared Sub Main()
      Try
         Dim myStringArray(2) As String
         myStringArray.SetValue("Jones", 0)
         myStringArray.SetValue("John", 1)
         Dim myIntArray(2) As Integer
         Dim myArrayType As New ArrayTypeMisMatchConst()
         myArrayType.CopyArray(myStringArray, myIntArray)
      Catch e As ArrayTypeMismatchException
         Console.WriteLine("The Exception is :" + e.ToString())
      End Try 
   End Sub 'Main
End Class 'ArrayTypeMisMatchConst
' </Snippet1>