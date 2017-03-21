      char[] chars = { 'a', 'b', 'c', 'd', 'e'};
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      int startPosition = Array.IndexOf(chars, 'a');
      int endPosition = Array.IndexOf(chars, 'c');
      if (startPosition >= 0 && endPosition >= 0) {
         sb.Append("The array from positions ").Append(startPosition).
                   Append(" to ").Append(endPosition).Append(" contains ").
                   Append(chars, startPosition, endPosition + 1).Append(".");
         Console.WriteLine(sb);
      }             
      // The example displays the following output:
      //       The array from positions 0 to 2 contains abc.