' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Module Example
   Public Sub Main()
      Dim intValue1 As Integer? = 12893
      Dim dValue1 As Double = CType(Convert.ChangeType(intValue1, GetType(Double), Nothing), Double)
      Console.WriteLine("{0} ({1})--> {2} ({3})", intValue1, intValue1.GetType().Name,
                        dValue1, dValue1.GetType().Name)
      

      Dim fValue1 As Single = 16.3478
      Dim intValue2 As Integer? = CType(fValue1, Integer) 
      Console.WriteLine("{0} ({1})--> {2} ({3})", fValue1, fValue1.GetType().Name,
                        intValue2, intValue2.GetType().Name)
   End Sub
End Module
' The example displays the following output:
'       12893 (Int32)--> 12893 (Double)
'       16.3478 (Single)--> 16 (Int32)
' </Snippet8>
