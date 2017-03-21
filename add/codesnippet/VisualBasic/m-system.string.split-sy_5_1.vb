      Dim phrase As String = "The quick brown fox"
      Dim words() As String
      
      words = phrase.Split(TryCast(Nothing, Char()),  
                             StringSplitOptions.RemoveEmptyEntries)
      
      words = phrase.Split(New Char() {}, 
                           StringSplitOptions.RemoveEmptyEntries)