      Dim thisDate As New DateTimeOffset(#6/1/2007 6:15AM#, _
                                            DateTimeOffset.Now.Offset)
      Dim weekdayName As String = thisDate.ToString("dddd", _
                                  New CultureInfo("fr-fr")) 
      Console.WriteLine(weekdayName)                        ' Displays vendredi     