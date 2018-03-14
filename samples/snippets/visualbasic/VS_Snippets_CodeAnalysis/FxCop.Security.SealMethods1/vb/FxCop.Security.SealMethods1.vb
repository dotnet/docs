'<Snippet1>
Imports System

Namespace SecurityLibrary

   Interface IValidate
      Function UserIsValidated() As Boolean
   End Interface

   Public Class BaseImplementation
      Implements IValidate
   
      Overridable Function UserIsValidated() As Boolean _ 
         Implements IValidate.UserIsValidated
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
