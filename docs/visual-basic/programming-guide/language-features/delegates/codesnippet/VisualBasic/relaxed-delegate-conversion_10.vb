        ' Assignments to function delegate Del1.

        ' Valid AddressOf assignments with Option Strict on or off:

        ' Integer parameters of delegate and function match.
        Dim d13 As Del1 = AddressOf f1

        ' Integer delegate parameter widens to Long.
        Dim d14 As Del1 = AddressOf f2

        ' Short return in f3 widens to Integer.
        Dim d15 As Del1 = AddressOf f3