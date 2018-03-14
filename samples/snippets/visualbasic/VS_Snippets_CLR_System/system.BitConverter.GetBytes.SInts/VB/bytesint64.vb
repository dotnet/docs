' <Snippet1>
Public Module Example
    Public Sub Main()
        ' Define an array of Int64 values.
        Dim values() As Long = { 0, &hFFFFFF, -&hFFFFFF, 1000000000, -1000000000,
                                 &h100000000, -&h100000000, &hAAAAAAAAAAAA, 
                                 -&hAAAAAAAAAAAA, 1000000000000000000, 
                                 -1000000000000000000, Long.MinValue, 
                                 Long.MaxValue }
        
        Console.WriteLine( "{0,22}{1,10}{2,30}", "Int64", "Endian", "Byte Array" )
        Console.WriteLine( "{0,22}{1,10}{2,30}", "----", "------", "----------" )
        
        For Each value in values
            ' Convert each Int64 value to a byte array.
            Dim byteArray() As Byte = BitConverter.GetBytes(value)
            ' Display the result.
            Console.WriteLine("{0,22}{1,10}{2,30}", value, 
                              If(BitConverter.IsLittleEndian, "Little", "Big"),
                              BitConverter.ToString(byteArray))
        
        Next  
    End Sub
End Module
' The example displays the following output:
'                      Int64    Endian                    Byte Array
'                       ----    ------                    ----------
'                          0    Little       00-00-00-00-00-00-00-00
'                   16777215    Little       FF-FF-FF-00-00-00-00-00
'                  -16777215    Little       01-00-00-FF-FF-FF-FF-FF
'                 1000000000    Little       00-CA-9A-3B-00-00-00-00
'                -1000000000    Little       00-36-65-C4-FF-FF-FF-FF
'                 4294967296    Little       00-00-00-00-01-00-00-00
'                -4294967296    Little       00-00-00-00-FF-FF-FF-FF
'            187649984473770    Little       AA-AA-AA-AA-AA-AA-00-00
'           -187649984473770    Little       56-55-55-55-55-55-FF-FF
'        1000000000000000000    Little       00-00-64-A7-B3-B6-E0-0D
'       -1000000000000000000    Little       00-00-9C-58-4C-49-1F-F2
'       -9223372036854775808    Little       00-00-00-00-00-00-00-80
'        9223372036854775807    Little       FF-FF-FF-FF-FF-FF-FF-7F
'</Snippet1>