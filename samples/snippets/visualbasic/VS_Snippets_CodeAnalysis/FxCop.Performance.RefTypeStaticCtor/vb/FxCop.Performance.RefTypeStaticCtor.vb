'<Snippet1>
Imports System
Imports System.Resources

Namespace PerformanceLibrary

   Public Class StaticConstructor

      Shared someInteger As Integer
      Shared resourceString As String 

      Shared Sub New()

         someInteger = 3
         Dim stringManager As New ResourceManager("strings", _
            System.Reflection.Assembly.GetExecutingAssembly())
         resourceString = stringManager.GetString("string")

      End Sub

   End Class


   Public Class NoStaticConstructor

      Shared someInteger As Integer = 3
      Shared resourceString As String = InitializeResourceString()

      Shared Private Function InitializeResourceString()

         Dim stringManager As New ResourceManager("strings", _
            System.Reflection.Assembly.GetExecutingAssembly())
         Return stringManager.GetString("string")

      End Function

   End Class

End Namespace
'</Snippet1>
