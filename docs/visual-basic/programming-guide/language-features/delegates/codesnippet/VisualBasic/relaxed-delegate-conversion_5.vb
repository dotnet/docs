        ' Valid only when Option Strict is set to Off.

        ' Integer does not widen to Short in the parameter.
        Dim d9 As Del1 = Function(n As Short) n

        ' Long does not widen to Integer in the return type.
        Dim d10 As Del1 = Function(n As Integer) CLng(n)