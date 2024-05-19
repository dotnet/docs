' Visual Basic .NET Document
Option Strict On

' <Snippet30>
<Assembly: CLSCompliant(True)>

Public Class Number(Of T As Structure)
    ' Use Double as the underlying type, since its range is a superset of
    ' the ranges of all numeric types except BigInteger.
    Protected number As Double

    Public Sub New(value As T)
        Try
            Me.number = Convert.ToDouble(value)
        Catch e As OverflowException
            Throw New ArgumentException("value is too large.", e)
        Catch e As InvalidCastException
            Throw New ArgumentException("The value parameter is not numeric.", e)
        End Try
    End Sub

    Public Function Add(value As T) As T
        Return CType(Convert.ChangeType(number + Convert.ToDouble(value), GetType(T)), T)
    End Function

    Public Function Subtract(value As T) As T
        Return CType(Convert.ChangeType(number - Convert.ToDouble(value), GetType(T)), T)
    End Function
End Class

Public Class FloatingPoint(Of T) : Inherits Number(Of T)
    Public Sub New(number As T)
        MyBase.New(number)
        If TypeOf number Is Single Or
                 TypeOf number Is Double Or
                 TypeOf number Is Decimal Then
            Me.number = Convert.ToDouble(number)
        Else
            throw new ArgumentException("The number parameter is not a floating-point number.")
        End If
    End Sub
End Class
' The attempt to compile the example displays the following output:
'    error BC32105: Type argument 'T' does not satisfy the 'Structure'
'    constraint for type parameter 'T'.
'    
'    Public Class FloatingPoint(Of T) : Inherits Number(Of T)
'                                                          ~
' </Snippet30>

Module Example
    Public Sub Main()
        Dim byt As New Number(Of Byte)(12)
        Console.WriteLine(byt.Add(12))

        Dim sbyt As New Number(Of SByte)(-3)
        Console.WriteLine(sbyt.Subtract(12))

        Dim ush As New Number(Of UShort)(16)
        Console.WriteLine(ush.Add(3))

        Dim dbl As New Number(Of Double)(Math.PI)
        Console.WriteLine(dbl.Add(1.0))

        Dim sng As New FloatingPoint(Of Single)(12.3)
        Console.WriteLine(sng.Add(3.0))

        '       Dim f2 As New FloatingPoint(Of Integer)(16)
        '       Console.WriteLine(f2.Add(6))
    End Sub
End Module

