'<Snippet2>
' Example of the BitConverter.ToChar method.
Imports System
Imports Microsoft.VisualBasic

Module BytesToCharDemo

    Const formatter As String = "{0,5}{1,17}{2,8}"
 
    ' Convert two Byte array elements to a Char and display it.
    Sub BAToChar( bytes( ) As Byte, index As Integer )

        Dim value As Char = BitConverter.ToChar( bytes, index )

        Console.WriteLine( formatter, index, _
            BitConverter.ToString( bytes, index, 2 ), value )
    End Sub 
       
    Sub Main( )

        Dim byteArray as Byte( ) = { _
             32,   0,   0,  42,   0,  65,   0, 125,   0, 197, _
              0, 168,   3,  41,   4, 172,  32 }

        Console.WriteLine( _
            "This example of the BitConverter.ToChar( Byte( ), " & _
            "Integer ) " & vbCrLf & "method generates the " & _
            "following output. It converts elements " & vbCrLf & _
            "of a Byte array to Char values." & vbCrLf )
        Console.WriteLine( "initial Byte array" )
        Console.WriteLine( "------------------" )
        Console.WriteLine( BitConverter.ToString( byteArray ) )
        Console.WriteLine( )
        Console.WriteLine( formatter, "index", "array elements", "Char" )
        Console.WriteLine( formatter, "-----", "--------------", "----" )
          
        ' Convert Byte array elements to Char values.
        BAToChar( byteArray, 0 )
        BAToChar( byteArray, 1 )
        BAToChar( byteArray, 3 )
        BAToChar( byteArray, 5 )
        BAToChar( byteArray, 7 )
        BAToChar( byteArray, 9 )
        BAToChar( byteArray, 11 )
        BAToChar( byteArray, 13 )
        BAToChar( byteArray, 15 )
    End Sub 
End Module

' This example of the BitConverter.ToChar( Byte( ), Integer )
' method generates the following output. It converts elements 
' of a Byte array to Char values.
' 
' initial Byte array
' ------------------
' 20-00-00-2A-00-41-00-7D-00-C5-00-A8-03-29-04-AC-20
' 
' index   array elements    Char
' -----   --------------    ----
'     0            20-00
'     1            00-00
'     3            2A-00       *
'     5            41-00       A
'     7            7D-00       }
'     9            C5-00       Å
'    11            A8-03       ?
'    13            29-04       ?
'    15            AC-20       ?
'</Snippet2>