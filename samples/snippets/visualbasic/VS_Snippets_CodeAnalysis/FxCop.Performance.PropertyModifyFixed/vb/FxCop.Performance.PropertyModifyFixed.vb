'<Snippet1>
Imports System
Imports System.Collections.ObjectModel 

Namespace PerformanceLibrary     

    Public Class Book         
    
        Private _Pages As Collection(Of String)         
        
        Public Sub New(ByVal pages As String())            
            _Pages = New Collection(Of String)(pages)        
        End Sub         
        
        Public ReadOnly Property Pages() As Collection(Of String)            
            Get                
                Return _Pages            
            End Get        
        End Property     
        
    End Class 

End Namespace
'</Snippet1>