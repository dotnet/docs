            Dim Done As Boolean = False
            Dim Inp As String
            Do

                Console.Write("Enter a real number: ")
                Inp = Console.ReadLine()
                Try
                    S = Single.Parse(Inp)
                    Console.WriteLine("You entered " + S.ToString() + ".")
                    Done = True
                Catch E As FormatException
                    Console.WriteLine("You did not enter a number.")
                Catch E As Exception
                    Console.WriteLine("An exception occurred while parsing your response: " + E.ToString())
                End Try
            Loop While Not Done