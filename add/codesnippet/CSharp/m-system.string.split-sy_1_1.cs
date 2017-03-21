      string phrase = "The quick  brown fox";
      string[] words;
      
      words = phrase.Split(default(string[]), 3, StringSplitOptions.RemoveEmptyEntries);

      words = phrase.Split((string[]) null, 3, StringSplitOptions.RemoveEmptyEntries);
      
      words = phrase.Split(null as string[], 3, StringSplitOptions.RemoveEmptyEntries);