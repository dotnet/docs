' Visual Basic .NET Document
Option Strict On

Module SByteRangeExample
   Public Sub Main()
      ' <Snippet1>
      Dim longValue As Long = -130
      Dim byteValue As SByte 
      
      If longValue <= SByte.MaxValue AndAlso _
         longValue >= SByte.MinValue Then
         byteValue = CSByte(longValue)
         Console.WriteLine("Converted long integer value to {0}.", byteValue)
      Else
         Dim rangeLimit As SByte
         Dim relationship As String
         
         If longValue > SByte.MaxValue Then
            rangeLimit = SByte.MaxValue
            relationship = "greater"
         Else
            rangeLimit = SByte.MinValue
            relationship = "less"
         End If       

         Console.WriteLine("Conversion failure: {0:n0} is {1} than {2}.", _ 
                           longValue, _
                           relationship, _
                           rangeLimit)
      End If       
      ' </Snippet1>
   End Sub
End Module

