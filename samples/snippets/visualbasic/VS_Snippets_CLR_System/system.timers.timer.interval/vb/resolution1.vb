' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Private Declare Function GetSystemTimeAdjustment Lib "Kernel32" (
                   ByRef lpTimeAdjustment As Long, ByRef lpTimeIncrement As Long,
                   ByRef lpTimeAdjustmentDisabled As Boolean) As Boolean

   Public Sub Main()
      Dim timeAdjustment, timeIncrement As Long
      Dim timeAdjustmentDisabled As Boolean
      
      If GetSystemTimeAdjustment(timeAdjustment, timeIncrement, 
                                  timeAdjustmentDisabled) Then
         If Not timeAdjustmentDisabled Then
            Console.WriteLine("System clock resolution: {0:N3} milliseconds", 
                              timeIncrement/10000.0)
         Else
            Console.WriteLine("Unable to determine system clock resolution.")                     
         End If
      End If
   End Sub
End Module
' The example displays output similar to the following:
'       System clock resolution: 15.625 milliseconds
' </Snippet2>
