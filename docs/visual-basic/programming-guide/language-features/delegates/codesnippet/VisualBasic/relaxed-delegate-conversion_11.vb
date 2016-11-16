        ' If Option Strict is Off, parameter specifications for f4 can be omitted.
        Dim d16 As Del1 = AddressOf f4

        ' Function d16 still requires a single argument, however, as specified
        ' by Del1.
        Console.WriteLine(d16(5))

        ' Not valid.
        'Console.WriteLine(d16())
        'Console.WriteLine(d16(5, 3))