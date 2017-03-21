            String DataString = Uri.UnescapeDataString(".NET+Framework");
            Console.WriteLine("Unescaped string: {0}", DataString);

            String PlusString = DataString.Replace('+',' ');
            Console.WriteLine("plus to space string: {0}", PlusString);