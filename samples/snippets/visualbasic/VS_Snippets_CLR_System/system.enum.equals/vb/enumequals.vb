' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Enum SledDog As Integer
   Unknown=0
   AlaskanMalamute=1
   Malamute=1
   Husky=2
   SiberianHusky=2
End Enum

Public Enum WorkDog As Integer
   Unknown=0
   Newfoundland=1
   GreatPyrennes=2
End Enum

Module Example
   Public Sub Main()
      Dim dog1 As SledDog = SledDog.Malamute
      Dim dog2 As SledDog = SledDog.AlaskanMalamute
      Dim dog3 As WorkDog = WorkDog.Newfoundland
      
      Console.WriteLine("{0:F} ({0:D}) = {1:F} ({1:D}): {2}", 
                        dog1, dog2, dog1.Equals(dog2))
      Console.WriteLine("{0:F} ({0:D}) = {1:F} ({1:D}): {2}",
                        dog1, dog3, dog1.Equals(dog3))
   End Sub
End Module
' The example displays the following output:
'       Malamute (1) = Malamute (1): True
'       Malamute (1) = Newfoundland (1): False
' </Snippet1>
