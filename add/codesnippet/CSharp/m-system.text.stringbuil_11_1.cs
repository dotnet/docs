      Byte[] bytes = { 16, 132, 27, 253 };
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      foreach (var value in bytes)
         sb.Append(value).Append(" ");         

      Console.WriteLine("The byte array: {0}", sb.ToString());
      // The example displays the following output:
      //         The byte array: 16 132 27 253      