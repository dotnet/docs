Imports System.Runtime.InteropServices

'<Snippet31>
' Declares a managed structure for each unmanaged structure.
<StructLayout(LayoutKind.Sequential)>
Public Structure MyPoint
    Public x As Integer
    Public y As Integer
    Public Sub New(x As Integer, y As Integer)
        Me.x = x
        Me.y = y
    End Sub
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
Public Structure MyPerson
    Public first As String
    Public last As String
    Public Sub New(first As String, last As String)
        Me.first = first
        Me.last = last
    End Sub
End Structure

Friend Class NativeMethods
    ' Declares a managed prototype for an array of integers by value.
    ' The array size cannot be changed, but the array is copied back.
    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function TestArrayOfInts(
        <[In], Out> ByVal myArray() As Integer, ByVal size As Integer) _
        As Integer
    End Function

    ' Declares managed prototype for an array of integers by reference.
    ' The array size can change, but the array is not copied back 
    ' automatically because the marshaler does not know the resulting size.
    ' The copy must be performed manually.
    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function TestRefArrayOfInts(
        ByRef myArray As IntPtr, ByRef size As Integer) As Integer
    End Function

    ' Declares a managed prototype for a matrix of integers by value.
    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function TestMatrixOfInts(
        <[In], Out> ByVal matrix(,) As Integer, ByVal row As Integer) _
        As Integer
    End Function

    ' Declares a managed prototype for an array of strings by value.
    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function TestArrayOfStrings(
        <[In], Out> ByVal strArray() As String, ByVal size As Integer) _
        As Integer
    End Function

    ' Declares a managed prototype for an array of structures with 
    ' integers.
    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function TestArrayOfStructs(
        <[In], Out> ByVal pointArray() As MyPoint, ByVal size As Integer) _
        As Integer
    End Function

    ' Declares a managed prototype for an array of structures with strings.
    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function TestArrayOfStructs2(
        <[In], Out> ByVal personArray() As MyPerson, ByVal size As Integer) _
        As Integer
    End Function
End Class
'</Snippet31>

'<Snippet32>
Public Class App
    Public Shared Sub Main()
        ' array ByVal
        Dim array1(9) As Integer

        Console.WriteLine("Integer array passed ByVal before call:")
        Dim i As Integer
        For i = 0 To array1.Length - 1
            array1(i) = i
            Console.Write(" " & array1(i))
        Next i

        Dim sum1 As Integer = NativeMethods.TestArrayOfInts(array1, array1.Length)
        Console.WriteLine(ControlChars.CrLf & "Sum of elements:" & sum1)
        Console.WriteLine(ControlChars.CrLf & "Integer array passed ByVal after call:")
        For Each i In array1
            Console.Write(" " & i)
        Next i

        ' array ByRef
        Dim array2(9) As Integer
        Dim arraySize As Integer = array2.Length
        Console.WriteLine(ControlChars.CrLf & ControlChars.CrLf &
            "Integer array passed ByRef before call:")
        For i = 0 To array2.Length - 1
            array2(i) = i
            Console.Write(" " & array2(i))
        Next i
        Dim buffer As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(
            arraySize) * array2.Length)
        Marshal.Copy(array2, 0, buffer, array2.Length)
        Dim sum2 As Integer = NativeMethods.TestRefArrayOfInts(buffer,
            arraySize)
        Console.WriteLine(ControlChars.CrLf & "Sum of elements:" & sum2)

        If arraySize > 0 Then
            Dim arrayRes(arraySize - 1) As Integer
            Marshal.Copy(buffer, arrayRes, 0, arraySize)
            Marshal.FreeCoTaskMem(buffer)

            Console.WriteLine(ControlChars.CrLf & "Integer array passed ByRef after call:")
            For Each i In arrayRes
                Console.Write(" " & i)
            Next i
        Else
            Console.WriteLine(ControlChars.CrLf & "Array after call is empty")
        End If

        ' matrix ByVal 
        Const [DIM] As Integer = 4
        Dim matrix([DIM], [DIM]) As Integer

        Console.WriteLine(ControlChars.CrLf & ControlChars.CrLf &
            "Matrix before call:")
        For i = 0 To [DIM]
            Dim j As Integer
            For j = 0 To [DIM]
                matrix(i, j) = j
                Console.Write(" " & matrix(i, j))
            Next j
            Console.WriteLine("")
        Next i

        Dim sum3 As Integer = NativeMethods.TestMatrixOfInts(matrix, [DIM] + 1)
        Console.WriteLine(ControlChars.CrLf & "Sum of elements:" & sum3)
        Console.WriteLine(ControlChars.CrLf & "Matrix after call:")
        For i = 0 To [DIM]
            Dim j As Integer
            For j = 0 To [DIM]
                Console.Write(" " & matrix(i, j))
            Next j
            Console.WriteLine("")
        Next i

        ' string array ByVal 
        Dim strArray As String() = {"one", "two", "three", "four",
            "five"}
        Console.WriteLine(ControlChars.CrLf & ControlChars.CrLf &
            "String array before call:")
        Dim s As String
        For Each s In strArray
            Console.Write(" " & s)
        Next s
        Dim lenSum As Integer = NativeMethods.TestArrayOfStrings(
            strArray, strArray.Length)
        Console.WriteLine(ControlChars.CrLf &
            "Sum of string lengths:" & lenSum)
        Console.WriteLine(ControlChars.CrLf & "String array after call:")
        For Each s In strArray
            Console.Write(" " & s)
        Next s

        ' struct array ByVal 
        Dim points As MyPoint() = {New MyPoint(1, 1), New MyPoint(2, 2),
            New MyPoint(3, 3)}
        Console.WriteLine(ControlChars.CrLf & ControlChars.CrLf &
            "Points array before call:")
        Dim p As MyPoint
        For Each p In points
            Console.WriteLine($"x = {p.x}, y = {p.y}")
        Next p
        Dim allSum As Integer = NativeMethods.TestArrayOfStructs(points,
            points.Length)
        Console.WriteLine(ControlChars.CrLf & "Sum of points:" & allSum)
        Console.WriteLine(ControlChars.CrLf & "Points array after call:")
        For Each p In points
            Console.WriteLine($"x = {p.x}, y = {p.y}")
        Next p

        ' struct with strings array ByVal 
        Dim persons As MyPerson() = {New MyPerson("Kim", "Akers"),
            New MyPerson("Adam", "Barr"),
            New MyPerson("Jo", "Brown")}
        Console.WriteLine(ControlChars.CrLf & ControlChars.CrLf &
            "Persons array before call:")
        Dim pe As MyPerson
        For Each pe In persons
            Console.WriteLine($"first = {pe.first}, last = {pe.last}")
        Next pe

        Dim namesSum As Integer = NativeMethods.TestArrayOfStructs2(persons,
            persons.Length)
        Console.WriteLine(ControlChars.CrLf & "Sum of name lengths:" &
            namesSum)
        Console.WriteLine(ControlChars.CrLf & ControlChars.CrLf _
            & "Persons array after call:")
        For Each pe In persons
            Console.WriteLine($"first = {pe.first}, last = {pe.last}")
        Next pe
    End Sub
End Class
'</Snippet32>
