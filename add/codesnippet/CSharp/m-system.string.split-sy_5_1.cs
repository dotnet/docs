      string phrase = "The quick  brown fox";
      string[] words;
      
      words = phrase.Split(default(Char[]), StringSplitOptions.RemoveEmptyEntries);

      words = phrase.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
      
      words = phrase.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);