Option Explicit On
Option Strict On

Class DoubleSample
    Public Shared Sub Main()
        '<snippet1> 
        Dim D As Double = 0
        '</snippet1>

        '<snippet2> 
        Console.WriteLine("A double is of type " + D.GetType().ToString() + ".")
        '</snippet2>

        '<snippet3> 
        Dim Done As Boolean = False
        Dim Inp As String
        Do

            Console.Write("Enter a real number: ")
            inp = Console.ReadLine()
            Try
                D = Double.Parse(inp)
                Console.WriteLine("You entered " + D.ToString() + ".")
                Done = True
            Catch e As FormatException
                Console.WriteLine("You did not enter a number.")
            Catch e As ArgumentNullException
                Console.WriteLine("You did not supply any input.")
            Catch e As OverflowException
                Console.WriteLine("The value you entered, {0}, is out of range.", inp)
            End Try
        Loop While Not Done
        '</snippet3>

        '<snippet4> 
        If D > Double.MaxValue Then
            Console.WriteLine("Your number is bigger than a double.")
        End If
        '</snippet4>

        '<snippet5> 
        If D < Double.MinValue Then
            Console.WriteLine("Your number is smaller than a double.")
        End If
        '</snippet5>

        '<snippet6> 
        Console.WriteLine("Epsilon, or the permittivity of a vacuum, has value " + Double.Epsilon.ToString())
        '</snippet6>

        '<snippet7> 
        Dim zero As Double = 0

        ' This condition will return false.
        If (0 / zero) = Double.NaN Then
            Console.WriteLine("0 / 0 can be tested with Double.NaN.")
        Else
            Console.WriteLine("0 / 0 cannot be tested with Double.NaN; use Double.IsNan() instead.")
        End If
        '</snippet7>

        '<snippet8> 
        ' This will return true.
        If Double.IsNaN(0 / zero) Then
            Console.WriteLine("Double.IsNan() can determine whether a value is not-a-number.")
        End If
        '</snippet8>

        '<snippet9> 
        ' This will equal Infinity.
        Console.WriteLine("10.0 minus NegativeInfinity equals " + (10 - Double.NegativeInfinity).ToString() + ".")
        '</snippet9>

        '<snippet10> 
        ' This will equal Infinity.
        Console.WriteLine("PositiveInfinity plus 10.0 equals " + (Double.PositiveInfinity + 10).ToString() + ".")
        '</snippet10>

        '<snippet11> 
        ' This will return "True".
        Console.Write("IsInfinity(3.0 / 0) = ")
        If Double.IsPositiveInfinity(3 / 0) Then
            Console.WriteLine("True.")
        Else
            Console.WriteLine("False.")
        End If
        '</snippet11>

        '<snippet12> 
        ' This will return "True".
        Console.Write("IsPositiveInfinity(4.0 / 0) = ")
        If Double.IsPositiveInfinity(4 / 0) Then
            Console.WriteLine("True.")
        Else
            Console.WriteLine("False.")
        End If
        '</snippet12>

        '<snippet13> 
        ' This will return "True".
        Console.Write("IsNegativeInfinity(-5.0 / 0) = ")
        If Double.IsNegativeInfinity(-5 / 0) Then
            Console.WriteLine("True.")
        Else
            Console.WriteLine("False.")
        End If
        '</snippet13>

        '<snippet14>
        Dim A As Double
        A = 500

        Dim Obj1 As Object
        '</snippet14>

        '<snippet15> 
        ' The variables point to the same objects.
        Dim Obj2 As Object
        Obj1 = A
        Obj2 = Obj1

        If Double.ReferenceEquals(Obj1, Obj2) Then
            Console.WriteLine("The variables point to the same double object.")
        Else
            Console.WriteLine("The variables point to different double objects.")
        End If
        '</snippet15>

        '<snippet16> 
        Obj1 = CType(450, Double)

        If A.CompareTo(Obj1) < 0 Then
            Console.WriteLine(A.ToString() + " is less than " + Obj1.ToString() + ".")
        End If

        If (A.CompareTo(Obj1) > 0) Then
            Console.WriteLine(A.ToString() + " is greater than " + Obj1.ToString() + ".")
        End If

        If (A.CompareTo(Obj1) = 0) Then
            Console.WriteLine(A.ToString() + " equals " + Obj1.ToString() + ".")
        End If
        '</snippet16>

        '<snippet17> 
        Obj1 = CType(500, Double)

        If A.Equals(Obj1) Then
            Console.WriteLine("The value type and reference type values are equal.")
        End If
        '</snippet17>
    End Sub
End Class

