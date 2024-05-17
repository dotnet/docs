' <Snippet1>
Public Structure Complex
    Public re, im As Double
    
    Public Overrides Function Equals(ByVal obj As [Object]) As Boolean 
        Return TypeOf obj Is Complex AndAlso Me = CType(obj, Complex)
    End Function 
    
    Public Overrides Function GetHashCode() As Integer 
        Return Tuple.Create(re, im).GetHashCode()
    End Function 
    
    Public Shared Operator = (x As Complex, y As Complex) As Boolean
       Return x.re = y.re AndAlso x.im = y.im
    End Operator 
    
    Public Shared Operator <> (x As Complex, y As Complex) As Boolean
       Return Not (x = y)
    End Operator 
    
    Public Overrides Function ToString() As String
       Return String.Format("({0}, {1})", re, im)
    End Function 
End Structure

Class Example8
    Public Shared Sub Main()
        Dim cmplx1, cmplx2 As Complex

        cmplx1.re = 4.0
        cmplx1.im = 1.0

        cmplx2.re = 2.0
        cmplx2.im = 1.0

        Console.WriteLine("{0} <> {1}: {2}", cmplx1, cmplx2, cmplx1 <> cmplx2)
        Console.WriteLine("{0} = {1}: {2}", cmplx1, cmplx2, cmplx1.Equals(cmplx2))

        cmplx2.re = 4.0

        Console.WriteLine("{0} = {1}: {2}", cmplx1, cmplx2, cmplx1 = cmplx2)
        Console.WriteLine("{0} = {1}: {2}", cmplx1, cmplx2, cmplx1.Equals(cmplx2))
    End Sub
End Class
' The example displays the following output:
'       (4, 1) <> (2, 1): True
'       (4, 1) = (2, 1): False
'       (4, 1) = (4, 1): True
'       (4, 1) = (4, 1): True
' </Snippet1>
