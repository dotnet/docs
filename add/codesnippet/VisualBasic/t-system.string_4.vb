      Dim sentence As String = "This sentence has five words."
      ' Extract the second word.
      Dim startPosition As Integer = sentence.IndexOf(" ") + 1
      Dim word2 As String = sentence.Substring(startPosition, 
                                               sentence.IndexOf(" ", startPosition) - startPosition) 
      Console.WriteLine("Second word: " + word2)
      ' The example displays the following output:
      '       Second word: sentence