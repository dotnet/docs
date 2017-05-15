'<Snippet1>
Imports System 

Public Module Calculator     

    Public Function Decrement(ByVal input As Integer) As Integer
             
        ' Violates this rule        
        input = input - 1         
        Return input
             
    End Function 
    
End Module
'</Snippet1>