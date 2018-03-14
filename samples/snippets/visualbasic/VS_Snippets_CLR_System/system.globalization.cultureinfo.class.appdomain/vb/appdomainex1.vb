' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Reflection
Imports System.Threading

Module Example
   Public Sub Main()
      ' Set the default culture and display the current date in the current application domain.
      Dim info1 As New Info()
      SetAppDomainCultures("fr-FR")
      
      ' Create a second application domain.
      Dim setup As New AppDomainSetup()
      setup.AppDomainInitializer = AddressOf SetAppDomainCultures
      setup.AppDomainInitializerArguments = { "ru-RU" }
      Dim domain As AppDomain = AppDomain.CreateDomain("Domain2", Nothing, setup)
      ' Create an Info object in the new application domain.
      Dim info2 As Info = CType(domain.CreateInstanceAndUnwrap(GetType(Example).Assembly.FullName, 
                                                               "Info"), Info) 

      ' Execute methods in the two application domains.
      info2.DisplayDate()
      info2.DisplayCultures()
      
      info1.DisplayDate()
      info1.DisplayCultures()            
   End Sub
   
   Public Sub SetAppDomainCultures(names() As String)
      SetAppDomainCultures(names(0))
   End Sub
   
   Public Sub SetAppDomainCultures(name As String)
       Try
         CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture(name)
         CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture(name)
      ' If an exception occurs, we'll just fall back to the system default.
      Catch e As CultureNotFoundException
         Return
      Catch e As ArgumentException
         Return
      End Try      
   End Sub
End Module

Public Class Info : Inherits MarshalByRefObject
   Public Sub DisplayDate()
      Console.WriteLine("Today is {0:D}", Date.Now)
   End Sub
   
   Public Sub DisplayCultures()
      Console.WriteLine("Application domain is {0}", AppDomain.CurrentDomain.Id)
      Console.WriteLine("Default Culture: {0}", CultureInfo.DefaultThreadCurrentCulture)
      Console.WriteLine("Default UI Culture: {0}", CultureInfo.DefaultThreadCurrentUICulture)
   End Sub
End Class
' The example displays the following output:
'       Today is 14 октября 2011 г.
'       Application domain is 2
'       Default Culture: ru-RU
'       Default UI Culture: ru-RU
'       Today is vendredi 14 octobre 2011
'       Application domain is 1
'       Default Culture: fr-FR
'       Default UI Culture: fr-FR
' </Snippet1>
