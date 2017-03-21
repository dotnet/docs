      Dim pattern As String = "[(.*?)]" 
      Dim input As String = "The animal [what kind?] was visible [by whom?] from the window."
      
      Dim matches As MatchCollection = Regex.Matches(input, pattern)
      Dim commentNumber As Integer = 0
      Console.WriteLine("{0} produces the following matches:", pattern)
      For Each match As Match In matches
         commentNumber += 1
         Console.WriteLine("{0}: {1}", commentNumber, match.Value)       
      Next      
      ' This example displays the following output:
      '       1: ?
      '       2: ?
      '       3: .