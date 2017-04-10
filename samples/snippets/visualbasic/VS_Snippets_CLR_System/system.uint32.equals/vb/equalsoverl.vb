' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Dim value As UInt32 = 112
   
   Public Sub Main()
      Dim byte1 As Byte = 112
      Console.WriteLine("value = byte1: {0,16}", value.Equals(byte1))
      TestObjectForEquality(byte1)
      
      Dim short1 As Short = 112
      Console.WriteLine("value = short1: {0,17}", value.Equals(short1))
      TestObjectForEquality(short1)

      Dim long1 As Long = 112
      Console.WriteLine("value = long1: {0,18}", value.Equals(long1))
      TestObjectForEquality(long1)

      Dim sbyte1 As SByte = 112
      Console.WriteLine("value = sbyte1: {0,17}", value.Equals(sbyte1))
      TestObjectForEquality(sbyte1)
      
      Dim ushort1 As UShort = 112
      Console.WriteLine("value = ushort1: {0,16}", value.Equals(ushort1))
      TestObjectForEquality(ushort1)

      Dim ulong1 As ULong = 112
      Console.WriteLine("value = ulong1: {0,19}", value.Equals(ulong1))
      TestObjectForEquality(ulong1)

      Dim dec1 As Decimal = 112d
      Console.WriteLine("value = dec1: {0,21}", value.Equals(dec1))
      TestObjectForEquality(dec1)

      Dim dbl1 As Double = 112
      Console.WriteLine("value = dbl1: {0,20}", value.Equals(dbl1))
      TestObjectForEquality(dbl1)
   End Sub
   
   Private Sub TestObjectForEquality(obj As Object)
      Console.WriteLine("{0} ({1}) = {2} ({3}): {4}",
                        value, value.GetType().Name,
                        obj, obj.GetType().Name,
                        value.Equals(obj))
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'       value = byte1:             True
'       112 (UInt32) = 112 (Byte): False
'
'       value = short1:             False
'       112 (UInt32) = 112 (Int16): False
'
'       value = long1:              False
'       112 (UInt32) = 112 (Int64): False
'
'       value = sbyte1:             False
'       112 (UInt32) = 112 (SByte): False
'
'       value = ushort1:             True
'       112 (UInt32) = 112 (UInt16): False
'
'       value = ulong1:               False
'       112 (UInt32) = 112 (UInt64): False
'
'       value = dec1:                 False
'       112 (UInt32) = 112 (Decimal): False
'
'       value = dbl1:                False
'       112 (UInt32) = 112 (Double): False
' </Snippet1>
