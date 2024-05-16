' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Resources
Imports System.Threading 

<Assembly:NeutralResourcesLanguageAttribute("en")>

Module Example
   Public Sub Main()
      ' Select the current culture randomly to test resource fallback.
      Dim cultures() As String = { "de-DE", "en-us", "fr-FR" }
      Dim rnd As New Random()
      Dim index As Integer = rnd.Next(0, cultures.Length)
      Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultures(index))      
      Console.WriteLine("The current culture is {0}", 
                        CultureInfo.CurrentUICulture.Name)       

      ' Retrieve the resource.
      Dim rm As New ResourceManager("ExampleResources" , GetType(Example).Assembly)
      Dim greeting As String = rm.GetString("Greeting")
      
      Console.Write("Enter your name: ")
      Dim name As String = Console.ReadLine()
      Console.WriteLine("{0} {1}", greeting, name)
   End Sub
End Module
' </Snippet1>
