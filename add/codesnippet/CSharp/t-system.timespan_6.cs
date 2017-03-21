      TimeSpan interval = new TimeSpan(12, 30, 45);
      string output;
      try {
         output = String.Format("{0:r}", interval);
      }
      catch (FormatException) {
         output = "Invalid Format";
      }
      Console.WriteLine(output);
      // Output from .NET Framework 3.5 and earlier versions:
      //       12:30:45
      // Output from .NET Framework 4:
      //       Invalid Format