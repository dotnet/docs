      Dim chars() As Char = { "w"c, "o"c, "r"c, "d"c }
      
      ' Create a string from a character array.
      Dim string1 As New String(chars)
      Console.WriteLine(string1)
      
      ' Create a string that consists of a character repeated 20 times.
      Dim string2 As New String("c"c, 20)
      Console.WriteLine(string2)
      ' The example displays the following output:
      '       word
      '       cccccccccccccccccccc      