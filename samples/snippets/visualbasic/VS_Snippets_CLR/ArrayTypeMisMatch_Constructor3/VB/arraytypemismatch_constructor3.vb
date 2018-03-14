' System.ArrayTypeMismatchException.ArrayTypeMismatchException

' The following example demonstrates the 'ArrayTypeMismatchException(string,innerException)'
' constructor of class ArrayTypeMismatchException class.It creates a 
' function which takes two arrays as arguments. It copies elements of
' one array to another array. If two arrays are of not same type then 
' an exception has been thrown. In the 'Catch' block a new 'WebException'
' object is created and thrown to the caller. That exception is caught
' in the calling method and the error message is displayed to the console.

' <Snippet1>

Imports System

Public Class ArrayTypeMisMatchConst

   Public Sub CopyArray(myArray As Array, myArray1 As Array)
      Try
         ' Copies the value of one array into another array.   
         myArray.SetValue(myArray1.GetValue(0), 0)
         myArray.SetValue(myArray1.GetValue(1), 1)
      Catch e As Exception
         ' Throw an exception of type 'ArrayTypeMismatchException' with a message and innerexception.
         Throw New ArrayTypeMismatchException("The Source and destination arrays are of not same type", e)
      End Try
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
         Console.WriteLine("The Exception Message is : " + e.Message)
         Console.WriteLine("The Inner exception is :" + e.InnerException.ToString())
      End Try
   End Sub 'Main
End Class 'ArrayTypeMisMatchConst
' </Snippet1>
