            ' This code requires Option Strict Off
            Dim MyNumber As Integer
            MyNumber = Int(99.8)   ' Returns 99.
            MyNumber = Fix(99.8)   ' Returns 99.

            MyNumber = Int(-99.8)  ' Returns -100.
            MyNumber = Fix(-99.8)  ' Returns -99.

            MyNumber = Int(-99.2)  ' Returns -100.
            MyNumber = Fix(-99.2)  ' Returns -99.