Option Explicit On
Option Strict On

Imports System

Namespace SingleSnippet

    Class SingleSample
        Public Sub New()
            '<snippet1> 
            Dim S As Single = 0
            '</snippet1>

            '<snippet2> 
            Console.WriteLine("A Single is of type " + S.GetType().ToString() + ".")
            '</snippet2>

            '<snippet3> 
            Dim Done As Boolean = False
            Dim Inp As String
            Do

                Console.Write("Enter a real number: ")
                Inp = Console.ReadLine()
                Try
                    S = Single.Parse(Inp)
                    Console.WriteLine("You entered " + S.ToString() + ".")
                    Done = True
                Catch E As FormatException
                    Console.WriteLine("You did not enter a number.")
                Catch E As Exception
                    Console.WriteLine("An exception occurred while parsing your response: " + E.ToString())
                End Try
            Loop While Not Done
            '</snippet3>

            '<snippet4> 
            If S > Single.MaxValue Then
                Console.WriteLine("Your number is larger than a Single.")
            End If
            '</snippet4>

            '<snippet5> 
            If S < Single.MinValue Then
                Console.WriteLine("Your number is smaller than a Single.")
            End If
            '</snippet5>

            '<snippet6> 
            Console.WriteLine("Epsilon, or the permittivity of a vacuum, has value " + Single.Epsilon.ToString())
            '</snippet6>

            '<snippet7> 
            Dim zero As Single = 0

            ' This condition will return false.
            If (0 / zero) = Single.NaN Then
                Console.WriteLine("0 / 0 can be tested with Single.NaN.")
            Else
                Console.WriteLine("0 / 0 cannot be tested with Single.NaN; use Single.IsNan() instead.")
            End If
            '</snippet7>

            '<snippet8> 
            ' This will return true.
            If Single.IsNaN(0 / zero) Then
                Console.WriteLine("Single.IsNan() can determine whether a value is not-a-number.")
            End If
            '</snippet8>

            '<snippet9> 
            ' This will equal Infinity.
            Console.WriteLine("10.0 minus NegativeInfinity equals " + (10 - Single.NegativeInfinity).ToString() + ".")
            '</snippet9>

            '<snippet10> 
            ' This will equal Infinity.
            Console.WriteLine("PositiveInfinity plus 10.0 equals " + (Single.PositiveInfinity + 10).ToString() + ".")
            '</snippet10>

            '<snippet11> 
            ' This will return "True".
            Console.Write("IsInfinity(3.0 / 0) = ")
            If Single.IsPositiveInfinity(3 / 0) Then
                Console.WriteLine("True.")
            Else
                Console.WriteLine("False.")
            End If
            '</snippet11>

            '<snippet12> 
            ' This will return True.
            Console.Write("IsPositiveInfinity(4.0 / 0) = ")
            If Single.IsPositiveInfinity(4 / 0) Then
                Console.WriteLine("True.")
            Else
                Console.WriteLine("False.")
            End If
            '</snippet12>

            '<snippet13> 
            ' This will return True.
            Console.Write("IsNegativeInfinity(-5.0 / 0) = ")
            If Single.IsNegativeInfinity(-5 / 0) Then
                Console.WriteLine("True.")
            Else
                Console.WriteLine("False.")
            End If
            '</snippet13>

            '<snippet14>
            Dim A As Single
            A = 500

            Dim Obj1 As Object
            '</snippet14>

            '<snippet15> 
            ' The variables point to the same objects.
            Dim Obj2 As Object
            Obj1 = A
            Obj2 = Obj1

            If Single.ReferenceEquals(Obj1, Obj2) Then
                Console.WriteLine("The variables point to the same Single object.")
            Else
                Console.WriteLine("The variables point to different Single objects.")
            End If
            '</snippet15>

            '<snippet16> 
            Obj1 = CType(450, Single)

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
            Obj1 = CType(500, Single)

            If A.Equals(Obj1) Then
                Console.WriteLine("The value type and reference type values are equal.")
            End If
            '</snippet17>
        End Sub
    End Class
End Namespace

Class EntryPoint
    Shared Sub Main()
        Dim A As New SingleSnippet.SingleSample()
    End Sub
End Class