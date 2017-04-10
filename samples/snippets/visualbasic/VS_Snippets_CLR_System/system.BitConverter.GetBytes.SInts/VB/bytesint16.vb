' <Snippet3>
Module Example
    Public Sub Main( )
        ' Define an array of integers.
        Dim values() As Integer  = { 0, 15, -15, 10000,  -10000, 
                                     Short.MinValue, Short.MaxValue }
          
        ' Convert each integer to a byte array.
        Console.WriteLine("{0,16}{1,10}{2,17}", "Integer", 
                          "Endian", "Byte Array")
        Console.WriteLine("{0,16}{1,10}{2,17}", "---", "------", 
                          "----------" )
        For Each value In values
          Dim byteArray() As Byte = BitConverter.GetBytes(value)
          Console.WriteLine("{0,16}{1,10}{2,17}", value, 
                            If(BitConverter.IsLittleEndian, "Little", " Big"), 
                            BitConverter.ToString(byteArray))
        Next
    End Sub
End Module
' This example displays output like the following:
'              Integer    Endian       Byte Array
'                  ---    ------       ----------
'                    0    Little            00-00
'                   15    Little            0F-00
'                  -15    Little            F1-FF
'                10000    Little            10-27
'               -10000    Little            F0-D8
'               -32768    Little            00-80
'                32767    Little            FF-7F
' </Snippet3>
