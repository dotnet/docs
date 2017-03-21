   public static string[] StripComments(string[] lines)
   { 
      List<string> lineList = new List<string>();
      foreach (string line in lines)
      {
         if (line.TrimStart(' ').StartsWith("//"))
            lineList.Add(line.TrimStart(' ', '/'));
      }
      return lineList.ToArray();
   }   