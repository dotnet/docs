' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Reflection

Module Example
   Public Sub Main()
      Dim assem As Assembly = Assembly.ReflectionOnlyLoadFrom(".\Enumerations.dll")
      Dim typ As Type = assem.GetType("Pets")
      Dim fields As FieldInfo() = typ.GetFields

      For Each field In fields
         If field.Name.Equals("value__") Then Continue For
          
         Console.WriteLine("{0,-9} {1}", field.Name + ":", 
                                         field.GetRawConstantValue())
      Next
   End Sub
End Module
' The example displays the following output:
'       None:     0
'       Dog:      1
'       Cat:      2
'       Rodent:   4
'       Bird:     8
'       Fish:     16
'       Reptile:  32
'       Other:    64
' </Snippet3>

' <Snippet2>
<Flags> Public Enum Pets As Integer
   None = 0
   Dog = 1
   Cat = 2
   Rodent = 4
   Bird = 8
   Fish = 16
   Reptile = 32
   Other = 64
End Enum   
' </Snippet2>