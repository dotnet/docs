'<Snippet1>
Imports System 

Namespace PerformanceLibrary     

    Public Class Book         
    
        Private _Pages As String()         
        
        Public Sub New(ByVal pages As String())            
            _Pages = pages        
        End Sub         
        
        Public Function GetPages() As String()	    
            ' Need to return a clone of the array so that consumers            
            ' of this library cannot change its contents            
            Return DirectCast(_Pages.Clone(), String())        
        End Function     
        
    End Class 
    
End Namespace
'</Snippet1>