            // Iterate through each IGrouping in the Lookup and output the contents.
            foreach (IGrouping<char, string> packageGroup in lookup)
            {
                // Print the key value of the IGrouping.
                Console.WriteLine(packageGroup.Key);
                // Iterate through each value in the IGrouping and print its value.
                foreach (string str in packageGroup)
                    Console.WriteLine("    {0}", str);
            }