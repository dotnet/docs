      ' Create a BigInteger from a large negative Single value
      Dim negativeSingle As Single = Single.MinValue
      Dim negativeNumber As New BigInteger(negativeSingle)
      
      Console.WriteLine(negativeSingle.ToString("N0"))
      Console.WriteLine(negativeNumber.ToString("N0"))
      
      negativeSingle += 1
      negativeNumber += 1
      Console.WriteLine(negativeSingle.ToString("N0"))
      Console.WriteLine(negativeNumber.ToString("N0"))
      ' The example displays the following output:
      '       -340,282,300,000,000,000,000,000,000,000,000,000,000
      '       -340,282,346,638,528,859,811,704,183,484,516,925,440
      '       -340,282,300,000,000,000,000,000,000,000,000,000,000
      '       -340,282,346,638,528,859,811,704,183,484,516,925,439