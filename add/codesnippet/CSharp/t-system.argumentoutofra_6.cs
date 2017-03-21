      // Get the index of the element whose value is "Z".
      int index = list.FindIndex((new StringSearcher("Z")).FindEquals);
      if (index >= 0)
         Console.WriteLine("'Z' is found at index {0}", list[index]); 