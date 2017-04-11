'<Snippet1>
Imports System 

Namespace PerformanceLibrary     

    Public Class Book         
        
        Private _Pages As String()       
          
        Public Sub New(ByVal pages As String())  
            _Pages = pages        
        End Sub         
        
        Public ReadOnly Property Pages() As String()            
            Get                
                Return _Pages            
            End Get            
        End Property     
        
    End Class 
    
End Namespace
'</Snippet1>