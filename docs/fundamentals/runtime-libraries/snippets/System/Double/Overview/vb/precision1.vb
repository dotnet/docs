' Visual Basic .NET Document
Option Strict On

Module Example9
    Public Sub Main()
        ' <Snippet1>
        Dim value As Double = -4.4233060424477198E-305

        Dim fromLiteral As Double = -4.4233060424477198E-305
        Dim fromVariable As Double = value
        Dim fromParse As Double = Double.Parse("-4.42330604244772E-305")

        Console.WriteLine("Double value from literal: {0,29:R}", fromLiteral)
        Console.WriteLine("Double value from variable: {0,28:R}", fromVariable)
        Console.WriteLine("Double value from Parse method: {0,24:R}", fromParse)
        ' On 32-bit versions of the .NET Framework, the output is:
        '    Double value from literal:        -4.42330604244772E-305
        '    Double value from variable:       -4.42330604244772E-305
        '    Double value from Parse method:   -4.42330604244772E-305
        '
        ' On other versions of the .NET Framework, the output is:
        '    Double value from literal:        -4.4233060424477198E-305
        '    Double value from variable:       -4.4233060424477198E-305
        '    Double value from Parse method:     -4.42330604244772E-305      
        ' </Snippet1>
    End Sub
End Module

