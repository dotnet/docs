      double nan1 = Double.NaN;
      
      Console.WriteLine("{0} + {1} = {2}", 3, nan1, 3 + nan1);
      Console.WriteLine("Abs({0}) = {1}", nan1, Math.Abs(nan1));
      // The example displays the following output:
      //       3 + NaN = NaN
      //       Abs(NaN) = NaN