      int value = -16325;
      string specifier;
      
      // Use standard numeric format specifier.
      specifier = "G";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    G: -16325
      specifier = "C";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    C: ($16,325.00)
      specifier = "D8";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    D8: -00016325
      specifier = "E4";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    E4: -1.6325E+004
      specifier = "e3";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    e3: -1.633e+004
      specifier = "F";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    F: -16325.00
      specifier = "N";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    N: -16,325.00
      specifier = "P";
      Console.WriteLine("{0}: {1}", specifier, (value/100000).ToString(specifier));
      // Displays:    P: -16.33 %
      specifier = "X";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    X: FFFFC03B 
      
      // Use custom numeric format specifiers.
      specifier = "0,0.000";
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
      // Displays:    0,0.000: -16,325.000
      specifier = "#,#.00#;(#,#.00#)";
      Console.WriteLine("{0}: {1}", specifier, (value*-1).ToString(specifier));
      // Displays:    #,#.00#;(#,#.00#): 16,325.00