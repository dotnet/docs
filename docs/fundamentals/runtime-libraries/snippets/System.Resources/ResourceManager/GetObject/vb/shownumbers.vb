' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization
Imports System.Resources
Imports System.Threading

Module Example2
    Dim cultureNames() As String = {"fr-FR", "pt-BR", "ru-RU"}

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
' </Snippet3>

<Serializable> Public Class Numbers3
    Public ReadOnly One As String
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
