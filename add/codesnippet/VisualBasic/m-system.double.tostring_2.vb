         Dim Done As Boolean = False
         Dim Inp As String
         Do

             Console.Write("Enter a real number: ")
             inp = Console.ReadLine()
             Try
                 D = Double.Parse(inp)
                 Console.WriteLine("You entered " + D.ToString() + ".")
                 Done = True
             Catch e As FormatException
                 Console.WriteLine("You did not enter a number.")
             Catch e As ArgumentNullException
                Console.WriteLine("You did not supply any input.")
             Catch e As OverflowException
                Console.WriteLine("The value you entered, {0}, is out of range.", inp)      
             End Try
         Loop While Not Done