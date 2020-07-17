' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Imports System.Globalization
Imports System.Resources
Imports System.Threading

<Assembly: NeutralResourcesLanguageAttribute("en-US")>

Module Example
    Public Sub Main()
        Dim cultureNames() As String = {"en-US", "en-CA", "ru-RU", "fr-FR"}
        Dim rm As ResourceManager = ResourceManager.CreateFileBasedResourceManager("Strings", "Resources", Nothing)

        For Each cultureName In cultureNames
            Console.WriteLine()
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName)
            Dim greeting As String = rm.GetString("Greeting", CultureInfo.CurrentCulture)
            Console.WriteLine("{0}!", greeting)
            Console.Write(rm.GetString("Prompt", CultureInfo.CurrentCulture))
            Dim name As String = Console.ReadLine()
            If Not String.IsNullOrEmpty(name) Then
                Console.WriteLine("{0}, {1}!", greeting, name)
            End If
        Next
        Console.WriteLine()
    End Sub
End Module
' The example displays output like the following:
'       Hello!
'       What is your name? Dakota
'       Hello, Dakota!
'       
'       Hello!
'       What is your name? Koani
'       Hello, Koani!
'       
'       Здравствуйте!
'       Как вас зовут?Samuel
'       Здравствуйте, Samuel!
'       
'       Bon jour!
'       Comment vous appelez-vous?Yiska
'       Bon jour, Yiska!
' </Snippet9>

