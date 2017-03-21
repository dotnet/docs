      Dim displayDate As New DateTimeOffset(#1/1/2008 1:18PM#, _
                                            DateTimeOffset.Now.Offset)
      Console.WriteLine("{0:D}", displayDate)    ' Output: Tuesday, January 01, 2008                     
      Console.WriteLine("{0:d} is a {0:dddd}.", _
                        displayDate)             ' Output: 1/1/2008 is a Tuesday.