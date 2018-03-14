
Module Example
   Public Sub Main()
      SimpleMethodCall()
      Console.WriteLine()
      ConditionalModification()
   End Sub
   
   Private Sub SimpleMethodCall()
      ' <Snippet1>
      Dim sentence As New Sentence("A time to see the world is now.")
      Dim found = False
      sentence.FindNext("A", found) = "A good" 
      Console.WriteLine(sentence.GetSentence()) 
      ' The example displays the following output:
      '      A good time to see the world is now.
      '  </Snippet1>
   End Sub
   
   Private Sub ConditionalModification()
      ' <Snippet2>
      Dim sentence As New Sentence("A time to see the world is now.")
      Dim found = False
      sentence.FindNext("A", found) = IIf(found, "A good", sentence.FindNext("B", found)) 
      Console.WriteLine(sentence.GetSentence()) 
      ' The example displays the following output:
      '      A good time to see the world is now.
      '  </Snippet2>
   End Sub
End Module

