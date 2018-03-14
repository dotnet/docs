'<Snippet2>
' Example of the BitConverter.IsLittleEndian field.
Imports System
Imports Microsoft.VisualBasic

Module LittleEndDemo
    Sub Main( )
        Console.WriteLine( _
            "This example of the BitConverter.IsLittleEndian " & _
            "field generates " & vbCrLf & "the following output " & _
            "when run on x86-class computers." & vbCrLf )
        Console.WriteLine( "IsLittleEndian:  {0}", _
            BitConverter.IsLittleEndian )
    End Sub 
End Module

' This example of the BitConverter.IsLittleEndian field generates
' the following output when run on x86-class computers.
'
' IsLittleEndian:  True
'</Snippet2>