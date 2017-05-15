' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

<ComVisible(True)> _
Class MyComVisibleType

   Public Sub New()
      Console.WriteLine("MyComVisibleType instantiated!")
   End Sub 'New

End Class 'MyComVisibleType

<ComVisible(False)> _
Class MyComNonVisibleType

   Public Sub New()
      Console.WriteLine("MyComNonVisibleType instantiated!")
   End Sub 'New

End Class 'MyComNonVisibleType

Module Test

   Sub Main()
      CreateComInstance("MyComNonVisibleType")   ' Fail!
      CreateComInstance("MyComVisibleType")      ' OK!
   End Sub 'Main

   Sub CreateComInstance(typeName As String)
      Try
         Dim currentDomain As AppDomain = AppDomain.CurrentDomain
         Dim assemblyName As String = currentDomain.FriendlyName
         currentDomain.CreateComInstanceFrom(assemblyName, typeName)
      Catch e As Exception
         Console.WriteLine(e.Message)
      End Try
   End Sub 'CreateComInstance

End Module 'Test
' </Snippet1>