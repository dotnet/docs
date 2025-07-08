' <Snippet1>
Imports System.Globalization
Imports System.Resources
Imports System.Threading

Module Example
   Sub Main()
      ' Create array of supported cultures
      Dim cultures() As String = {"en-CA", "en-US", "fr-FR", "ru-RU" }
      Dim rnd As New Random()
      Dim cultureNdx As Integer = rnd.Next(0, cultures.Length)
      Dim originalCulture As CultureInfo = Thread.CurrentThread.CurrentCulture
      Dim rm As New ResourceManager("Greetings", GetType(Example).Assembly)
      Try
         Dim newCulture As New CultureInfo(cultures(cultureNdx))
         Thread.CurrentThread.CurrentCulture = newCulture
         Thread.CurrentThread.CurrentUICulture = newCulture
         Dim greeting As String = String.Format("The current culture is {0}.{1}{2}",
                                                Thread.CurrentThread.CurrentUICulture.Name,
                                                vbCrLf, rm.GetString("HelloString"))

         Console.WriteLine(greeting)
      Catch e As CultureNotFoundException
         Console.WriteLine("Unable to instantiate culture {0}", e.InvalidCultureName)
      Finally
         Thread.CurrentThread.CurrentCulture = originalCulture
         Thread.CurrentThread.CurrentUICulture = originalCulture
      End Try
   End Sub
End Module
' The example displays output like the following:
'       The current culture is ru-RU.
'       Всем привет!
' </Snippet1>