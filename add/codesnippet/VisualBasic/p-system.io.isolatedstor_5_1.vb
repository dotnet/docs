                Dim writer As New StreamWriter(isoStream)
                ' Update the data based on the new inputs.
                writer.WriteLine(Me.NewsUrl)
                writer.WriteLine(Me.SportsUrl)

                '  Calculate the amount of space used to record this user's preferences.
                Dim d As Double = Convert.ToDouble(isoFile.CurrentSize) / Convert.ToDouble(isoFile.MaximumSize)
                Console.WriteLine(("CurrentSize = " & isoFile.CurrentSize.ToString()))
                Console.WriteLine(("MaximumSize = " & isoFile.MaximumSize.ToString()))