Imports System.Resources

Module CreateResource
   Public Sub Main()
      Dim en As New Numbers("one", "two", "three", "four", "five",
                            "six", "seven", "eight", "nine", "ten")
      CreateResourceFile(en, "en")
      Dim fr As New Numbers("un", "deux", "trois", "quatre", "cinq", 
                            "six", "sept", "huit", "neuf", "dix")
      CreateResourceFile(fr, "fr")
      Dim pt As New Numbers("um", "dois", "três", "quatro", "cinco", 
                            "seis", "sete", "oito", "nove", "dez")
      CreateResourceFile(pt, "pt") 
      Dim ru As New Numbers("один", "два", "три", "четыре", "пять", 
                            "шесть", "семь", "восемь", "девять", "десять")                                                       
      CreateResourceFile(ru, "ru")
   End Sub

   Public Sub CreateResourceFile(n As Numbers, lang As String)
      Dim filename As String = ".\NumberResources" + 
                               If(lang <> "en", "." + lang, "") +
                               ".resx"
      Dim rr As New ResXResourceWriter(filename)
      rr.AddResource("Numbers", n)
      rr.Generate()
      rr.Close()    
   End Sub
End Module