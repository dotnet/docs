' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Resources
Imports System.Globalization
Imports System.Threading

<Assembly:NeutralResourcesLanguage("en")>

Module Example
   Public Sub Main()
      Dim cultureNames() As String = {"en-US", "fr-FR", "ru-RU", "sv-SE" }
      Dim noon As New Date(Date.Now.Year, Date.Now.Month, 
                           Date.Now.Day, 12,0,0)
      Dim evening As New Date(Date.Now.Year, Date.Now.Month,
                              Date.Now.Day, 18, 0, 0)                          
      
      Dim rm As New ResourceManager(GetType(GreetingResources))
      
      For Each cultureName In cultureNames
         Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName)
         Console.WriteLine("The current UI culture is {0}", 
                           CultureInfo.CurrentUICulture.Name)
         If Date.Now < noon Then
            Console.WriteLine("{0}!", rm.GetString("Morning"))
         ElseIf Date.Now < evening Then
            Console.WriteLine("{0}!", rm.GetString("Afternoon"))
         Else
            Console.WriteLine("{0}!", rm.GetString("Evening"))
         End If 
         Console.WriteLine()
      Next
   End Sub
End Module

Friend Class GreetingResources
End Class
' The example displays output like the following:
'       The current UI culture is en-US
'       Good afternoon!
'       
'       The current UI culture is fr-FR
'       Bonjour!
'       
'       The current UI culture is ru-RU
'       Добрый день!
'       
'       The current UI culture is sv-SE
'       Good afternoon!
' </Snippet3>
