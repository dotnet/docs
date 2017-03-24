            try
            {
                int m = Int32.Parse("abc");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            // Output: Input string was not in a correct format.