' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet1>
      Dim value As Byte = &B0110_1110
      Console.WriteLine($"{NameOf(value)}  = {value} (hex: 0x{value:X2}) " +
                        $"(binary: {Convert.ToString(value, 2)})")
      ' The example displays the following output:
      '      value  = 110 (hex: 0x6E) (binary: 1101110)      
      ' </Snippet1>                  
   End Sub
End Module

