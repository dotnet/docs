    static void ReadText(TextReader textReader)
    {
        Console.WriteLine("From {0} - {1}", 
            textReader.GetType().Name, textReader.ReadToEnd());
    }