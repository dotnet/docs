'<Snippet4>
' Example of the BitConverter.ToSingle method.
Imports System
Imports Microsoft.VisualBasic

Module BytesToSingleDemo

    Const formatter As String = "{0,5}{1,17}{2,18:E7}"
 
    ' Convert four Byte array elements to a Single and display it.
    Sub BAToSingle( bytes( ) As Byte, index As Integer )

        Dim value As Single = BitConverter.ToSingle( bytes, index )

        Console.WriteLine( formatter, index, _
            BitConverter.ToString( bytes, index, 4 ), value )
    End Sub 

    ' Display a Byte array, using multiple lines if necessary.
    Sub WriteMultiLineByteArray( bytes( ) As Byte )
       
        Const rowSize As Integer = 20 
        Dim iter As Integer

        Console.WriteLine( "initial Byte array" )
        Console.WriteLine( "------------------" )

        For iter = 0 To bytes.Length - rowSize - 1 Step rowSize
            Console.Write( _
                BitConverter.ToString( bytes, iter, rowSize ) )
            Console.WriteLine( "-" )
        Next iter

        Console.WriteLine( BitConverter.ToString( bytes, iter ) )
        Console.WriteLine( )
    End Sub

    Sub Main( )
        Dim byteArray as Byte( ) = { _
              0,   0,   0,   0, 128,  63,   0,   0, 112,  65, _
              0, 255, 127,  71,   0,   0, 128,  59,   0,   0, _
            128,  47,  73,  70, 131,   5,  75,   6, 158,  63, _
             77,   6, 158,  63,  80,   6, 158,  63,  30,  55, _
            190, 121, 255, 255, 127, 255, 255, 127, 127,   1, _
              0,   0,   0, 192, 255,   0,   0, 128, 255,   0, _
              0, 128, 127 }

        Console.WriteLine( _
            "This example of the BitConverter.ToSingle( Byte( ), " & _
            "Integer ) " & vbCrLf & "method generates the " & _
            "following output. It converts elements " & vbCrLf & _
            "of a Byte array to Single values." & vbCrLf )

        WriteMultiLineByteArray( byteArray )

        Console.WriteLine( formatter, "index", "array elements", _
            "Single" )
        Console.WriteLine( formatter, "-----", "--------------", _
            "------" )
          
        ' Convert Byte array elements to Single values.
        BAToSingle( byteArray, 0 )
        BAToSingle( byteArray, 2 )
        BAToSingle( byteArray, 6 )
        BAToSingle( byteArray, 10 )
        BAToSingle( byteArray, 14 )
        BAToSingle( byteArray, 18 )
        BAToSingle( byteArray, 22 )
        BAToSingle( byteArray, 26 )
        BAToSingle( byteArray, 30 )
        BAToSingle( byteArray, 34 )
        BAToSingle( byteArray, 38 )
        BAToSingle( byteArray, 42 )
        BAToSingle( byteArray, 45 )
        BAToSingle( byteArray, 49 )
        BAToSingle( byteArray, 51 )
        BAToSingle( byteArray, 55 )
        BAToSingle( byteArray, 59 )
    End Sub 
End Module

' This example of the BitConverter.ToSingle( Byte( ), Integer )
' method generates the following output. It converts elements
' of a Byte array to Single values.
' 
' initial Byte array
' ------------------
' 00-00-00-00-80-3F-00-00-70-41-00-FF-7F-47-00-00-80-3B-00-00-
' 80-2F-49-46-83-05-4B-06-9E-3F-4D-06-9E-3F-50-06-9E-3F-1E-37-
' BE-79-FF-FF-7F-FF-FF-7F-7F-01-00-00-00-C0-FF-00-00-80-FF-00-
' 00-80-7F
' 
' index   array elements            Single
' -----   --------------            ------
'     0      00-00-00-00    0.0000000E+000
'     2      00-00-80-3F    1.0000000E+000
'     6      00-00-70-41    1.5000000E+001
'    10      00-FF-7F-47    6.5535000E+004
'    14      00-00-80-3B    3.9062500E-003
'    18      00-00-80-2F    2.3283064E-010
'    22      49-46-83-05    1.2345000E-035
'    26      4B-06-9E-3F    1.2345671E+000
'    30      4D-06-9E-3F    1.2345673E+000
'    34      50-06-9E-3F    1.2345676E+000
'    38      1E-37-BE-79    1.2345679E+035
'    42      FF-FF-7F-FF   -3.4028235E+038
'    45      FF-FF-7F-7F    3.4028235E+038
'    49      01-00-00-00    1.4012985E-045
'    51      00-00-C0-FF               NaN
'    55      00-00-80-FF         -Infinity
'    59      00-00-80-7F          Infinity
'</Snippet4>