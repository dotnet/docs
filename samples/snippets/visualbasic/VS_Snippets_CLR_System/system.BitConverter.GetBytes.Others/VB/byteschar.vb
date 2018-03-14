'<Snippet2>
' Example of the BitConverter.GetBytes( Char ) method.
Imports System
Imports Microsoft.VisualBasic

Module GetBytesCharDemo

    Const formatter As String = "{0,10}{1,16}"
 
    ' Convert a Char argument to a Byte array and display it.
    Sub GetBytesChar( argument As Char )

        Dim byteArray As Byte( ) = BitConverter.GetBytes( argument )
        Console.WriteLine( formatter, argument, _
            BitConverter.ToString( byteArray ) )
    End Sub 
       
    Sub Main( )

        Console.WriteLine( _
            "This example of the BitConverter.GetBytes( Char ) " & _
            vbCrLf & "method generates the following " & _
            "output." & vbCrLf )
        Console.WriteLine( formatter, "Char", "Byte array" )
        Console.WriteLine( formatter, "----", "----------" )
          
        ' Convert Char values and display the results.
        GetBytesChar( Chr( 0 ) )
        GetBytesChar( " "c )
        GetBytesChar( "*"c )
        GetBytesChar( "3"c )
        GetBytesChar( "A"c )
        GetBytesChar( "["c )
        GetBytesChar( "a"c )
        GetBytesChar( "{"c )
    End Sub 
End Module

' This example of the BitConverter.GetBytes( Char )
' method generates the following output.
' 
'       Char      Byte array
'       ----      ----------
'                      00-00
'                      20-00
'          *           2A-00
'          3           33-00
'          A           41-00
'          [           5B-00
'          a           61-00
'          {           7B-00
'</Snippet2>