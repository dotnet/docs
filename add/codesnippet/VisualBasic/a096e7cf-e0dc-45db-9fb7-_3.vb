Imports System.Globalization
Imports System.Resources 
Imports System.Threading

<assembly:NeutralResourcesLanguageAttribute("en-US")>

Module Example
   Dim cultureNames() As String = { "fr-FR", "pt-BR", "ru-RU" }
   
   Public Sub Main()
      ' Make any non-default culture the current culture.
      Dim rnd As New Random
      Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture(cultureNames(rnd.Next(0, cultureNames.Length)))
      Thread.CurrentThread.CurrentUICulture = culture
      Console.WriteLine("The current culture is {0}", CultureInfo.CurrentUICulture.Name)
      Console.WriteLine()
      Dim enCulture As CultureInfo = CultureInfo.CreateSpecificCulture("en-US") 

      Dim rm As New ResourceManager(GetType(NumberResources))
      Dim numbers As Numbers = CType(rm.GetObject("Numbers"), Numbers)
      Dim numbersEn As Numbers = CType(rm.GetObject("Numbers", enCulture), Numbers)
      Console.WriteLine("{0} --> {1}", numbers.One, numbersEn.One) 
      Console.WriteLine("{0} --> {1}", numbers.Three, numbersEn.Three) 
      Console.WriteLine("{0} --> {1}", numbers.Five, numbersEn.Five) 
      Console.WriteLine("{0} --> {1}", numbers.Seven, numbersEn.Seven) 
      Console.WriteLine("{0} --> {1}", numbers.Nine, numbersEn.Nine) 
      Console.WriteLine()       
   End Sub
End Module


Friend Class NumberResources
End Class

' The example displays output like the following:
'       The current culture is pt-BR
'       
'       um --> one
'       três --> three
'       cinco --> five
'       sete --> seven
'       nove --> nine