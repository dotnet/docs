' Visual Basic .NET Document
Option Strict On
' <Snippet2>
<Assembly: CLSCompliant(True)> 

Public Class Person
   Private personAge As UInt16
   
   Public ReadOnly Property Age As Int16
      Get
         Return CType(personAge, Int16)      
      End Get   
   End Property
End Class
' </Snippet2>                            
