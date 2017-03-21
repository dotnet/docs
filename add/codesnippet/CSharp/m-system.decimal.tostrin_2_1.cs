      decimal value = 16325.62m;
      string specifier;
      
      // Use standard numeric format specifiers.
      specifier = "G";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    G: 16325.62
      specifier = "C";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    C: $16,325.62
      specifier = "E04";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    E04: 1.6326E+004
      specifier = "F";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    F: 16325.62
      specifier = "N";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    N: 16,325.62
      specifier = "P";
      Console.WriteLine("{0}: {1}", specifier, (value/10000).ToString(specifier));
      // Displays:    P: 163.26 %
      
      // Use custom numeric format specifiers.
      specifier = "0,0.000";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    0,0.000: 16,325.620
      specifier = "#,#.00#;(#,#.00#)";
      Console.WriteLine("{0}: {1}", specifier, (value*-1).ToString(specifier));
      // Displays:    #,#.00#;(#,#.00#): (16,325.62)