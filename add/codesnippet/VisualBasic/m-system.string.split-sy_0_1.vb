      Dim phrase As String = "The quick brown fox"
      Dim words() As String
      
      words = phrase.Split(TryCast(Nothing, Char()), 3, 
                             StringSplitOptions.RemoveEmptyEntries)
      
      words = phrase.Split(New Char() {}, 3,
                           StringSplitOptions.RemoveEmptyEntries)