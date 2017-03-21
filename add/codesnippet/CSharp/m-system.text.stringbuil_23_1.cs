      string str = "Characters in a string.";
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      foreach (var ch in str)
         sb.Append(" '").Append(ch).Append("' ");

      Console.WriteLine("Characters in the string:");
      Console.WriteLine("  {0}", sb);
      // The example displays the following output:
      //    Characters in the string:
      //       'C'  'h'  'a'  'r'  'a'  'c'  't'  'e'  'r'  's'  ' '  'i'  'n'  ' '  'a'  ' '  's'  't' 'r'  'i'  'n'  'g'  '.'      