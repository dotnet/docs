Imports System
Imports System.Runtime.InteropServices

'<Snippet31>
' Declares a managed structure for each unmanaged structure.
< StructLayout( LayoutKind.Sequential )> _
Public Structure MyPoint
   Public x As Integer
   Public y As Integer
   Public Sub New( x As Integer, y As Integer )
      Me.x = x
      Me.y = y
   End Sub 'New
End Structure 

< StructLayout( LayoutKind.Sequential, CharSet:=CharSet.Ansi )> _
Public Structure MyPerson
   Public first As String
   Public last As String
   Public Sub New( first As String, last As String )
      Me.first = first
      Me.last = last
   End Sub 'New
End Structure 

Public Class LibWrap
   ' Declares a managed prototype for an array of integers by value.
   ' The array size cannot be changed, but the array is copied back.
   Declare Function TestArrayOfInts Lib "..\LIB\PinvokeLib.dll" ( _
      <[In], Out> ByVal myArray() As Integer, ByVal size As Integer ) _
      As Integer

   ' Declares managed prototype for an array of integers by reference.
   ' The array size can change, but the array is not copied back 
   ' automatically because the marshaler does not know the resulting size.
   ' The copy must be performed manually.
   Declare Function TestRefArrayOfInts Lib "..\LIB\PinvokeLib.dll" ( _
      ByRef myArray As IntPtr, ByRef size As Integer ) As Integer

   ' Declares a managed prototype for a matrix of integers by value.
   Declare Function TestMatrixOfInts Lib "..\LIB\PinvokeLib.dll" ( _
      <[In], Out> ByVal matrix(,) As Integer, ByVal row As Integer ) _
      As Integer

   ' Declares a managed prototype for an array of strings by value.
   Declare Function TestArrayOfStrings Lib "..\LIB\PinvokeLib.dll" ( _
      <[In], Out> ByVal strArray() As String, ByVal size As Integer ) _
   As Integer
   
   ' Declares a managed prototype for an array of structures with 
   ' integers.
   Declare Function TestArrayOfStructs Lib "..\LIB\PinvokeLib.dll" ( _
      <[In], Out> ByVal pointArray() As MyPoint, _
      ByVal size As Integer ) As Integer
   
   ' Declares a managed prototype for an array of structures with strings.
   Declare Function TestArrayOfStructs2 Lib "..\LIB\PinvokeLib.dll" ( _
      <[In], Out> ByVal personArray() As MyPerson, ByVal size _
      As Integer ) As Integer
End Class 
'</Snippet31>

'<Snippet32>
Public Class App
   Public Shared Sub Main()
      ' array ByVal
      Dim array1(9) As Integer
      
      Console.WriteLine( "Integer array passed ByVal before call:" )
      Dim i As Integer
      For i = 0 To array1.Length - 1
         array1(i) = i
         Console.Write( " " & array1(i) )
      Next i
      
      Dim sum1 As Integer = LibWrap.TestArrayOfInts( array1, array1.Length )
      Console.WriteLine( ControlChars.CrLf & "Sum of elements:" & sum1 )
      Console.WriteLine( ControlChars.CrLf & "Integer array passed ByVal after call:" )
      For Each i In  array1
         Console.Write( " " & i )
      Next i
      
      ' array ByRef
      Dim array2(9) As Integer
      Dim arraySize As Integer = array2.Length
      Console.WriteLine( ControlChars.CrLf & ControlChars.CrLf & _
         "Integer array passed ByRef before call:" )
      For i = 0 To array2.Length - 1
         array2(i) = i
         Console.Write( " " & array2(i) )
      Next i
      Dim buffer As IntPtr = Marshal.AllocCoTaskMem( Marshal.SizeOf( _
         arraySize ) * array2.Length )
      Marshal.Copy( array2, 0, buffer, array2.Length )
      Dim sum2 As Integer = LibWrap.TestRefArrayOfInts( buffer, _
         arraySize )
      Console.WriteLine( ControlChars.CrLf & "Sum of elements:" & sum2 )
      
      If arraySize > 0 Then
         Dim arrayRes( arraySize - 1 ) As Integer
         Marshal.Copy( buffer, arrayRes, 0, arraySize )
         Marshal.FreeCoTaskMem( buffer )
         
         Console.WriteLine( ControlChars.CrLf & "Integer array passed ByRef after call:" )
         For Each i In  arrayRes
            Console.Write( " " & i )
         Next i
      Else
         Console.WriteLine( ControlChars.CrLf & "Array after call is empty" )
      End If
      
      ' matrix ByVal 
      Const [DIM] As Integer = 4
      Dim matrix([DIM], [DIM]) As Integer
      
      Console.WriteLine( ControlChars.CrLf & ControlChars.CrLf & _
         "Matrix before call:" )
      For i = 0 To [DIM]
         Dim j As Integer
         For j = 0 To [DIM]
            matrix(i, j) = j
            Console.Write( " " & matrix(i, j) )
         Next j
         Console.WriteLine( "" )
      Next i

      Dim sum3 As Integer = LibWrap.TestMatrixOfInts( matrix, [DIM] + 1 )
      Console.WriteLine( ControlChars.CrLf & "Sum of elements:" & sum3 )
      Console.WriteLine( ControlChars.CrLf & "Matrix after call:" )
      For i = 0 To [DIM]
         Dim j As Integer
         For j = 0 To [DIM]
            Console.Write( " " & matrix(i, j) )
         Next j
         Console.WriteLine( "" )
      Next i

      ' string array ByVal 
      Dim strArray As String() =  { "one", "two", "three", "four", _
        "five" }
      Console.WriteLine( ControlChars.CrLf & ControlChars.CrLf & _
        "String array before call:" )
      Dim s As String
      For Each s In  strArray
         Console.Write( " " & s )
      Next s 
      Dim lenSum As Integer = LibWrap.TestArrayOfStrings( _
         strArray, strArray.Length )
      Console.WriteLine( ControlChars.CrLf & _
         "Sum of string lengths:" & lenSum )
      Console.WriteLine( ControlChars.CrLf & "String array after call:" )
      For Each s In  strArray
         Console.Write( " " & s )
      Next s

      ' struct array ByVal 
      Dim points As MyPoint() = { New MyPoint(1, 1), New MyPoint(2, 2), _
         New MyPoint(3, 3) }
      Console.WriteLine( ControlChars.CrLf & ControlChars.CrLf & _
         "Points array before call:" )
      Dim p As MyPoint
      For Each p In  points
         Console.WriteLine( "x = {0}, y = {1}", p.x, p.y )
      Next p 
      Dim allSum As Integer = LibWrap.TestArrayOfStructs( points, _
         points.Length )
      Console.WriteLine( ControlChars.CrLf & "Sum of points:" & allSum )
      Console.WriteLine( ControlChars.CrLf & "Points array after call:" )
      For Each p In  points
         Console.WriteLine( "x = {0}, y = {1}", p.x, p.y )
      Next p 
      
      ' struct with strings array ByVal 
      Dim persons As MyPerson() =  { New MyPerson( "Kim", "Akers" ), _
         New MyPerson( "Adam", "Barr" ), _
         New MyPerson( "Jo", "Brown" )}
      Console.WriteLine( ControlChars.CrLf & ControlChars.CrLf & _
         "Persons array before call:" )
      Dim pe As MyPerson
      For Each pe In  persons
         Console.WriteLine( "first = {0}, last = {1}", pe.first, pe.last )
      Next pe 
      
      Dim namesSum As Integer = LibWrap.TestArrayOfStructs2( persons, _
         persons.Length )
      Console.WriteLine( ControlChars.CrLf & "Sum of name lengths:" & _
         namesSum )
      Console.WriteLine( ControlChars.CrLf & ControlChars.CrLf _
         & "Persons array after call:" )
      For Each pe In  persons
         Console.WriteLine( "first = {0}, last = {1}", pe.first, pe.last )
      Next pe
   End Sub 
End Class 
'</Snippet32>
