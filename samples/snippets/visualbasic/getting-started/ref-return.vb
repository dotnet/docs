
Module Example
   Public Sub Main()
      Dim sentence As New Sentence("A time to see the world is now.")
      Dim found = False
      sentence.FindNext("A", found) = IIf(found, "A good", sentence.FindNext("B", found)) 
      Console.WriteLine(sentence.GetSentence()) 
   End Sub
End Module
' The example displays the following output:
'      A good time to see the world is now.

