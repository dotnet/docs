      string phrase = "The quick  brown fox";
      string[] words;
      
      words = phrase.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);

      words = phrase.Split((string[]) null, StringSplitOptions.RemoveEmptyEntries);
      
      words = phrase.Split(null as string[], StringSplitOptions.RemoveEmptyEntries);