Imports Microsoft.VisualBasic

' <Snippet1>
Public Class MovieLibrary
    Dim _availableGenres() As String = {"Comedy", "Drama", "Romance"}

    Public ReadOnly Property AvailableGenres() As String()
        Get
            Return _availableGenres
        End Get
    End Property
    
End Class
' </Snippet1>
