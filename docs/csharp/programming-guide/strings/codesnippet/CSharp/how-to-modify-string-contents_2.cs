    class ModifyStrings
    {
        static void Main()
        {
            string str = "The quick brown fox jumped over the fence";
            System.Console.WriteLine(str);

            char[] chars = str.ToCharArray();
            int animalIndex = str.IndexOf("fox");
            if (animalIndex != -1)
            {
                chars[animalIndex++] = 'c';
                chars[animalIndex++] = 'a';
                chars[animalIndex] = 't';
            }

            string str2 = new string(chars);
            System.Console.WriteLine(str2);

            // Keep the console window open in debug mode
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    /* Output:
      The quick brown fox jumped over the fence
      The quick brown cat jumped over the fence 
    */