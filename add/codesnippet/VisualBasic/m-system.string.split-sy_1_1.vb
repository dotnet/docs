      Dim phrase As String = "The quick brown fox"
      Dim words() As String
      
      words = phrase.Split(TryCast(Nothing, String()), 3, 
                             StringSplitOptions.RemoveEmptyEntries)
      
      words = phrase.Split(New String() {}, 3,
                           StringSplitOptions.RemoveEmptyEntries)