      Const LIGHT_YEAR As Long = 5878625373183
   
      Dim altairDistance As BigInteger = 17 * LIGHT_YEAR
      Dim epsilonIndiDistance As BigInteger = 12 * LIGHT_YEAR
      Dim ursaeMajoris47Distance As BigInteger = 46 * LIGHT_YEAR
      Dim tauCetiDistance As BigInteger = 12 * LIGHT_YEAR
      Dim procyon2Distance As Long = 12 * LIGHT_YEAR
      Dim wolf424ABDistance As Object = 14 * LIGHT_YEAR
      
      Console.WriteLine("Approx. equal distances from Epsilon Indi to:")
      Console.WriteLine("   Altair: {0}", _
                        epsilonIndiDistance.Equals(altairDistance))
      Console.WriteLine("   Ursae Majoris 47: {0}", _
                        epsilonIndiDistance.Equals(ursaeMajoris47Distance))
      Console.WriteLine("   TauCeti: {0}", _
                        epsilonIndiDistance.Equals(tauCetiDistance))
      Console.WriteLine("   Procyon 2: {0}", _
                        epsilonIndiDistance.Equals(procyon2Distance))
      Console.WriteLine("   Wolf 424 AB: {0}", _
                        epsilonIndiDistance.Equals(wolf424ABDistance))
      ' The example displays the following output:
      '    Approx. equal distances from Epsilon Indi to:
      '       Altair: False
      '       Ursae Majoris 47: False
      '       TauCeti: True
      '       Procyon 2: True
      '       Wolf 424 AB: False