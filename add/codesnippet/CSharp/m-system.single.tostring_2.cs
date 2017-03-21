            bool done = false;
            string inp;
            do
            {
                Console.Write("Enter a real number: ");
                inp = Console.ReadLine();
                try
                {
                    s = Single.Parse(inp);
                    Console.WriteLine("You entered {0}.", s.ToString());
                    done = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You did not enter a number.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occurred while parsing your response: {0}", e.ToString());
                }
            } while (!done);