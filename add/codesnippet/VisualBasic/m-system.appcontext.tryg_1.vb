Public Class AmazingLib

   Private shouldThrow As Boolean

   Public Sub PerformAnOperation()
      If Not AppContext.TryGetSwitch("Switch.AmazingLib.ThrowOnException", shouldThrow) Then 
         ' This is the case where the switch value was not set by the application. 
         ' The library can choose to get the value of shouldThrow by other means. 
         ' If no overrides or default values are specified, the value should be 'false'. 
         ' A false value implies the latest behavior.
      End If

      ' The library can use the value of shouldThrow to throw exceptions or not.
      If shouldThrow Then
         ' old code
      Else 
          ' new code
      End If
   End Sub
End Class