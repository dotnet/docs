                startInfo = New ProcessStartInfo(fileName)

                If File.Exists(fileName) Then
                    i = 0
                    Dim verb As String
                    For Each verb In startInfo.Verbs
                        ' Display the possible verbs.
                        Console.WriteLine("  {0}. {1}", i.ToString(), verb)
                        i += 1
                    Next verb
                End If
            Else
                ' Return if no file is selected.
                Return
            End If

            Console.WriteLine("Select the index of the verb.")
            Dim index As String = Console.ReadLine()
            If Convert.ToInt32(index) < i Then
                verbToUse = startInfo.Verbs(Convert.ToInt32(index))
            Else
                Return
            End If

            startInfo.Verb = verbToUse
            If verbToUse.ToLower().IndexOf("printto") >= 0 Then
                ' printto implies a specific printer.  Ask for the network address.
                ' The address must be in the form \\server\printer.
                Console.WriteLine("Enter the network address of the target printer:")
                arguments = Console.ReadLine()
                startInfo.Arguments = arguments
            End If