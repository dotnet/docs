' Visual Basic .NET Document
' 
' Illustrates ToBoolean with the following parameter types:
'    Byte
'    Decimal
'    Int16
'    Int32
'    Int64
'
Option Strict On

Module Example
   Public Sub Main()
      ConvertByte()
      Console.WriteLine("-----")
      ConvertDecimal()
      Console.WriteLine("-----")
      ConvertInt16()
      Console.WriteLine("-----")
      ConvertInt32()
      Console.WriteLine("-----")
      ConvertInt64()
      Console.WriteLine("-----")
      ConvertSByte()
      Console.WriteLine("-----")
      ConvertSingle()
      Console.WriteLine("-----")
      ConvertUInt16()
      Console.WriteLine("-----")
      ConvertUInt32()
      Console.WriteLine("-----")
      ConvertUInt64()
      Console.WriteLine("-----")
      ConvertObject()      
   End Sub
   
   Private Sub ConvertByte()
      ' <Snippet12>
      Dim bytes() As Byte = { Byte.MinValue, 100, 200, Byte.MaxValue }
      Dim result As Boolean
      
      For Each byteValue As Byte In bytes
         result = Convert.ToBoolean(byteValue) 
         Console.WriteLine("{0,-5}  -->  {1}", byteValue, result)
      Next           
      ' The example displays the following output:
      '       0      -->  False
      '       100    -->  True
      '       200    -->  True
      '       255    -->  True
      ' </Snippet12>
   End Sub
   
   Private Sub ConvertDecimal()
      ' <Snippet2>
      Dim numbers() As Decimal = { Decimal.MinValue, -12034.87d, -100d, _
                                   0d, 300d, 6790823.45d, Decimal.MaxValue }
      Dim result As Boolean
      
      For Each number As Decimal In numbers
         result = Convert.ToBoolean(number) 
         Console.WriteLine("{0,-30}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       -79228162514264337593543950335  -->  True
      '       -12034.87                       -->  True
      '       -100                            -->  True
      '       0                               -->  False
      '       300                             -->  True
      '       6790823.45                      -->  True
      '       79228162514264337593543950335   -->  True
      ' </Snippet2>
   End Sub
   
   Private Sub ConvertInt16()
      ' <Snippet3>
      Dim numbers() As Short = { Int16.MinValue, -10000, -154, 0, 216, _
                                 21453, Int16.MaxValue }
      Dim result As Boolean
      
      For Each number As Short In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-7:N0}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       -32,768  -->  True
      '       -10,000  -->  True
      '       -154     -->  True
      '       0        -->  False
      '       216      -->  True
      '       21,453   -->  True
      '       32,767   -->  True
      ' </Snippet3>
   End Sub
   
   Private Sub ConvertInt32()
      ' <Snippet4>
      Dim numbers() As Integer = { Int32.MinValue, -201649, -68, 0, 612, _
                                   4038907, Int32.MaxValue }
      Dim result As Boolean
      
      For Each number As Integer In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-15:N0}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       -2,147,483,648   -->  True
      '       -201,649         -->  True
      '       -68              -->  True
      '       0                -->  False
      '       612              -->  True
      '       4,038,907        -->  True
      '       2,147,483,647    -->  True
      ' </Snippet4>
   End Sub
   
   Private Sub ConvertInt64()
      ' <Snippet5>
      Dim numbers() As Long = { Int64.MinValue, -2016493, -689, 0, 6121, _
                                403890774, Int64.MaxValue }
      Dim result As Boolean
      
      For Each number As Long In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-26:N0}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       -9,223,372,036,854,775,808  -->  True
      '       -2,016,493                  -->  True
      '       -689                        -->  True
      '       0                           -->  False
      '       6,121                       -->  True
      '       403,890,774                 -->  True
      '       9,223,372,036,854,775,807   -->  True
      ' </Snippet5>
   End Sub

   Private Sub ConvertSByte()
      ' <Snippet6>
      Dim numbers() As SByte = { SByte.MinValue, -1, 0, 10, 100, SByte.MaxValue }
      Dim result As Boolean
      
      For Each number As SByte In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-5}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       -128   -->  True
      '       -1     -->  True
      '       0      -->  False
      '       10     -->  True
      '       100    -->  True
      '       127    -->  True
      ' </Snippet6>
   End Sub
   
   Private Sub ConvertSingle()
      ' <Snippet7>
      Dim numbers() As Single = { Single.MinValue, -193.0012, 20e-15, 0, _
                                  10551e-10, 100.3398, Single.MaxValue }
      Dim result As Boolean
      
      For Each number As Single In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-15}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       -3.402823E+38    -->  True
      '       -193.0012        -->  True
      '       2E-14            -->  True
      '       0                -->  False
      '       1.0551E-06       -->  True
      '       100.3398         -->  True
      '       3.402823E+38     -->  True
      ' </Snippet7>
   End Sub
   
   Private Sub ConvertUInt16()
      ' <Snippet8>
      Dim numbers() As UShort = { UInt16.MinValue, 216, 21453, UInt16.MaxValue }
      Dim result As Boolean
      
      For Each number As UShort In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-7:N0}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       0        -->  False
      '       216      -->  True
      '       21,453   -->  True
      '       65,535   -->  True
      ' </Snippet8>
   End Sub
   
   Private Sub ConvertUInt32()
      ' <Snippet9>
      Dim numbers() As UInteger = { UInt32.MinValue, 612, 4038907, Int32.MaxValue }
      Dim result As Boolean
      
      For Each number As UInteger In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-15:N0}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       0                -->  False
      '       612              -->  True
      '       4,038,907        -->  True
      '       2,147,483,647    -->  True
      ' </Snippet9>
   End Sub
   
   Private Sub ConvertUInt64()
      ' <Snippet10>
      Dim numbers() As ULong = { UInt64.MinValue, 6121, 403890774, UInt64.MaxValue }
      Dim result As Boolean
      
      For Each number As ULong In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-26:N0}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       0                           -->  False
      '       6,121                       -->  True
      '       403,890,774                 -->  True
      '       18,446,744,073,709,551,615  -->  True
      ' </Snippet10>
   End Sub
   
   Private Sub ConvertObject()
      ' <Snippet11>
      Dim objects() As Object = {16.33, -24, 0, "12", "12.7", String.Empty, _
                                 "1String", "True", "false", Nothing, _
                                 New System.Collections.ArrayList() }
      For Each obj As Object In objects
         If obj IsNot Nothing Then
            Console.Write("{0,-40}  -->  ", _
                          String.Format("{0} ({1})", obj, obj.GetType().Name))
         Else
            Console.Write("{0,-40}  -->  ", "Nothing")   
         End If
         Try
            Console.WriteLine("{0}", Convert.ToBoolean(obj))
         Catch e As FormatException
            Console.WriteLine("Bad Format")
         Catch e As InvalidCastException
            Console.WriteLine("No Conversion")
         End Try   
      Next     
      ' The example displays the following output:
      '       16.33 (Double)                            -->  True
      '       -24 (Int32)                               -->  True
      '       0 (Int32)                                 -->  False
      '       12 (String)                               -->  Bad Format
      '       12.7 (String)                             -->  Bad Format
      '        (String)                                 -->  Bad Format
      '       1String (String)                          -->  Bad Format
      '       True (String)                             -->  True
      '       false (String)                            -->  False
      '       Nothing                                   -->  False
      '       System.Collections.ArrayList (ArrayList)  -->  No Conversion
      ' </Snippet11>
   End Sub
End Module

