Option Strict On

Public Module Example

   Public Sub Main()
       Console.WriteLine("Byte Assignments:")
       AssignByte()
       Console.WriteLine()
       Console.WriteLine("Byte Assignments with Separator:")
       AssignByteWithSeparator()
       Console.WriteLine()

       Console.WriteLine("Short Assignments:")
       AssignShort()
       Console.WriteLine()
       Console.WriteLine("Short Assignments with Separator:")
       AssignShortWithSeparator()
       Console.WriteLine()

       Console.WriteLine("Integer Assignments:")
       AssignInteger()
       Console.WriteLine()
       Console.WriteLine("Integer Assignments with Separator:")
       AssignIntegerWithSeparator()
       Console.WriteLine()

       Console.WriteLine("Long Assignments:")
       AssignLong()
       Console.WriteLine()
       Console.WriteLine("Long Assignments with Separator:")
       AssignLongWithSeparator()
       Console.WriteLine()

       Console.WriteLine("Signed Byte Assignments:")
       AssignSByte()
       Console.WriteLine()
       Console.WriteLine("Signed Byte Assignments with Separator:")
       AssignSByteWithSeparator()
       Console.WriteLine()

       Console.WriteLine("UShort Assignments:")
       AssignUShort()
       Console.WriteLine()
       Console.WriteLine("UShort Assignments with Separator:")
       AssignUShortWithSeparator()
       Console.WriteLine()

       Console.WriteLine("UInteger Assignments:")
       AssignUInteger()
       Console.WriteLine()
       Console.WriteLine("UInteger Assignments with Separator:")
       AssignUIntegerWithSeparator()
       Console.WriteLine()

       Console.WriteLine("ULong Assignments:")
       AssignULong()
       Console.WriteLine()
       Console.WriteLine("ULong Assignments with Separator:")
       AssignULongWithSeparator()
       Console.WriteLine()
   End Sub

   Private Sub AssignByte()
      ' <SnippetByte>
      Dim byteValue1 As Byte = 201
      Console.WriteLine(byteValue1)
      
      Dim byteValue2 As Byte = &H00C9
      Console.WriteLine(byteValue2)
      
      Dim byteValue3 As Byte = &B1100_1001
      Console.WriteLine(byteValue3)
      ' The example displays the following output:
      '          201
      '          201
      '          201
      ' </SnippetByte>
   End Sub

   Private Sub AssignByteWithSeparator()
      ' <SnippetByteS>
      Dim byteValue3 As Byte = &B1100_1001
      Console.WriteLine(byteValue3)
      ' The example displays the following output:
      '          201
      ' </SnippetByteS>
   End Sub

   Private Sub AssignShort()
      ' <SnippetShort>
      Dim shortValue1 As Short = 1034
      Console.WriteLine(shortValue1)
      
      Dim shortValue2 As Short = &H040A
      Console.WriteLine(shortValue2)
      
      Dim shortValue3 As Short = &B0100_00001010
      Console.WriteLine(shortValue3)
      ' The example displays the following output:
      '          1034
      '          1034
      '          1034
      ' </SnippetShort>
   End Sub

   Private Sub AssignShortWithSeparator()
      ' <SnippetShortS>
      Dim shortValue1 As Short = 1_034
      Console.WriteLine(shortValue1)
      
      Dim shortValue3 As Short = &B00000100_00001010
      Console.WriteLine(shortValue3)
      ' The example displays the following output:
      '          1034
      '          1034
      ' </SnippetShortS>
   End Sub

   Private Sub AssignInteger()
      ' <SnippetInt>
      Dim intValue1 As Integer = 90946
      Console.WriteLine(intValue1)
      Dim intValue2 As Integer = &H16342
      Console.WriteLine(intValue2)
      
      Dim intValue3 As Integer = &B0001_0110_0011_0100_0010
      Console.WriteLine(intValue3)
      ' The example displays the following output:
      '          90946
      '          90946
      '          90946
      ' </SnippetInt>
   End Sub

   Private Sub AssignIntegerWithSeparator()
      ' <SnippetIntS>
      Dim intValue1 As Integer = 90_946
      Console.WriteLine(intValue1)
      
      Dim intValue2 As Integer = &H0001_6342
      Console.WriteLine(intValue2)
      
      Dim intValue3 As Integer = &B0001_0110_0011_0100_0010
      Console.WriteLine(intValue3)
      ' The example displays the following output:
      '          90946
      '          90946
      '          90946
      ' </SnippetIntS>
   End Sub

   Private Sub AssignLong()
      ' <SnippetLong>
      Dim longValue1 As Long = 4294967296
      Console.WriteLine(longValue1)
      
      Dim longValue2 As Long = &H100000000
      Console.WriteLine(longValue2)
      
      Dim longValue3 As Long = &B1_0000_0000_0000_0000_0000_0000_0000_0000
      Console.WriteLine(longValue3)
      ' The example displays the following output:
      '          4294967296
      '          4294967296
      '          4294967296
      ' </SnippetLong>
   End Sub

   Private Sub AssignLongWithSeparator()
      ' <SnippetLongS>
      Dim longValue1 As Long = 4_294_967_296
      Console.WriteLine(longValue1)
      
      Dim longValue2 As Long = &H1_0000_0000
      Console.WriteLine(longValue2)
      
      Dim longValue3 As Long = &B1_0000_0000_0000_0000_0000_0000_0000_0000
      Console.WriteLine(longValue3)
      ' The example displays the following output:
      '          4294967296
      '          4294967296
      '          4294967296
      ' </SnippetLongS>
   End Sub

   Private Sub AssignSByte()
      ' <SnippetSByte>
      Dim sbyteValue1 As SByte = -102
      Console.WriteLine(sbyteValue1)
      
      Dim sbyteValue4 As SByte = &H9A
      Console.WriteLine(sbyteValue4)
      
      Dim sbyteValue5 As SByte = &B1001_1010
      Console.WriteLine(sbyteValue5)
      ' The example displays the following output:
      '          -102
      '          -102
      '          -102
      ' </SnippetSByte>
   End Sub

   Private Sub AssignSByteWithSeparator()
      ' <SnippetSByteS>
      Dim sbyteValue3 As SByte = &B1001_1010
      Console.WriteLine(sbyteValue3)
      ' The example displays the following output:
      '          -102
      ' </SnippetSByteS>
   End Sub

   Private Sub AssignUShort()
      ' <SnippetUShort>
      Dim ushortValue1 As UShort = 65034
      Console.WriteLine(ushortValue1)
      
      Dim ushortValue2 As UShort = &HFE0A
      Console.WriteLine(ushortValue2)
      
      Dim ushortValue3 As UShort = &B1111_1110_0000_1010
      Console.WriteLine(ushortValue3)
      ' The example displays the following output:
      '          65034
      '          65034
      '          65034
      ' </SnippetUShort>
   End Sub

   Private Sub AssignUShortWithSeparator()
      ' <SnippetUShortS>
      Dim ushortValue1 As UShort = 65_034
      Console.WriteLine(ushortValue1)
      
      Dim ushortValue3 As UShort = &B11111110_00001010
      Console.WriteLine(ushortValue3)
      ' The example displays the following output:
      '          65034
      '          65034
      ' </SnippetUShortS>
   End Sub

   Private Sub AssignUInteger()
      ' <SnippetUInt>
      Dim uintValue1 As UInteger = 3000000000ui
      Console.WriteLine(uintValue1)
      
      Dim uintValue2 As UInteger = &HB2D05E00ui
      Console.WriteLine(uintValue2)
      
      Dim uintValue3 As UInteger = &B1011_0010_1101_0000_0101_1110_0000_0000ui
      Console.WriteLine(uintValue3)
      ' The example displays the following output:
      '          3000000000
      '          3000000000
      '          3000000000
      ' </SnippetUInt>
   End Sub

   Private Sub AssignUIntegerWithSeparator()
      ' <SnippetUIntS>
      Dim uintValue1 As UInteger = 3_000_000_000ui
      Console.WriteLine(uintValue1)
      
      Dim uintValue2 As UInteger = &HB2D0_5E00ui
      Console.WriteLine(uintValue2)
      
      Dim uintValue3 As UInteger = &B1011_0010_1101_0000_0101_1110_0000_0000ui
      Console.WriteLine(uintValue3)
      ' The example displays the following output:
      '          3000000000
      '          3000000000
      '          3000000000
      ' </SnippetUIntS>
   End Sub

   Private Sub AssignULong()
      ' <SnippetULong>
      Dim ulongValue1 As ULong = 7934076125
      Console.WriteLine(ulongValue1)
      
      Dim ulongValue2 As ULong = &H0001D8e864DD
      Console.WriteLine(ulongValue2)
      
      Dim ulongValue3 As ULong = &B0001_1101_1000_1110_1000_0110_0100_1101_1101
      Console.WriteLine(ulongValue3)
      ' The example displays the following output:
      '          7934076125
      '          7934076125
      '          7934076125
      ' </SnippetULong>
   End Sub

   Private Sub AssignULongWithSeparator()
      ' <SnippetIntULong>
      Dim ulongValue1 As ULong = 7_934_076_125
      Console.WriteLine(ulongValue1)
      
      Dim ulongValue2 As ULong = &H0001_D8e8_64DD
      Console.WriteLine(ulongValue2)
      
      Dim ulongValue3 As ULong = &B0000_0001_1101_1000_1110_1000_0110_0100_1101_1101
      Console.WriteLine(ulongValue3)
      ' The example displays the following output:
      '          7934076125
      '          7934076125
      '          7934076125
      ' </SnippetULongS>
   End Sub
End Module
