'<Snippet1>
' Example of the BitConverter.ToString( Byte( ) ) method.
Imports System
Imports Microsoft.VisualBasic

Module BytesToStringDemo

    ' Display a Byte array with a name.
    Sub WriteByteArray( bytes( ) As Byte, name As String )
       
        Const underLine As String = "--------------------------------"

        Console.WriteLine( name )
        Console.WriteLine( underLine.Substring( 0, _
            Math.Min( name.Length, underLine.Length ) ) )
        Console.WriteLine( BitConverter.ToString( bytes ) )
        Console.WriteLine( )
    End Sub

    Sub Main( )
        Dim arrayOne as Byte( ) = { _
              0,   1,   2,   4,   8,  16,  32,  64, 128, 255 }

        Dim arrayTwo as Byte( ) = { _
             32,   0,   0,  42,   0,  65,   0, 125,   0, 197, _
              0, 168,   3,  41,   4, 172,  32 }

        Dim arrayThree as Byte( ) = { _
             15,   0,   0, 128,  16,  39, 240, 216, 241, 255, _
            127 }

        Dim arrayFour as Byte( ) = { _
             15,   0,   0,   0,   0,  16,   0, 255,   3,   0, _
              0, 202, 154,  59, 255, 255, 255, 255, 127 }

        Console.WriteLine( "This example of the " & _
            "BitConverter.ToString( Byte( ) ) " & vbCrLf & _
            "method generates the following output." & vbCrLf )

        WriteByteArray( arrayOne, "arrayOne" )
        WriteByteArray( arrayTwo, "arrayTwo" )
        WriteByteArray( arrayThree, "arrayThree" )
        WriteByteArray( arrayFour, "arrayFour" )
    End Sub 
End Module

' This example of the BitConverter.ToString( Byte( ) )
' method generates the following output.
' 
' arrayOne
' --------
' 00-01-02-04-08-10-20-40-80-FF
' 
' arrayTwo
' --------
' 20-00-00-2A-00-41-00-7D-00-C5-00-A8-03-29-04-AC-20
' 
' arrayThree
' ----------
' 0F-00-00-80-10-27-F0-D8-F1-FF-7F
' 
' arrayFour
' ---------
' 0F-00-00-00-00-10-00-FF-03-00-00-CA-9A-3B-FF-FF-FF-FF-7F
'</Snippet1>