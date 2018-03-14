'<snippet1>
' Example for the Math.E field.
Imports System
Imports Microsoft.VisualBasic

Module EField
       
    Sub Main()
        Console.WriteLine( _
            "This example of Math.E = {0:E16}" & vbCrLf & _
            "generates the following output." & vbCrLf, _
            Math.E )
        Console.WriteLine( _
            "Define the power series PS(n) = Sum(k->0,n)[1/k!]" )
        Console.WriteLine( " (limit n->infinity)PS(n) = e" )
        Console.WriteLine( _
            "Display PS(n) and Math.E - PS(n), " & _
            "and stop when delta < 1.0E-15" & vbCrLf )
          
        CalcPowerSeries()
    End Sub 'Main
       
    ' Approximate E with a power series.
    Sub CalcPowerSeries()
        Dim factorial As Double = 1.0
        Dim PS As Double = 0.0
          
        ' Stop iterating when the series converges,
        ' and prevent a runaway process.
        Dim n As Integer
        For n = 0 To 999

            ' Calculate a running factorial.
            If n > 0 Then
                factorial *= System.Convert.ToDouble(n)
            End If 

            ' Calculate and display the power series.
            PS += 1.0 / factorial
            Console.WriteLine( _
                "PS({0:D2}) = {1:E16},  Math.E - PS({0:D2}) = {2:E16}", _
                n, PS, Math.E - PS )

            ' Exit when the series converges.
            If Math.Abs( Math.E - PS ) < 1.0E-15 Then
                Exit For
            End If
        Next n
    End Sub 'CalcPowerSeries
    End Module 'EField

' This example of Math.E = 2.7182818284590451E+000
' generates the following output.
' 
' Define the power series PS(n) = Sum(k->0,n)[1/k!]
'  (limit n->infinity)PS(n) = e
' Display PS(n) and Math.E - PS(n), and stop when delta < 1.0E-15
' 
' PS(00) = 1.0000000000000000E+000,  Math.E - PS(00) = 1.7182818284590451E+000
' PS(01) = 2.0000000000000000E+000,  Math.E - PS(01) = 7.1828182845904509E-001
' PS(02) = 2.5000000000000000E+000,  Math.E - PS(02) = 2.1828182845904509E-001
' PS(03) = 2.6666666666666665E+000,  Math.E - PS(03) = 5.1615161792378572E-002
' PS(04) = 2.7083333333333330E+000,  Math.E - PS(04) = 9.9484951257120535E-003
' PS(05) = 2.7166666666666663E+000,  Math.E - PS(05) = 1.6151617923787498E-003
' PS(06) = 2.7180555555555554E+000,  Math.E - PS(06) = 2.2627290348964380E-004
' PS(07) = 2.7182539682539684E+000,  Math.E - PS(07) = 2.7860205076724043E-005
' PS(08) = 2.7182787698412700E+000,  Math.E - PS(08) = 3.0586177750535626E-006
' PS(09) = 2.7182815255731922E+000,  Math.E - PS(09) = 3.0288585284310443E-007
' PS(10) = 2.7182818011463845E+000,  Math.E - PS(10) = 2.7312660577649694E-008
' PS(11) = 2.7182818261984929E+000,  Math.E - PS(11) = 2.2605521898810821E-009
' PS(12) = 2.7182818282861687E+000,  Math.E - PS(12) = 1.7287637987806193E-010
' PS(13) = 2.7182818284467594E+000,  Math.E - PS(13) = 1.2285727990501982E-011
' PS(14) = 2.7182818284582302E+000,  Math.E - PS(14) = 8.1490370007486490E-013
' PS(15) = 2.7182818284589949E+000,  Math.E - PS(15) = 5.0182080713057076E-014
' PS(16) = 2.7182818284590429E+000,  Math.E - PS(16) = 2.2204460492503131E-015
' PS(17) = 2.7182818284590455E+000,  Math.E - PS(17) = -4.4408920985006262E-016
'</snippet1>
