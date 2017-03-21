Module Example
   Public Sub Main()
      Dim cool As New Temperature(5)
      Dim targetTypes() As Type = { GetType(SByte), GetType(Int16), GetType(Int32), _
                                    GetType(Int64), GetType(Byte), GetType(UInt16), _
                                    GetType(UInt32), GetType(UInt64), GetType(Decimal), _
                                    GetType(Single), GetType(Double), GetType(String) }
      Dim provider As New CultureInfo("fr-FR")
      
      For Each targetType As Type In targetTypes
         Try
            Dim value As Object = Convert.ChangeType(cool, targetType, provider)
            Console.WriteLine("Converted {0} {1} to {2} {3}.", _
                              cool.GetType().Name, cool.ToString(), _
                              targetType.Name, value)
         Catch e As InvalidCastException
            Console.WriteLine("Unsupported {0} --> {1} conversion.", _
                              cool.GetType().Name, targetType.Name)
         Catch e As OverflowException
            Console.WriteLine("{0} is out of range of the {1} type.", _
                              cool, targetType.Name)
         End Try                     
      Next
   End Sub
End Module
' The example displays the following output:
'       Converted Temperature 5.00°C to SByte 5.
'       Converted Temperature 5.00°C to Int16 5.
'       Converted Temperature 5.00°C to Int32 5.
'       Converted Temperature 5.00°C to Int64 5.
'       Converted Temperature 5.00°C to Byte 5.
'       Converted Temperature 5.00°C to UInt16 5.
'       Converted Temperature 5.00°C to UInt32 5.
'       Converted Temperature 5.00°C to UInt64 5.
'       Converted Temperature 5.00°C to Decimal 5.
'       Converted Temperature 5.00°C to Single 5.
'       Converted Temperature 5.00°C to Double 5.
'       Converted Temperature 5.00°C to String 5,00°C.