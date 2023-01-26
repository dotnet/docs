Module Program
    Sub Main()
        Dim separated As String = ChrW(&H61) & ChrW(&H30A)
        Dim combined As String = ChrW(&HE5)

        Console.WriteLine("Equal sort weight of {0} and {1} using InvariantCulture: {2}",
                          separated, combined,
                          String.Compare(separated, combined, StringComparison.InvariantCulture) = 0)

        Console.WriteLine("Equal sort weight of {0} and {1} using Ordinal: {2}",
                          separated, combined,
                          String.Compare(separated, combined, StringComparison.Ordinal) = 0)

        ' The example displays the following output:
        '     Equal sort weight of a° and å using InvariantCulture: True
        '     Equal sort weight of a° and å using Ordinal: False
    End Sub
End Module
