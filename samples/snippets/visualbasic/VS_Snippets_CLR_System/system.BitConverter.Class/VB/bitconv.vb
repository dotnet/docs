'<Snippet1>
' Example of BitConverter class methods.
Module BitConverterDemo

    Sub Main( )

        Const formatter As String = "{0,25}{1,30}"
 
        Dim aDoubl      As Double   = 0.1111111111111111111
        Dim aSingl      As Single   = 0.1111111111111111111
        Dim aLong       As Long     = 1111111111111111111
        Dim anInt       As Integer  = 1111111111
        Dim aShort      As Short    = 11111
        Dim aChar       As Char     = "*"c
        Dim aBool       As Boolean  = True

        Console.WriteLine( _
            "This example of methods of the BitConverter class" & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( formatter, "argument", "Byte array" )
        Console.WriteLine( formatter, "--------", "----------" )

        ' Convert values to Byte arrays and display them.
        Console.WriteLine( formatter, aDoubl, _
            BitConverter.ToString( BitConverter.GetBytes( aDoubl ) ) )
        Console.WriteLine( formatter, aSingl, _
            BitConverter.ToString( BitConverter.GetBytes( aSingl ) ) )
        Console.WriteLine( formatter, aLong, _
            BitConverter.ToString( BitConverter.GetBytes( aLong ) ) )
        Console.WriteLine( formatter, anInt, _
            BitConverter.ToString( BitConverter.GetBytes( anInt ) ) )
        Console.WriteLine( formatter, aShort, _
            BitConverter.ToString( BitConverter.GetBytes( aShort ) ) )
        Console.WriteLine( formatter, aChar, _
            BitConverter.ToString( BitConverter.GetBytes( aChar ) ) )
        Console.WriteLine( formatter, aBool, _
            BitConverter.ToString( BitConverter.GetBytes( aBool ) ) )
    End Sub
End Module

' This example of methods of the BitConverter class
' generates the following output.
' 
'                  argument                    Byte array
'                  --------                    ----------
'         0.111111111111111       1C-C7-71-1C-C7-71-BC-3F
'                 0.1111111                   39-8E-E3-3D
'       1111111111111111111       C7-71-C4-2B-AB-75-6B-0F
'                1111111111                   C7-35-3A-42
'                     11111                         67-2B
'                         *                         2A-00
'                      True                            01
'</Snippet1>
