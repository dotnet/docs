'<Snippet1>
Imports System 

Namespace PerformanceLibrary     

    Public Class Book         
    
        Private _Pages As String()         
        
        Public Sub New(ByVal pages As String())            
            _Pages = pages        
        End Sub         
        
        Public Property Pages() As String()            
            Get                
                Return _Pages            
            End Get            
            
            Set(ByVal value as String())                
                _Pages = value            
            End Set        
        End Property     
        
    End Class 

End Namespace
'</Snippet1>