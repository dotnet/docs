'************************************************
Option Infer On
Option Strict Off

Module Module2
    Sub Tester()
        '8 goes after 2
        '<Snippet8>
        ' Valid only when Option Strict is off:

        Dim d4 As Del1 = Function(m As String) CInt(m)
        Dim d5 As Del1 = Function(m As Short) m
        '</Snippet8>

        '<Snippet4>
        ' Valid only when Option Strict is set to Off.

        ' Integer does not widen to Short in the parameter.
        Dim d9 As Del1 = Function(n As Short) n

        ' Long does not widen to Integer in the return type.
        Dim d10 As Del1 = Function(n As Integer) CLng(n)
        '</Snippet4>

        '<Snippet14>
        ' If Option Strict is Off, parameter specifications for f4 can be omitted.
        Dim d16 As Del1 = AddressOf f4

        ' Function d16 still requires a single argument, however, as specified
        ' by Del1.
        Console.WriteLine(d16(5))

        ' Not valid.
        'Console.WriteLine(d16())
        'Console.WriteLine(d16(5, 3))
        '</Snippet14>
    End Sub
End Module
