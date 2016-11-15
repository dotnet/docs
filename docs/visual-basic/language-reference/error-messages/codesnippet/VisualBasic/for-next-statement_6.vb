    Public Enum Mammals
        Buffalo
        Gazelle
        Mongoose
        Rhinoceros
        Whale
    End Enum


    Public Sub ListSomeMammals()
        For mammal As Mammals = Mammals.Gazelle To Mammals.Rhinoceros
            Debug.Write(mammal.ToString & " ")
        Next
        Debug.WriteLine("")
        ' Output: Gazelle Mongoose Rhinoceros
    End Sub