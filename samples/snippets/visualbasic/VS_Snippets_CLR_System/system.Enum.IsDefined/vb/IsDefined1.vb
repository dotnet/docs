' Visual Basic .NET Document
Option Strict On

' <Snippet1>
<Flags> Public Enum PetType As Integer
   None = 0
   Dog = 1
   Cat = 2
   Rodent = 4
   Bird = 8
   Reptile = 16
   Other = 32
End Enum

Module Example
   Public Sub Main()
      Dim value As Object
      
      ' Call IsDefined with underlying integral value of member.
      value = 1
      Console.WriteLine("{0}: {1}", value, [Enum].IsDefined(GetType(PetType), value))
      ' Call IsDefined with invalid underlying integral value.
      value = 64
      Console.WriteLine("{0}: {1}", value, [Enum].IsDefined(GetType(PetType), value))
      ' Call IsDefined with string containing member name.
      value = "Rodent"
      Console.WriteLine("{0}: {1}", value, [Enum].IsDefined(GetType(PetType), value))
      ' Call IsDefined with a variable of type PetType.
      value = PetType.Dog
      Console.WriteLine("{0}: {1}", value, [Enum].IsDefined(GetType(PetType), value))
      value = PetType.Dog Or PetType.Cat
      Console.WriteLine("{0}: {1}", value, [Enum].IsDefined(GetType(PetType), value))
      ' Call IsDefined with uppercase member name.      
      value = "None"
      Console.WriteLine("{0}: {1}", value, [Enum].IsDefined(GetType(PetType), value))
      value = "NONE"
      Console.WriteLine("{0}: {1}", value, [Enum].IsDefined(GetType(PetType), value))
      ' Call IsDefined with combined value
      value = PetType.Dog Or PetType.Bird
      Console.WriteLine("{0:D}: {1}", value, [Enum].IsDefined(GetType(PetType), value))
      value = value.ToString()
      Console.WriteLine("{0:D}: {1}", value, [Enum].IsDefined(GetType(PetType), value))
   End Sub
End Module
' The example displays the following output:
'       1: True
'       64: False 
'       Rodent: True
'       Dog: True
'       Dog, Cat: False
'       None: True
'       NONE: False
'       9: False
'       Dog, Bird: False
' </Snippet1>
