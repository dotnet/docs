' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module Example
   Public Sub Main()
      EqualsLong() 
      EqualsBigInteger()
   End Sub
   
   Private Sub EqualsLong()
      ' <Snippet1>
      Dim bigIntValue As BigInteger 

      Dim byteValue As Byte = 16
      bigIntValue = New BigInteger(byteValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        byteValue.GetType().Name, byteValue, 
                        bigIntValue.Equals(byteValue))
                        
      Dim sbyteValue As SByte = -16
      bigIntValue = New BigInteger(sbyteValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        sbyteValue.GetType().Name, sbyteValue,
                        bigIntValue.Equals(sbyteValue))
      
      Dim shortValue As Short = 1233
      bigIntValue = New BigInteger(shortValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        shortValue.GetType().Name, shortValue, 
                        bigIntValue.Equals(shortValue))
            
      Dim ushortValue As UShort = 64000
      bigIntValue = New BigInteger(ushortValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        ushortValue.GetType().Name, ushortValue, 
                        bigIntValue.Equals(ushortValue))

      Dim intValue As Integer = -1603854
      bigIntValue = New BigInteger(intValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        intValue.GetType().Name, intValue, 
                        bigIntValue.Equals(intValue))
      
      Dim uintValue As UInteger = 1223300
      bigIntValue = New BigInteger(uintValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        uintValue.GetType().Name, uintValue, 
                        bigIntValue.Equals(uintValue))
      
      Dim longValue As Long = -123822229012
      bigIntValue = New BigInteger(longValue)
      Console.WriteLine("{0} {1} = {2} {3} : {4}", 
                        bigIntValue.GetType().Name, bigIntValue,
                        longValue.GetType().Name, longValue, 
                        bigIntValue.Equals(longValue))
      ' The example displays the following output:
      '    BigInteger 16 = Byte 16 : True
      '    BigInteger -16 = SByte -16 : True
      '    BigInteger 1233 = Int16 1233 : True
      '    BigInteger 64000 = UInt16 64000 : True
      '    BigInteger -1603854 = Int32 -1603854 : True
      '    BigInteger 1223300 = UInt32 1223300 : True
      '    BigInteger -123822229012 = Int64 -123822229012 : True
      ' </Snippet1>
   End Sub
   
   Private Sub EqualsBigInteger()
      ' <Snippet2>
      Const LIGHT_YEAR As Long = 5878625373183
   
      Dim altairDistance As BigInteger = 17 * LIGHT_YEAR
      Dim epsilonIndiDistance As BigInteger = 12 * LIGHT_YEAR
      Dim ursaeMajoris47Distance As BigInteger = 46 * LIGHT_YEAR
      Dim tauCetiDistance As BigInteger = 12 * LIGHT_YEAR
      Dim procyon2Distance As Long = 12 * LIGHT_YEAR
      Dim wolf424ABDistance As Object = 14 * LIGHT_YEAR
      
      Console.WriteLine("Approx. equal distances from Epsilon Indi to:")
      Console.WriteLine("   Altair: {0}", _
                        epsilonIndiDistance.Equals(altairDistance))
      Console.WriteLine("   Ursae Majoris 47: {0}", _
                        epsilonIndiDistance.Equals(ursaeMajoris47Distance))
      Console.WriteLine("   TauCeti: {0}", _
                        epsilonIndiDistance.Equals(tauCetiDistance))
      Console.WriteLine("   Procyon 2: {0}", _
                        epsilonIndiDistance.Equals(procyon2Distance))
      Console.WriteLine("   Wolf 424 AB: {0}", _
                        epsilonIndiDistance.Equals(wolf424ABDistance))
      ' The example displays the following output:
      '    Approx. equal distances from Epsilon Indi to:
      '       Altair: False
      '       Ursae Majoris 47: False
      '       TauCeti: True
      '       Procyon 2: True
      '       Wolf 424 AB: False
      ' </Snippet2>
   End Sub   
End Module

