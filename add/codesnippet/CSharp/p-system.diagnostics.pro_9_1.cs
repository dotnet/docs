                startInfo = new ProcessStartInfo(fileName);

                if (File.Exists(fileName))
                {
                    i = 0;
                    foreach (String verb in startInfo.Verbs)
                    {
                        // Display the possible verbs.
                        Console.WriteLine("  {0}. {1}", i.ToString(), verb);
                        i++;
                    }
                }
            }

            Console.WriteLine("Select the index of the verb.");
            string index = Console.ReadLine();
            if (Convert.ToInt32(index) < i)
                verbToUse = startInfo.Verbs[Convert.ToInt32(index)];
            else
                return;
            startInfo.Verb = verbToUse;
            if (verbToUse.ToLower().IndexOf("printto") >= 0)
            {
                // printto implies a specific printer.  Ask for the network address.
                // The address must be in the form \\server\printer.
                // The printer address is passed as the Arguments property.
                Console.WriteLine("Enter the network address of the target printer:");
                arguments = Console.ReadLine();
                startInfo.Arguments = arguments;
            }