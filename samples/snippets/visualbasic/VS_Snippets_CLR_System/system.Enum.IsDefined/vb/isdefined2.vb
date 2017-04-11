' Visual Basic .NET Document
Option Strict On

' <Snippet2>
<Flags> Public Enum Pets As Integer
   None = 0
   Dog = 1
   Cat = 2
   Bird = 4
   Rodent = 8
   Other = 16
End Enum

Module Example
   Public Sub Main()
      Dim value As Pets = Pets.Dog Or Pets.Cat
      Console.WriteLine("{0:D} Exists: {1}", 
                        value, Pets.IsDefined(GetType(Pets), value))
      Dim name As String = value.ToString()
      Console.WriteLine("{0} Exists: {1}", 
                        name, Pets.IsDefined(GetType(Pets), name))
   End Sub
End Module
' The example displays the following output:
'       3 Exists: False
'       Dog, Cat Exists: False
' </Snippet2>
