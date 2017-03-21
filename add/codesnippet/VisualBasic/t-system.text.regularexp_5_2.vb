      Dim sr As New StreamReader(filename)
      Dim input As String
      Dim pattern As String = "\b(\w+)\s\1\b"
      Dim rgx As New Regex(pattern, RegexOptions.IgnoreCase)
      Do While sr.Peek() >= 0
         input = sr.ReadLine()
         Dim matches As MatchCollection = rgx.Matches(input)
         If matches.Count > 0 Then
            Console.WriteLine("{0} ({1} matches):", input, matches.Count)
            For Each match As Match In matches
               Console.WriteLine("   " + match.Value)
            Next   
         End If
      Loop
      sr.Close()   