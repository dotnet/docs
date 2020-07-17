' **********************************************************
Option Infer On

Module Module1
    '<Snippet1>
    ' Definition of delegate Del1.
    Delegate Function Del1(ByVal arg As Integer) As Integer
    '</Snippet1>

    '<Snippet5>
    ' Definition of delegate Del2, which has two parameters.
    Delegate Function Del2(ByVal arg1 As Integer, ByVal arg2 As String) As Integer
    '</Snippet5>

    '<Snippet7>
    ' Definitions of f1, f2, f3, and f4.
    Function f1(ByVal m As Integer) As Integer
    End Function

    Function f2(ByVal m As Long) As Integer
    End Function

    Function f3(ByVal m As Integer) As Short
    End Function

    Function f4() As Integer
    End Function
    '</Snippet7>

    '<Snippet10>
    ' Definition of Sub delegate Del3.
    Delegate Sub Del3(ByVal arg1 As Integer)

    ' Definition of function doubler, which both displays and returns the
    ' value of its integer parameter.
    Function doubler(ByVal p As Integer) As Integer
        Dim times2 = 2 * p
        Console.WriteLine("Value of p: " & p)
        Console.WriteLine("Double p:   " & times2)
        Return times2
    End Function
    '</Snippet10>

    ' From Lambda Expressions topic
    '<Snippet12>
    ' Definition of function delegate ExampleDel.
    Delegate Function ExampleDel(ByVal arg1 As Integer,
                                 ByVal arg2 As String) As Integer
    '</Snippet12>

    Sub Main()
        '<Snippet2>
        ' Valid lambda expression assignments with Option Strict on or off:

        ' Integer matches Integer.
        Dim d1 As Del1 = Function(m As Integer) 3

        ' Integer widens to Long
        Dim d2 As Del1 = Function(m As Long) 3

        ' Integer widens to Double
        Dim d3 As Del1 = Function(m As Double) 3
        '</Snippet2>

        '<Snippet3>
        ' Valid return types with Option Strict on:

        ' Integer matches Integer.
        Dim d6 As Del1 = Function(m As Integer) m

        ' Short widens to Integer.
        Dim d7 As Del1 = Function(m As Long) CShort(m)

        ' Byte widens to Integer.
        Dim d8 As Del1 = Function(m As Double) CByte(m)
        '</Snippet3>

        '<Snippet6>
        ' The assigned lambda expression specifies no parameters, even though
        ' Del2 has two parameters. Because the assigned function in this 
        ' example is a lambda expression, Option Strict can be on or off.
        ' Compare the declaration of d16, where a standard function is assigned.
        Dim d11 As Del2 = Function() 3

        ' The parameters are still there, however, as defined in the delegate.
        Console.WriteLine(d11(5, "five"))

        ' Not valid.
        ' Console.WriteLine(d11())
        ' Console.WriteLine(d11(5))
        '</Snippet6>

        '<Snippet15>
        ' Not valid.
        'Dim d12 As Del2 = Function(p As Integer) p
        '</Snippet15>

        '<Snippet9>
        ' Assignments to function delegate Del1.

        ' Valid AddressOf assignments with Option Strict on or off:

        ' Integer parameters of delegate and function match.
        Dim d13 As Del1 = AddressOf f1

        ' Integer delegate parameter widens to Long.
        Dim d14 As Del1 = AddressOf f2

        ' Short return in f3 widens to Integer.
        Dim d15 As Del1 = AddressOf f3
        '</Snippet9>


        '<Snippet11>
        ' You can assign the function to the Sub delegate:
        Dim d17 As Del3 = AddressOf doubler

        ' You can then call d17 like a regular Sub procedure.
        d17(5)

        ' You cannot call d17 as a function. It is a Sub, and has no 
        ' return value.
        ' Not valid.
        'Console.WriteLine(d17(5))
        '</Snippet11>

        ' From Lambda Expressions
        '<Snippet13>
        ' Declaration of del as an instance of ExampleDel, with no data 
        ' type specified for the parameters, m and s.
        Dim del As ExampleDel = Function(m, s) m

        ' Valid call to del, sending in an integer and a string.
        Console.WriteLine(del(7, "up"))

        ' Neither of these calls is valid. Function del requires an integer
        ' argument and a string argument.
        ' Not valid.
        ' Console.WriteLine(del(7, 3))
        ' Console.WriteLine(del("abc"))
        '</Snippet13>
    End Sub

End Module
