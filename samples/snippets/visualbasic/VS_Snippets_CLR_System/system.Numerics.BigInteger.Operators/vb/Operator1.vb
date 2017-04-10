' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module modMain
   Public Sub Main()
      BitwiseAnd()
      BitwiseOr()
      Decrement()
      EqualsInt641()
      EqualsInt642()
      EqualsUInt641()
      EqualsUInt642()
      BitwiseXOr()
      GreaterThan64B()
      GreaterThan64BDirect()
      GreaterThanB64()
      GreaterThan64BDirect()
      GreaterThanBU64()
      GreaterThanBU64Direct()
      GreaterThanU64B()
      GreaterThanU64BDirect()
      GreaterThanOrEqual64B
      GreaterThanOrEqual64BDirect()
      GreaterThanOrEqualB64()
      GreaterThanOrEqualB64Direct()
      GreaterThanOrEqualBU64()
      GreaterThanOrEqualBU64Direct()
      GreaterThanOrEqualU64B()
      GreaterThanOrEqualU64BDirect()
      Inequality64B()
      InequalityB64()
      InequalityBU64()
      InequalityU64B()
      LeftShift()
      LeftShiftManually()
      LessThan64B()
      LessThan64BDirect()
      LessThanB64()
      LessThanB64Direct()
      LessThanBU64()
      LessThanBU64Direct()
      LessThanU64B()
      LessthanU64BDirect()
      LessThanOrEqual64B()
      LessThanOrEqual64BDirect()
      LessThanOrEqualB64()
      LessThanOrEqualB64Direct()
      LessThanOrEqualBU64()
      LessThanOrEqualBU64Direct()
      LessThanOrEqualU64B()
      LessthanOrEqualU64BDirect()
      RightShift()
      RightShiftManually()
   End Sub
   
   Private Sub BitwiseAnd()
      ' <Snippet1>
      Dim number1 As BigInteger = BigInteger.Add(Int64.MaxValue, Int32.MaxValue)
      Dim number2 As BigInteger = BigInteger.Pow(Byte.MaxValue, 10)
      Dim result As BigInteger = number1 And number2
      ' </Snippet1>
      Console.WriteLine(result)
   End Sub   
   
   Private Sub BitwiseOr()
      ' <Snippet2>
      Dim number1 As BigInteger = BigInteger.Parse("10343901200000000000")
      Dim number2 As BigInteger = Byte.MaxValue
      Dim result As BigInteger = number1 Or number2
      ' </Snippet2>
      Console.WriteLine(result)
   End Sub
   
   Private Sub Decrement()
      ' <Snippet3>
      Dim number1 As BigInteger = BigInteger.Pow(Int32.MaxValue, 2)
      number1 = BigInteger.Subtract(number1, BigInteger.One)
      ' </Snippet3>
   End Sub   
   
   Private Sub EqualsInt641()
      ' <Snippet4>
      Dim bigNumber As BigInteger = BigInteger.Pow(2, 63)
      Dim number As Long = Int64.MaxValue
      If number = bigNumber Then
         ' Do something...
      End If   
      ' </Snippet4>
      Console.WriteLine("{0} = {1}: {2}", number, bigNumber, bigNumber = number)
   End Sub
   
   Private Sub EqualsInt642()
      ' <Snippet5>
      Dim bigNumber As BigInteger = BigInteger.Pow(2, 63)
      Dim number As Long = Int64.MaxValue
      If bigNumber = number Then
         ' Do something...
      End If   
      ' </Snippet5>
      Console.WriteLine("{0} = {1}: {2}", bigNumber, number, bigNumber = number)
   End Sub
  
   Private Sub EqualsUInt641()
      ' <Snippet6>
      Dim bigNumber As BigInteger = BigInteger.Pow(2, 63) - BigInteger.One
      Dim uNumber As ULong = CULng(Int64.MaxValue And CULng(&h7FFFFFFFFFFFFFFF))
      If bigNumber = uNumber Then
         ' Do something...
      End If
      ' </Snippet6>
   End Sub

   Private Sub EqualsUInt642()
      ' <Snippet7>
      Dim bigNumber As BigInteger = BigInteger.Pow(2, 63) - BigInteger.One
      Dim uNumber As ULong = CULng(Int64.MaxValue And CULng(&h7FFFFFFFFFFFFFFF))
      If uNumber = bigNumber Then
         ' Do something...
      End If
      ' </Snippet7>
   End Sub
   
   Private Sub BitwiseXOr()
      ' <Snippet8>
      Dim number1 As BigInteger = BigInteger.Pow(2, 127)
      Dim number2 As BigInteger = BigInteger.Multiply(163, 124)
      Dim result As BigInteger = number1 XOr number2
      ' </Snippet8>
      Console.WriteLine("XOR: " + result.ToString())
   End Sub
   
   Private Sub GreaterThan64B()
      ' <Snippet9>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 4)
      Dim number As Long = Int64.MaxValue
      If number > bigNumber Then
         ' Do something
      End If
      ' </Snippet9>
   End Sub
   
   Private Sub GreaterThan64BDirect()
      ' <Snippet10>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 4)
      Dim number As Long = Int64.MaxValue
      If BigInteger.op_GreaterThan(number,bigNumber) Then
         ' Do something
      End If
      ' </Snippet10>
   End Sub
   
   Private Sub GreaterThanB64()
      ' <Snippet11>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 4)
      Dim number As Long = Int64.MaxValue
      If bigNumber > Number Then
         ' Do something
      End If
      ' </Snippet11>
   End Sub
   
   Private Sub GreaterThanB64Direct()
      ' <Snippet12>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 4)
      Dim number As Long = Int64.MaxValue
      If BigInteger.op_GreaterThan(bigNumber,number) Then
         ' Do something
      End If
      ' </Snippet12>
   End Sub
   
   Private Sub GreaterThanBU64()
      ' <Snippet13>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 2)
      Dim number As ULong = UInt64.MaxValue
      If bigNumber > number Then
         ' Do something
      End If
      ' </Snippet13>
   End Sub
      
   Private Sub GreaterThanBU64Direct()
      ' <Snippet14>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 2)
      Dim number As ULong = UInt64.MaxValue
      If BigInteger.op_GreaterThan(bigNumber, number) Then
         ' Do something
      End If
      ' </Snippet14>
   End Sub
      
   Private Sub GreaterThanU64B()
      ' <Snippet15>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 2)
      Dim number As ULong = UInt64.MaxValue
      If number > bigNumber Then
         ' Do something
      End If
      ' </Snippet15>
   End Sub
      
   Private Sub GreaterThanU64BDirect()
      ' <Snippet16>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 2)
      Dim number As ULong = UInt64.MaxValue
      If BigInteger.op_GreaterThan(number, bigNumber) Then
         ' Do something
      End If
      ' </Snippet16>
   End Sub

   Private Sub GreaterThanOrEqual64B()
      ' <Snippet17>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 4)
      Dim number As Long = Int64.MaxValue
      If number >= bigNumber Then
         ' Do something
      End If
      ' </Snippet17>
   End Sub
   
   Private Sub GreaterThanOrEqual64BDirect()
      ' <Snippet18>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 4)
      Dim number As Long = Int64.MaxValue
      If BigInteger.op_GreaterThanOrEqual(number,bigNumber) Then
         ' Do something
      End If
      ' </Snippet18>
   End Sub
   
   Private Sub GreaterThanOrEqualB64()
      ' <Snippet19>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 4)
      Dim number As Long = Int64.MaxValue
      If bigNumber >= number Then
         ' Do something
      End If
      ' </Snippet19>
   End Sub
   
   Private Sub GreaterThanOrEqualB64Direct()
      ' <Snippet20>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 4)
      Dim number As Long = Int64.MaxValue
      If BigInteger.op_GreaterThanOrEqual(bigNumber,number) Then
         ' Do something
      End If
      ' </Snippet20>
   End Sub
   
   Private Sub GreaterThanOrEqualBU64()
      ' <Snippet21>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 2)
      Dim number As ULong = UInt64.MaxValue
      If bigNumber >= number Then
         ' Do something
      End If
      ' </Snippet21>
   End Sub
   
   Private Sub GreaterThanOrEqualBU64Direct()
      ' <Snippet22>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 2)
      Dim number As ULong = UInt64.MaxValue
      If BigInteger.op_GreaterThanOrEqual(bigNumber, number) Then
         ' Do something
      End If
      ' </Snippet22>
   End Sub
   
   Private Sub GreaterThanOrEqualU64B()
      ' <Snippet23>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 2)
      Dim number As ULong = UInt64.MaxValue
      If number >= bigNumber Then
         ' Do something
      End If
      ' </Snippet23>
   End Sub
   
   Private Sub GreaterThanOrEqualU64BDirect()
      ' <Snippet24>
      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 2)
      Dim number As ULong = UInt64.MaxValue
      If BigInteger.op_GreaterThanOrEqual(number, bigNumber) Then
         ' Do something
      End If
      ' </Snippet24>
   End Sub
   
   Public Sub Inequality64B()
      ' <Snippet25>
      Dim bigNumber As BigInteger = BigInteger.Pow(2, 63)
      Dim number As Long = Int64.MaxValue
      If number <> bigNumber Then
         ' Do something...
      End If   
      ' </Snippet25>
   End Sub
   
   Private Sub InequalityB64()
      ' <Snippet26>
      Dim bigNumber As BigInteger = BigInteger.Pow(2, 63)
      Dim number As Long = Int64.MaxValue
      If bigNumber <> number Then
         ' Do something...
      End If   
      ' </Snippet26>
   End Sub
   
   Private Sub InequalityBU64()
      ' <Snippet27>
      Dim bigNumber As BigInteger = BigInteger.Pow(2, 63) - BigInteger.One
      Dim uNumber As ULong = CULng(Int64.MaxValue And CULng(&h7FFFFFFFFFFFFFFF))
      If bigNumber <> uNumber Then
         ' Do something...
      End If
      ' </Snippet27>
   End Sub
   
   Private Sub InequalityU64B()
      ' <Snippet28>
      Dim bigNumber As BigInteger = BigInteger.Pow(2, 63) - BigInteger.One
      Dim uNumber As ULong = CULng(Int64.MaxValue And CULng(&h7FFFFFFFFFFFFFFF))
      If uNumber <> bigNumber Then
         ' Do something...
      End If
      ' </Snippet28>
   End Sub
   
   Private Sub LeftShift()
      ' <Snippet29>
      Dim number As BigInteger = BigInteger.Parse("-9047321678449816249999312055")
      Console.WriteLine("Shifting {0} left by:", number)
      For ctr As Integer = 0 To 16
         Dim newNumber As BigInteger = number << ctr
         Console.WriteLine(" {0,2} bits: {1,35} {2,30}", ctr, newNumber, newNumber.ToString("X"))
      Next
      ' The example displays the following output:
      '    Shifting -9047321678449816249999312055 left by:
      '      0 bits:       -9047321678449816249999312055       E2C43B1D0D6F07D2CC1FBB49
      '      1 bits:      -18094643356899632499998624110       C588763A1ADE0FA5983F7692
      '      2 bits:      -36189286713799264999997248220       8B10EC7435BC1F4B307EED24
      '      3 bits:      -72378573427598529999994496440      F1621D8E86B783E9660FDDA48
      '      4 bits: -1.4475714685519705999998899288E+29      E2C43B1D0D6F07D2CC1FBB490
      '      5 bits: -2.8951429371039411999997798576E+29      C588763A1ADE0FA5983F76920
      '      6 bits: -5.7902858742078823999995597152E+29      8B10EC7435BC1F4B307EED240
      '      7 bits:  -1.158057174841576479999911943E+30     F1621D8E86B783E9660FDDA480
      '      8 bits: -2.3161143496831529599998238861E+30     E2C43B1D0D6F07D2CC1FBB4900
      '      9 bits: -4.6322286993663059199996477722E+30     C588763A1ADE0FA5983F769200
      '     10 bits: -9.2644573987326118399992955443E+30     8B10EC7435BC1F4B307EED2400
      '     11 bits: -1.8528914797465223679998591089E+31    F1621D8E86B783E9660FDDA4800
      '     12 bits: -3.7057829594930447359997182177E+31    E2C43B1D0D6F07D2CC1FBB49000
      '     13 bits: -7.4115659189860894719994364355E+31    C588763A1ADE0FA5983F7692000
      '     14 bits: -1.4823131837972178943998872871E+32    8B10EC7435BC1F4B307EED24000
      '     15 bits: -2.9646263675944357887997745742E+32   F1621D8E86B783E9660FDDA48000
      '     16 bits: -5.9292527351888715775995491484E+32   E2C43B1D0D6F07D2CC1FBB490000      
      ' </Snippet29>
   End Sub
   
   Private Sub LeftShiftManually()   
      ' <Snippet30>
      Dim number As BigInteger = BigInteger.Parse("-9047321678449816249999312055")
      Console.WriteLine("Shifting {0} left by:", number)
      For ctr As Integer = 0 To 16
         Dim newNumber As BigInteger = BigInteger.Multiply(number, BigInteger.Pow(2, ctr))
         Console.WriteLine(" {0,2} bits: {1,35} {2,30}", 
                           ctr, newNumber, newNumber.ToString("X"))
      Next
      ' The example displays the following output:
      '    Shifting -9047321678449816249999312055 left by:
      '      0 bits:       -9047321678449816249999312055       E2C43B1D0D6F07D2CC1FBB49
      '      1 bits:      -18094643356899632499998624110       C588763A1ADE0FA5983F7692
      '      2 bits:      -36189286713799264999997248220       8B10EC7435BC1F4B307EED24
      '      3 bits:      -72378573427598529999994496440      F1621D8E86B783E9660FDDA48
      '      4 bits: -1.4475714685519705999998899288E+29      E2C43B1D0D6F07D2CC1FBB490
      '      5 bits: -2.8951429371039411999997798576E+29      C588763A1ADE0FA5983F76920
      '      6 bits: -5.7902858742078823999995597152E+29      8B10EC7435BC1F4B307EED240
      '      7 bits:  -1.158057174841576479999911943E+30     F1621D8E86B783E9660FDDA480
      '      8 bits: -2.3161143496831529599998238861E+30     E2C43B1D0D6F07D2CC1FBB4900
      '      9 bits: -4.6322286993663059199996477722E+30     C588763A1ADE0FA5983F769200
      '     10 bits: -9.2644573987326118399992955443E+30     8B10EC7435BC1F4B307EED2400
      '     11 bits: -1.8528914797465223679998591089E+31    F1621D8E86B783E9660FDDA4800
      '     12 bits: -3.7057829594930447359997182177E+31    E2C43B1D0D6F07D2CC1FBB49000
      '     13 bits: -7.4115659189860894719994364355E+31    C588763A1ADE0FA5983F7692000
      '     14 bits: -1.4823131837972178943998872871E+32    8B10EC7435BC1F4B307EED24000
      '     15 bits: -2.9646263675944357887997745742E+32   F1621D8E86B783E9660FDDA48000
      '     16 bits: -5.9292527351888715775995491484E+32   E2C43B1D0D6F07D2CC1FBB490000      
      ' </Snippet30>
   End Sub
   
   Public Sub LessThan64B()
      ' <Snippet31>
      Dim number As BigInteger = BigInteger.Parse("9801324316220166912")
      If Int64.MaxValue < number Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet31>
   End Sub 
     
   Public Sub LessThan64BDirect()
      ' <Snippet32>
      Dim number As BigInteger = BigInteger.Parse("9801324316220166912")
      If BigInteger.op_LessThan(Int64.MaxValue, number) Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet32>
   End Sub   

   Public Sub LessThanB64()
      ' <Snippet33>
      Dim number As BigInteger = BigInteger.Parse("9801324316220166912")
      If number < Int64.MaxValue Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet33>
   End Sub 
     
   Public Sub LessThanB64Direct()
      ' <Snippet34>
      Dim number As BigInteger = BigInteger.Parse("9801324316220166912")
      If BigInteger.op_LessThan(number, Int64.MaxValue) Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet34>
   End Sub   

   Public Sub LessThanBU64()
      ' <Snippet35>
      Dim number As BigInteger = BigInteger.Parse("19801324316220166912")
      If number < UInt64.MaxValue Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet35>
   End Sub 
     
   Public Sub LessThanBU64Direct()
      ' <Snippet36>
      Dim number As BigInteger = BigInteger.Parse("19801324316220166912")
      If BigInteger.op_LessThan(number, UInt64.MaxValue) Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet36>
   End Sub   

   Public Sub LessThanU64B()
      ' <Snippet37>
      Dim number As BigInteger = BigInteger.Parse("9801324316220166912")
      If UInt64.MaxValue < number Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet37>
   End Sub 
     
   Public Sub LessThanU64BDirect()
      ' <Snippet38>
      Dim number As BigInteger = BigInteger.Parse("9801324316220166912")
      If BigInteger.op_LessThan(UInt64.MaxValue, number) Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet38>
   End Sub   

   Public Sub LessThanOrEqual64B()
      ' <Snippet39>
      Dim number As BigInteger = BigInteger.Parse("9801324316220166912")
      If Int64.MaxValue <= number Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet39>
   End Sub 
     
   Public Sub LessThanOrEqual64BDirect()
      ' <Snippet40>
      Dim number As BigInteger = BigInteger.Parse("9801324316220166912")
      If BigInteger.op_LessThanOrEqual(Int64.MaxValue, number) Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet40>
   End Sub   

   Public Sub LessThanOrEqualB64()
      ' <Snippet41>
      Dim number As BigInteger = BigInteger.Parse("9801324316220166912")
      If number <= Int64.MaxValue Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet41>
   End Sub 
     
   Public Sub LessThanOrEqualB64Direct()
      ' <Snippet42>
      Dim number As BigInteger = BigInteger.Parse("9801324316220166912")
      If BigInteger.op_LessThanOrEqual(number, Int64.MaxValue) Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet42>
   End Sub   

   Public Sub LessThanOrEqualBU64()
      ' <Snippet43>
      Dim number As BigInteger = BigInteger.Parse("19801324316220166912")
      If number <= UInt64.MaxValue Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet43>
   End Sub 
     
   Public Sub LessThanOrEqualBU64Direct()
      ' <Snippet44>
      Dim number As BigInteger = BigInteger.Parse("19801324316220166912")
      If BigInteger.op_LessThanOrEqual(number, UInt64.MaxValue) Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet44>
   End Sub   

   Public Sub LessThanOrEqualU64B()
      ' <Snippet45>
      Dim number As BigInteger = BigInteger.Parse("9801324316220166912")
      If UInt64.MaxValue <= number Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet45>
   End Sub 
     
   Public Sub LessThanOrEqualU64BDirect()
      ' <Snippet46>
      Dim number As BigInteger = BigInteger.Parse("9801324316220166912")
      If BigInteger.op_LessThanOrEqual(UInt64.MaxValue, number) Then
         ' Do something.
      Else
         ' Do something else.
      End If      
      ' </Snippet46>
   End Sub  
   
   Private Sub RightShift()
      ' <Snippet47>
      Dim number As BigInteger = BigInteger.Parse("-9047321678449816249999312055")
      Console.WriteLine("Shifting {0} right by:", number)
      For ctr As Integer = 0 To 16
         Dim newNumber As BigInteger = number >> ctr
         Console.WriteLine(" {0,2} bits: {1,35} {2,30}", ctr, newNumber, newNumber.ToString("X"))
      Next
      ' The example displays the following output:
      '    Shifting -9047321678449816249999312055 right by:
      '      0 bits:       -9047321678449816249999312055       E2C43B1D0D6F07D2CC1FBB49
      '      1 bits:       -4523660839224908124999656028       F1621D8E86B783E9660FDDA4
      '      2 bits:       -2261830419612454062499828014        8B10EC7435BC1F4B307EED2
      '      3 bits:       -1130915209806227031249914007        C588763A1ADE0FA5983F769
      '      4 bits:        -565457604903113515624957004        E2C43B1D0D6F07D2CC1FBB4
      '      5 bits:        -282728802451556757812478502        F1621D8E86B783E9660FDDA
      '      6 bits:        -141364401225778378906239251         8B10EC7435BC1F4B307EED
      '      7 bits:         -70682200612889189453119626         C588763A1ADE0FA5983F76
      '      8 bits:         -35341100306444594726559813         E2C43B1D0D6F07D2CC1FBB
      '      9 bits:         -17670550153222297363279907         F1621D8E86B783E9660FDD
      '     10 bits:          -8835275076611148681639954          8B10EC7435BC1F4B307EE
      '     11 bits:          -4417637538305574340819977          C588763A1ADE0FA5983F7
      '     12 bits:          -2208818769152787170409989          E2C43B1D0D6F07D2CC1FB
      '     13 bits:          -1104409384576393585204995          F1621D8E86B783E9660FD
      '     14 bits:           -552204692288196792602498           8B10EC7435BC1F4B307E
      '     15 bits:           -276102346144098396301249           C588763A1ADE0FA5983F
      '     16 bits:           -138051173072049198150625           E2C43B1D0D6F07D2CC1F
      ' </Snippet47>
   End Sub
   
   Private Sub RightShiftManually()   
      ' <Snippet48>
      Dim number As BigInteger = BigInteger.Parse("-9047321678449816249999312055")
      Console.WriteLine("Shifting {0} right by:", number)
      For ctr As Integer = 0 To 16
         Dim newNumber As BigInteger = BigInteger.Divide(number, BigInteger.Pow(2, ctr))
         If newNumber * ctr < 0 Then newNumber = newNumber - 1
         Console.WriteLine(" {0,2} bits: {1,35} {2,30}", 
                           ctr, newNumber, newNumber.ToString("X"))
      Next
      ' The example displays the following output:
      '      0 bits:       -9047321678449816249999312055       E2C43B1D0D6F07D2CC1FBB49
      '      1 bits:       -4523660839224908124999656028       F1621D8E86B783E9660FDDA4
      '      2 bits:       -2261830419612454062499828014        8B10EC7435BC1F4B307EED2
      '      3 bits:       -1130915209806227031249914007        C588763A1ADE0FA5983F769
      '      4 bits:        -565457604903113515624957004        E2C43B1D0D6F07D2CC1FBB4
      '      5 bits:        -282728802451556757812478502        F1621D8E86B783E9660FDDA
      '      6 bits:        -141364401225778378906239251         8B10EC7435BC1F4B307EED
      '      7 bits:         -70682200612889189453119626         C588763A1ADE0FA5983F76
      '      8 bits:         -35341100306444594726559813         E2C43B1D0D6F07D2CC1FBB
      '      9 bits:         -17670550153222297363279907         F1621D8E86B783E9660FDD
      '     10 bits:          -8835275076611148681639954          8B10EC7435BC1F4B307EE
      '     11 bits:          -4417637538305574340819977          C588763A1ADE0FA5983F7
      '     12 bits:          -2208818769152787170409989          E2C43B1D0D6F07D2CC1FB
      '     13 bits:          -1104409384576393585204995          F1621D8E86B783E9660FD
      '     14 bits:           -552204692288196792602498           8B10EC7435BC1F4B307E
      '     15 bits:           -276102346144098396301249           C588763A1ADE0FA5983F
      '     16 bits:           -138051173072049198150625           E2C43B1D0D6F07D2CC1F
       ' </Snippet48>
   End Sub
    
End Module

