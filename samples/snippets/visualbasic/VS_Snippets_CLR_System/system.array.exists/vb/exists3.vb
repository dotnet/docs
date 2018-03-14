' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
    Public Sub Main()
        Dim planets() As String = {"Mercury", "Venus",
                                    "Earth", "Mars", "Jupiter",
                                    "Saturn", "Uranus", "Neptune"}

        Console.WriteLine("One or more planets begin with 'M': {0}",
            Array.Exists(planets, Function(element)
                                      Return element.StartsWith("M")
                                  End Function))

        Console.WriteLine("One or more planets begin with 'T': {0}",
            Array.Exists(planets, Function(element)
                                      Return element.StartsWith("T")
                                  End Function))

        Console.WriteLine("Is Pluto one of the planets? {0}",
            Array.Exists(planets, Function(element)
                                      Return element.Equals("Pluto")
                                  End Function))

    End Sub
End Module
' The example displays the following output:
'       One or more planets begin with 'M': True
'       One or more planets begin with 'T': False
'       Is Pluto one of the planets? False
' </Snippet3>