      decimal value = 1346.19m;
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      sb.Append('*', 5).AppendFormat("{0:C2}", value).Append('*', 5);
      Console.WriteLine(sb);
      // The example displays the following output:
      //       *****$1,346.19*****