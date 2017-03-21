      string phrase = "The quick  brown fox";
      string[] words;
      
      words = phrase.Split(default(Char[]), 3, StringSplitOptions.RemoveEmptyEntries);

      words = phrase.Split((char[]) null, 3, StringSplitOptions.RemoveEmptyEntries);
      
      words = phrase.Split(null as char[], 3, StringSplitOptions.RemoveEmptyEntries);