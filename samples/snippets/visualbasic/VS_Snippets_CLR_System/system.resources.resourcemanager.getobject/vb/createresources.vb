' Visual Basic .NET Document
Option Strict On

' <Snippet2>
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
' </Snippet2>

<Serializable> Public Class Numbers
   Public Readonly One As String
   Public ReadOnly Two As String
   Public ReadOnly Three As String
   Public ReadOnly Four As String
   Public ReadOnly Five As String
   Public ReadOnly Six As String
   Public ReadOnly Seven As String
   Public ReadOnly Eight As String
   Public ReadOnly Nine As String
   Public ReadOnly Ten As String
   
   Public Sub New(one As String, two As String, three As String, four As String, 
                  five As String, six As String, seven As String, eight As String,
                  nine As String, ten As String)
      Me.One = one
      Me.Two = two
      Me.Three = three
      Me.Four = four
      Me.Five = five
      Me.Six = six
      Me.Seven = seven
      Me.Eight = eight
      Me.Nine = nine
      Me.Ten = ten                                    
   End Sub                  
End Class
