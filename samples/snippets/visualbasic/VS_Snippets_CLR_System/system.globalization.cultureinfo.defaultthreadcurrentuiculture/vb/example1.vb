' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Reflection
Imports System.Resources
Imports System.Threading

<Assembly:NeutralResourcesLanguageAttribute("en-US")>

Public Class Example
   Private Shared nGreetings As Integer = 0
   Private Shared rm As ResourceManager

   Public Shared Sub Main()
      Dim domain As AppDomain = AppDomain.CurrentDomain
      rm = New ResourceManager("GreetingStrings", 
                               GetType(Example).Assembly)
                  
      Dim culture As CultureInfo = Nothing
      If Thread.CurrentThread.CurrentUICulture.Name = "ru-RU" Then
         culture = CultureInfo.CreateSpecificCulture("en-US")
      Else
         culture = CultureInfo.CreateSpecificCulture("ru-RU")
      End If   
      Thread.CurrentThread.CurrentCulture = culture
      Thread.CurrentThread.CurrentUICulture = culture

      ShowGreeting()
      Thread.Sleep(1000)

      Dim workerThread As New Thread(AddressOf Example.ShowGreeting)
      workerThread.Start()
   End Sub
   
   Private Shared Sub ShowGreeting()
      Dim greeting As String = CStr(IIf(nGreetings = 0, 
                                        rm.GetString("newGreeting"),
                                        rm.GetString("greeting")))
      nGreetings += 1
      Console.WriteLine("{0}", greeting)   
   End Sub
End Class
' The example displays the following output:
'       Привет!
'       Hello again!
' </Snippet1>
