' <Snippet1>
Module Example
    Public Sub Main()
        ' Define an array of Char values.
        Dim values() As Char = { ChrW(0), " "c, "*"c, "A"c, "a"c, 
                                 "{"c, "Æ"c }

        ' Convert each Char value to a Decimal.
        For Each value In values
           Dim decValue As Decimal = Decimal.op_Implicit(value)
           Console.WriteLine("'{0}' ({1}) --> {2} ({3})", value,
                             value.GetType().Name, decValue,
                             decValue.GetType().Name)      
        Next
    End Sub 
End Module
' The example displays the following output:
'       ' ' (Char) --> 0 (Decimal)
'       ' ' (Char) --> 32 (Decimal)
'       '*' (Char) --> 42 (Decimal)
'       'A' (Char) --> 65 (Decimal)
'       'a' (Char) --> 97 (Decimal)
'       '{' (Char) --> 123 (Decimal)
'       'Æ' (Char) --> 198 (Decimal)
'</Snippet1>

