' <Snippet1>
Imports System.Reflection
Imports System.Runtime.InteropServices

<ComVisible(True)> _
Class MyComVisibleType

   Public Sub New()
      Console.WriteLine("MyComVisibleType instantiated!")
   End Sub

End Class

<ComVisible(False)> _
Class MyComNonVisibleType

   Public Sub New()
      Console.WriteLine("MyComNonVisibleType instantiated!")
   End Sub

End Class

Module Test

   Sub Main()
      CreateComInstance("MyComNonVisibleType")   ' Fail!
      CreateComInstance("MyComVisibleType")      ' OK!
   End Sub

   Sub CreateComInstance(typeName As String)
      Try
         Dim currentDomain As AppDomain = AppDomain.CurrentDomain
         Dim assemblyName As String = currentDomain.FriendlyName
         currentDomain.CreateComInstanceFrom(assemblyName, typeName)
      Catch e As Exception
         Console.WriteLine(e.Message)
      End Try
   End Sub

End Module 'Test
' </Snippet1>