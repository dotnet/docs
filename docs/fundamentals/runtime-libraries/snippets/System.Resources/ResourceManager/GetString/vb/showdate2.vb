' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization
Imports System.Resources
Imports System.Threading

Module Example2
    Public Sub Main()
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU")
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ru-RU")

        Dim cultureNames() As String = {"fr-FR", "sv-SE"}
        Dim rm As New ResourceManager("DateStrings",
                                    GetType(Example).Assembly)

        For Each cultureName In cultureNames
            Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture(cultureName)
            Dim dateString As String = rm.GetString("DateStart", culture)
            Console.WriteLine("{0}: {1} {2}.", culture.DisplayName, dateString,
                                            Date.Now.ToString("M", culture))
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays output similar to the following:
'       French (France): Aujourd'hui, c'est le 7 février.
'       
'       Swedish (Sweden): Today is den 7 februari.
' </Snippet3>
