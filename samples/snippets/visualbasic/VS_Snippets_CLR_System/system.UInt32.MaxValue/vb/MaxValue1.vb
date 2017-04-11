' Visual Basic .NET Document
Option Strict On

Module ULongRangeExample
   Public Sub Main()
      ' <Snippet1>
      Dim longValue As Long = Long.MaxValue \ 2
      Dim integerValue As UInteger 
      
      If longValue <= UInteger.MaxValue AndAlso _
         longValue >= UInteger.MinValue Then
         integerValue = CUInt(longValue)
         Console.WriteLine("Converted long integer value to {0:n0}.", _
                           integerValue)
      Else
         Dim rangeLimit As UInteger
         Dim relationship As String
         
         If longValue > UInteger.MaxValue Then
            rangeLimit = UInteger.MaxValue
            relationship = "greater"
         Else
            rangeLimit = UInteger.MinValue
            relationship = "less"
         End If       

         Console.WriteLine("Conversion failure: {0:n0} is {1} than {2:n0}.", _ 
                           longValue, _
                           relationship, _
                           rangeLimit)
      End If       
      ' </Snippet1>
   End Sub
End Module

