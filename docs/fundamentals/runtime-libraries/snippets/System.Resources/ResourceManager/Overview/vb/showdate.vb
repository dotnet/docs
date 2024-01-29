' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization
Imports System.Resources
Imports System.Threading

<Assembly:NeutralResourcesLanguage("en")>

Module Example5
    Public Sub Main()
        Dim cultureNames() As String = {"en-US", "fr-FR", "ru-RU", "sv-SE"}
        Dim rm As New ResourceManager("DateStrings",
                                    GetType(Example5).Assembly)

        For Each cultureName In cultureNames
            Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture(cultureName)
            Thread.CurrentThread.CurrentCulture = culture
            Thread.CurrentThread.CurrentUICulture = culture

            Console.WriteLine("Current UI Culture: {0}",
                           CultureInfo.CurrentUICulture.Name)
            Dim dateString As String = rm.GetString("DateStart")
            Console.WriteLine("{0} {1:M}.", dateString, Date.Now)
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays output similar to the following:
'       Current UI Culture: en-US
'       Today is February 03.
'       
'       Current UI Culture: fr-FR
'       Aujourd'hui, c'est le 3 février
'       
'       Current UI Culture: ru-RU
'       Сегодня февраля 03.
'       
'       Current UI Culture: sv-SE
'       Today is den 3 februari.
' </Snippet2>
