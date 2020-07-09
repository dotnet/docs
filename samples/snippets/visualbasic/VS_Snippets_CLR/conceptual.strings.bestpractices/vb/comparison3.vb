' Visual Basic .NET Document
Option Strict On

<Assembly: CLSCompliant(True)>
Module modMain

    Public Sub Main()
        ' <Snippet15>
        Dim separated As String = ChrW(&h61) + ChrW(&h30a)
        Dim combined As String = ChrW(&he5)

        Console.WriteLine("Equal sort weight of {0} and {1} using InvariantCulture: {2}", _
                          separated, combined, _
                          String.Compare(separated, combined, _
                                         StringComparison.InvariantCulture) = 0)

        Console.WriteLine("Equal sort weight of {0} and {1} using Ordinal: {2}", _
                          separated, combined, _
                          String.Compare(separated, combined, _
                                         StringComparison.Ordinal) = 0)
        ' The example displays the following output:
        '    Equal sort weight of a° and å using InvariantCulture: True
        '    Equal sort weight of a° and å using Ordinal: False
        ' </Snippet15>
    End Sub
End Module

