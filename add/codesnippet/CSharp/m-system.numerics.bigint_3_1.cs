      // Redefine the negative sign as the tilde for the invariant culture.
      NumberFormatInfo bigIntegerFormatter = new NumberFormatInfo();
      bigIntegerFormatter.NegativeSign = "~";

      BigInteger value = BigInteger.Parse("-903145792771643190182");
      string[] specifiers = { "C", "D", "D25", "E", "E4", "e8", "F0", 
                              "G", "N0", "P", "R", "X", "0,0.000", 
                              "#,#.00#;(#,#.00#)" };
      
      foreach (string specifier in specifiers)
         Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier, 
                           bigIntegerFormatter));

      // The example displays the following output:
      //    C: (☼903,145,792,771,643,190,182.00)
      //    D: ~903145792771643190182
      //    D25: ~0000903145792771643190182
      //    E: ~9.031457E+020
      //    E4: ~9.0314E+020
      //    e8: ~9.03145792e+020
      //    F0: ~903145792771643190182
      //    G: ~903145792771643190182
      //    N0: ~903,145,792,771,643,190,182
      //    P: ~90,314,579,277,164,319,018,200.00 %
      //    R: ~903145792771643190182
      //    X: CF0A55968BB1A7545A
      //    0,0.000: ~903,145,792,771,643,190,182.000
      //    #,#.00#;(#,#.00#): (903,145,792,771,643,190,182.00)