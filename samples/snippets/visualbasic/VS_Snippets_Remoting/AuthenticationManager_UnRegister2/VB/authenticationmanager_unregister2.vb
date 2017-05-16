' System.Net.AuthenticationManager.UnRegister(String).
' System.Net.AuthenticationManager.Register.
' Grouping Clause : 1,3 AND 2,3.

 'This program demonstrates the  'UnRegister(String) ' and 'Register' methods of 
''AuthenticationManager' class. It gets all the authentication modules registered with the system into an 
'IEnumerator instance ,unregisters the first authentication module and displays to show that it was 
'unregistered. Then registers the same module back again and displays all the modules again.

Imports System
Imports System.Net
Imports System.Collections
Imports Microsoft.VisualBasic


Namespace Authentication2
  
  Class Class1
    
    Public Shared Sub Main()
      
      Try
' <Snippet1>
' <Snippet2>
        Dim registeredModules As IEnumerator = AuthenticationManager.RegisteredModules
        DisplayAllModules()
        
        registeredModules.Reset()
        registeredModules.MoveNext()
        
        'Get the first Authentication module registered with the system
        Dim authenticationModule1 As IAuthenticationModule = CType(registeredModules.Current, IAuthenticationModule)
        
        'Call the UnRegister method to unregister the first authentication module from the system.
        Dim authenticationScheme As [String] = authenticationModule1.AuthenticationType
        AuthenticationManager.Unregister(authenticationScheme)
        Console.WriteLine(ControlChars.Cr + "Successfully unregistered {0}", authenticationModule1)
        'Display all modules to see that the module was unregistered.
        DisplayAllModules()
' </Snippet1>
        'Call the Register method to register authenticationModule1 module again.
        AuthenticationManager.Register(authenticationModule1)
        Console.WriteLine(ControlChars.Cr + "Successfully re-registered {0}", authenticationModule1)
        'Display the modules to verify that 'authenticationModule1' has been registered again.
        DisplayAllModules()
' </Snippet2>
        Console.WriteLine("Press any key to continue")
        Console.ReadLine()
      Catch e As Exception
        Console.WriteLine(ControlChars.Cr + " The following exception was raised : {0}", e.Message)
      End Try
    End Sub 'Main
' <Snippet3>    
    Shared Sub DisplayAllModules()
      Dim registeredModules As IEnumerator = AuthenticationManager.RegisteredModules
      Console.WriteLine(ControlChars.Cr + ControlChars.Tab + "The following modules are now registered with the system:")
      While registeredModules.MoveNext()
        Console.WriteLine(ControlChars.Cr + ControlChars.Tab + ControlChars.Tab + "Module : {0}", registeredModules.Current)
        Dim currentAuthenticationModule As IAuthenticationModule = CType(registeredModules.Current, IAuthenticationModule)
        Console.WriteLine(ControlChars.Tab + ControlChars.Tab + ControlChars.Tab + " CanPreAuthenticate : {0}", currentAuthenticationModule.CanPreAuthenticate)
      End While 
    End Sub 'DisplayAllModules
  End Class 'Class1
' </Snippet3>
End Namespace 'Authentication2