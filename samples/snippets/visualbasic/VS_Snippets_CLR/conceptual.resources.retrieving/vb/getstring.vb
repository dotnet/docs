' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization
Imports System.Resources
Imports System.Threading

<Assembly: NeutralResourcesLanguageAttribute("en-US")>

Module Example
   Public Sub Main()
      Dim cultureNames() As String = { "en-US", "fr-FR", "ru-RU", "es-ES" }
      Dim rnd As New Random()
      Dim rm As New ResourceManager("Strings", GetType(Example).Assembly)
      
      For ctr As Integer = 0 To cultureNames.Length
         Dim cultureName As String = cultureNames(rnd.Next(0, cultureNames.Length))
         Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture(cultureName)
         Thread.CurrentThread.CurrentCulture = culture
         Thread.CurrentThread.CurrentUICulture = culture
         
         Console.WriteLine("Current culture: {0}", culture.NativeName)
         Dim timeString As String = rm.GetString("TimeHeader")
         Console.WriteLine("{0} {1:T}", timeString, Date.Now)   
         Console.WriteLine()
      Next   
   End Sub
End Module
' The example displays output similar to the following:
'    Current culture: English (United States)
'    The current time is 9:34:18 AM
'    
'    Current culture: Español (España, alfabetización internacional)
'    The current time is 9:34:18
'    
'    Current culture: русский (Россия)
'    Текущее время — 9:34:18
'    
'    Current culture: français (France)
'    L'heure actuelle est 09:34:18
'    
'    Current culture: русский (Россия)
'    Текущее время — 9:34:18
' </Snippet3>
