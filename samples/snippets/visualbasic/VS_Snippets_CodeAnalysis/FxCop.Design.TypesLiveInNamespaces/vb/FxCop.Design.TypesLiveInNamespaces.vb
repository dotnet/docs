'<Snippet1>
Imports System 

' Violates rule: DeclareTypesInNamespaces.
Public Class Test     

    Public Overrides Function ToString() As String        
        Return "Test does not live in a namespace!"    
    End Function 
    
End Class 

Namespace GoodSpace  
   
    Public Class Test 
            
        Public Overrides Function ToString() As String            
            Return "Test lives in a namespace!"        
        End Function  
           
    End Class 
    
End Namespace
'</Snippet1>
