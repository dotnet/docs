      Dim positiveString As String = "91389681247993671255432112000000"
      Dim negativeString As string = "-90315837410896312071002088037140000"
      Dim posBigInt As BigInteger = 0
      Dim negBigInt As BigInteger = 0

      Try
         posBigInt = BigInteger.Parse(positiveString)
         Console.WriteLine(posBigInt)
      Catch e As FormatException
         Console.WriteLine("Unable to convert the string '{0}' to a BigInteger value.", _
                           positiveString)
      End Try

      If BigInteger.TryParse(negativeString, negBigInt) Then
        Console.WriteLine(negBigInt)
      Else
         Console.WriteLine("Unable to convert the string '{0}' to a BigInteger value.", _
                            negativeString)
      End If         
      ' The example displays the following output:
      '   9.1389681247993671255432112E+31
      '   -9.0315837410896312071002088037E+34