      Dim string1 As String = "Today is " + Date.Now.ToString("D") + "."  
      Console.WriteLine(string1)
      Dim string2 As String = "This is one sentence. " + "This is a second. "
      string2 += "This is a third sentence."
      Console.WriteLine(string2)      
      ' The example displays output like the following:
      '    Today is Tuesday, July 06, 2011.
      '    This is one sentence. This is a second. This is a third sentence.