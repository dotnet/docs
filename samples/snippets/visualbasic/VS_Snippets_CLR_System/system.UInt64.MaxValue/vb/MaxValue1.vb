' Visual Basic .NET Document
Option Strict On

Module ULongRangeExample
   Public Sub Main()
      ' <Snippet1>
      Dim decimalValue As Double = -1.5
      Dim integerValue As ULong 
      
      ' Discard fractional portion of Double value
      Dim decimalInteger As Double = Math.Floor(decimalValue)

      If decimalInteger <= ULong.MaxValue AndAlso _
         decimalInteger >= ULong.MinValue Then
         integerValue = CULng(decimalValue)
         Console.WriteLine("Converted {0} to {1}.", decimalValue, integerValue)
      Else
         Dim rangeLimit As ULong
         Dim relationship As String
         
         If decimalInteger > ULong.MaxValue Then
            rangeLimit = ULong.MaxValue
            relationship = "greater"
         Else
            rangeLimit = ULong.MinValue
            relationship = "less"
         End If       

         Console.WriteLine("Conversion failure: {0} is {1} than {2}", _ 
                           decimalInteger, _
                           relationship, _
                           rangeLimit)
      End If       
      ' </Snippet1>
   End Sub
End Module

