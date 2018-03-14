' Visual Basic .NET Document
Option Strict On

' <Snippet1>     
Imports Corporate.EmployeeObjects

Module Example
   Public Sub Main()
      Dim empA As New EmployeeA With { .Name = "Robert" }
      Console.WriteLine(empA.ToString())
      
      Dim empB = new EmployeeB With { .Name = "Robert" }
      Console.WriteLine(empB.ToString())
   End Sub
End Module

Namespace Corporate.EmployeeObjects
    Public Structure EmployeeA
         Public Property Name As String 
    End Structure
    
    Public Structure EmployeeB
         Public Property Name As String 

         Public Overrides Function ToString() As String 
              Return Name
         End Function
    End Structure  
End Namespace
' The example displays the following output:
'     Corporate.EmployeeObjects.EmployeeA
'     Robert
' </Snippet1>
