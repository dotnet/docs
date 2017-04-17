' Visual Basic .NET Document
Option Strict On

Imports System.Reflection
Imports System.Resources
' <Snippet3>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      Dim cultureNames() As String = { "en-GB", "en-US", "fr-FR", "ru-RU" }
      Dim rnd As New Random()
      Dim cultureName As String = cultureNames(rnd.Next(0, cultureNames.Length)) 
      Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName)
      Console.WriteLine("The current UI culture is {0}", 
                        Thread.CurrentThread.CurrentUICulture.Name)
      Dim strLib As New StringLibrary()
      Dim greeting As String = strLib.GetGreeting()
      Console.WriteLine(greeting)
   End Sub
End Module
' </Snippet3>

Public Class StringLibrary
   Public Function GetGreeting() As String
      Dim rm As New ResourceManager("Strings", _
                                    Assembly.GetAssembly(GetType(StringLibrary)))
      Dim greeting As String = rm.GetString("Greeting")
      Return greeting
   End Function
End Class
