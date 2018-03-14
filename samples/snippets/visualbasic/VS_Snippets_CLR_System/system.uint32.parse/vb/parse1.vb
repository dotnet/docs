' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet1>
      Dim values() As String = { "+13230", "-0", "1,390,146", "$190,235,421,127", 
                                 "0xFA1B", "163042", "-10", "2147483648",  
                                 "14065839182", "16e07", "134985.0", "-12034" }
      For Each value As String In values
         Try
            Dim number As UInteger = UInt32.Parse(value) 
            Console.WriteLine("{0} --> {1}", value, number)
         Catch e As FormatException
            Console.WriteLine("{0}: Bad Format", value)
         Catch e As OverflowException
            Console.WriteLine("{0}: Overflow", value)   
         End Try  
      Next
      ' The example displays the following output:
      '       +13230 --> 13230
      '       -0 --> 0
      '       1,390,146: Bad Format
      '       $190,235,421,127: Bad Format
      '       0xFA1B: Bad Format
      '       163042 --> 163042
      '       -10: Overflow
      '       2147483648 --> 2147483648
      '       14065839182: Overflow
      '       16e07: Bad Format
      '       134985.0: Bad Format
      '       -12034: Overflow
      ' </Snippet1>                                            
   End Sub
End Module

