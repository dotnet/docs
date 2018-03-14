' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesBitArray

    Public Shared Sub Main()

        ' Creates and initializes the source BitArray.
        Dim myBA As New BitArray(4)
        myBA(0) = True
        myBA(1) = True
        myBA(2) = True
        myBA(3) = True

        ' Creates and initializes the one-dimensional target Array of type Boolean.
        Dim myBoolArray(7) As Boolean
        myBoolArray(0) = False
        myBoolArray(1) = False

        ' Displays the values of the target Array.
        Console.WriteLine("The target Boolean Array contains the following (before and after copying):")
        PrintValues(myBoolArray)

        ' Copies the entire source BitArray to the target BitArray, starting at index 3.
        myBA.CopyTo(myBoolArray, 3)

        ' Displays the values of the target Array.
        PrintValues(myBoolArray)

        ' Creates and initializes the one-dimensional target Array of type integer.
        Dim myIntArray(7) As Integer
        myIntArray(0) = 42
        myIntArray(1) = 43

        ' Displays the values of the target Array.
        Console.WriteLine("The target integer Array contains the following (before and after copying):")
        PrintValues(myIntArray)

        ' Copies the entire source BitArray to the target BitArray, starting at index 3.
        myBA.CopyTo(myIntArray, 3)

        ' Displays the values of the target Array.
        PrintValues(myIntArray)

        ' Creates and initializes the one-dimensional target Array of type byte.
        Dim myByteArray As Array = Array.CreateInstance(GetType(Byte), 8)
        myByteArray.SetValue(System.Convert.ToByte(10), 0)
        myByteArray.SetValue(System.Convert.ToByte(11), 1)

        ' Displays the values of the target Array.
        Console.WriteLine("The target byte Array contains the following (before and after copying):")
        PrintValues(myByteArray)

        ' Copies the entire source BitArray to the target BitArray, starting at index 3.
        myBA.CopyTo(myByteArray, 3)

        ' Displays the values of the target Array.
        PrintValues(myByteArray)

        ' Returns an exception if the array is not of type Boolean, integer or byte.
        Try
            Dim myStringArray As Array = Array.CreateInstance(GetType(String), 8)
            myStringArray.SetValue("Hello", 0)
            myStringArray.SetValue("World", 1)
            myBA.CopyTo(myStringArray, 3)
        Catch myException As Exception
            Console.WriteLine("Exception: " + myException.ToString())
        End Try

    End Sub 'Main

    Public Shared Sub PrintValues(myArr As IEnumerable)
        Dim obj As [Object]
        For Each obj In  myArr
            Console.Write("{0,8}", obj)
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues

End Class 'SamplesBitArray 


' This code produces the following output.
' 
' The target Boolean Array contains the following (before and after copying):
'    False   False   False   False   False   False   False   False
'    False   False   False    True    True    True    True   False
' The target integer Array contains the following (before and after copying):
'       42      43       0       0       0       0       0       0
'       42      43       0      15       0       0       0       0
' The target byte Array contains the following (before and after copying):
'       10      11       0       0       0       0       0       0
'       10      11       0      15       0       0       0       0
' Exception: System.ArgumentException: Only supported array types for CopyTo on BitArrays are Boolean[], Int32[] and Byte[].
'    at System.Collections.BitArray.CopyTo(Array array, Int32 index)
'    at SamplesBitArray.Main()

' </Snippet1>