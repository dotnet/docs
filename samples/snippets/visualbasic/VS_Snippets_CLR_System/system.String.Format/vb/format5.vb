' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Module Example
   Public Sub Main()
      Dim date1 As Date = #7/1/2009#
      Dim hiTime As New TimeSpan(14, 17, 32)
      Dim hiTemp As Decimal = 62.1d 
      Dim loTime As New TimeSpan(3, 16, 10)
      Dim loTemp As Decimal = 54.8d 

      Dim result1 As String = String.Format("Temperature on {0:d}:{5}{1,11}: {2} degrees (hi){5}{3,11}: {4} degrees (lo)", _
                                           date1, hiTime, hiTemp, loTime, loTemp, vbCrLf)
      Console.WriteLine(result1)
      Console.WriteLine()
           
      Dim result2 As String = String.Format("Temperature on {0:d}:{5}{1,11}: {2} degrees (hi){5}{3,11}: {4} degrees (lo)", _
                                            New Object() { date1, hiTime, hiTemp, loTime, loTemp, vbCrLf })
      Console.WriteLine(result2)                                            
   End Sub
End Module
' The example displays the following output:
'       Temperature on 7/1/2009:
'          14:17:32: 62.1 degrees (hi)
'          03:16:10: 54.8 degrees (lo)
'
'       Temperature on 7/1/2009:
'          14:17:32: 62.1 degrees (hi)
'          03:16:10: 54.8 degrees (lo)
' </Snippet5>
