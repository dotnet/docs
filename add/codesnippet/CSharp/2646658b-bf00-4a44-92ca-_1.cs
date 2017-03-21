      DateTime date1 = new DateTime(2010, 8, 18, 16, 32, 18, 500, 
                                    DateTimeKind.Local);
      Console.WriteLine("{0:M/dd/yyyy h:mm:ss.fff tt} {1}", date1, date1.Kind);
      // The example displays the following output:
      //      8/18/2010 4:32:18.500 PM Local