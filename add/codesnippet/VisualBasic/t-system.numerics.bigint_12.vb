      Dim negativeNumber As Integer = -1000000
      Dim positiveNumber As UInteger = 4293967296
      
      Dim negativeBytes() As Byte = BitConverter.GetBytes(negativeNumber) 
      Dim negativeBigInt As New BigInteger(negativeBytes)
      Console.WriteLine(negativeBigInt.ToString("N0"))
      
      Dim tempPosBytes() As Byte = BitConverter.GetBytes(positiveNumber)
      Dim positiveBytes(tempposBytes.Length) As Byte
      Array.Copy(tempPosBytes, positiveBytes, tempPosBytes.Length)
      Dim positiveBigInt As New BigInteger(positiveBytes)
      Console.WriteLine(positiveBigInt.ToString("N0")) 
      ' The example displays the following output:
      '    -1,000,000
      '    4,293,967,296      