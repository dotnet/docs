' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Runtime.CompilerServices

Module Example
   Public Sub Main()
      Console.WriteLine("{0,-18} {1,6} {2,18:N0}    {3,6} {4,18:N0}",
                        "", "Var 1", "Hash Code", "Var 2", "Hash Code")
      Console.WriteLine()
      
      ' Get hash codes of two different strings.
      Dim sc1 As String = "String #1"
      Dim sc2 As String = "String #2"
      ShowHashCodes("sc1", sc1, "sc2", sc2)
 
      ' Get hash codes of two identical non-interned strings.
      Dim s1 As String = "This string"
      Dim s2 As String = String.Format("{0} {1}", "This", "string")
      ShowHashCodes("s1", s1, "s2", s2)

      ' Get hash codes of two (evidently concatenated) strings.
      Dim si1 As String = "This is a string!"
      Dim si2 As String = "This " + "is " + "a " + "string!"
      ShowHashCodes("si1", si1, "si2", si2)
   End Sub
   
   Private Sub ShowHashCodes(var1 As String, value1 As Object, 
                             var2 As String, value2 As Object)
      Console.WriteLine("{0,-18} {1,6} {2,18:X8}    {3,6} {4,18:X8}",
                        "Obj.GetHashCode", var1, value1.GetHashCode,
                        var2, value2.GetHashCode)

      Console.WriteLine("{0,-18} {1,6} {2,18:X8}    {3,6} {4,18:X8}",
                        "RTH.GetHashCode", var1, RuntimeHelpers.GetHashCode(value1),
                        var2, RuntimeHelpers.GetHashCode(value2))
      Console.WriteLine()
   End Sub
End Module
' The example displays output similar to the following:
'                        Var 1          Hash Code     Var 2          Hash Code
'    
'    Obj.GetHashCode       sc1           94EABD27       sc2           94EABD24
'    RTH.GetHashCode       sc1           02BF8098       sc2           00BB8560
'    
'    Obj.GetHashCode        s1           29C5A397        s2           29C5A397
'    RTH.GetHashCode        s1           0297B065        s2           03553390
'    
'    Obj.GetHashCode       si1           941BCEA5       si2           941BCEA5
'    RTH.GetHashCode       si1           01FED012       si2           01FED012
' </Snippet1>
