'<Snippet1>
Imports System

Namespace UsageLibrary
Public Class ABaseType
   
   Public Sub BasePublicMethod(argument1 As Integer)
   End Sub 'BasePublicMethod
    
End Class 'ABaseType 

Public Class ADerivedType
   Inherits ABaseType
   
   ' Violates rule DoNotDecreaseInheritedMemberVisibility.
   Private Shadows Sub BasePublicMethod(argument1 As Integer)
   End Sub 'BasePublicMethod
End Class 'ADerivedType

End Namespace
'</Snippet1>
