    Public Function getAgePhrase(ByVal age As Integer) As String
        If age > 60 Then Return "Senior"
        If age > 40 Then Return "Middle-aged"
        If age > 20 Then Return "Adult"
        If age > 12 Then Return "Teen-aged"
        If age > 4 Then Return "School-aged"
        If age > 1 Then Return "Toddler"
        Return "Infant"
    End Function