   String^ sentence = "This sentence has five words.";
   // Extract the second word.
   int startPosition = sentence->IndexOf(" ") + 1;
   String^ word2 = sentence->Substring(startPosition, 
                                       sentence->IndexOf(" ", startPosition) - startPosition);
   Console::WriteLine("Second word: " + word2);