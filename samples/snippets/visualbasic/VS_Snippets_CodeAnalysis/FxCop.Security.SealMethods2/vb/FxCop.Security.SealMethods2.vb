'<Snippet1>
Imports System

Namespace SecurityLibrary

   Public Class BaseImplementation
   
      Overridable Function UserIsValidated() As Boolean
         Return False
      End Function

   End Class

   Public Class UseBaseImplementation
   
      Sub SecurityDecision(someImplementation As BaseImplementation)

         If(someImplementation.UserIsValidated() = True)
            Console.WriteLine("Account number & balance.")
         Else
            Console.WriteLine("Please login.")
         End If

      End Sub
   
   End Class

End Namespace
'</Snippet1>
