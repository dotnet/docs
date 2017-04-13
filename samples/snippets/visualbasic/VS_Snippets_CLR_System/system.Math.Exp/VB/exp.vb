'<snippet1>
' Example for the Math.Exp( Double ) method.
Imports System
Imports Microsoft.VisualBasic

Module ExpDemo
   
    Sub Main()
        Console.WriteLine( _
            "This example of Math.Exp( Double ) " & _
            "generates the following output." & vbCrLf)
        Console.WriteLine( _
            "Evaluate [e ^ ln(X) == ln(e ^ X) == X] " & _
            "with selected values for X:")

        UseLnExp(0.1)
        UseLnExp(1.2)
        UseLnExp(4.9)
        UseLnExp(9.9)
          
        Console.WriteLine( vbCrLf & _
            "Evaluate these identities with selected values for X and Y:")
        Console.WriteLine("   (e ^ X) * (e ^ Y) = e ^ (X + Y)")
        Console.WriteLine("   (e ^ X) ^ Y = e ^ (X * Y)")
        Console.WriteLine("   X ^ Y = e ^ (Y * ln(X))")
          
        UseTwoArgs(0.1, 1.2)
        UseTwoArgs(1.2, 4.9)
        UseTwoArgs(4.9, 9.9)
    End Sub 'Main
       
    ' Evaluate logarithmic/exponential identity with a given argument.
    Sub UseLnExp(arg As Double)

        ' Evaluate e ^ ln(X) = ln(e ^ X) = X.
        Console.WriteLine( _
            vbCrLf & "      Math.Exp(Math.Log({0})) = {1:E16}" + _
            vbCrLf & "      Math.Log(Math.Exp({0})) = {2:E16}", _
            arg, Math.Exp(Math.Log(arg)), Math.Log(Math.Exp(arg)))
    End Sub 'UseLnExp
       
    ' Evaluate exponential identities that are functions of two arguments.
    Sub UseTwoArgs(argX As Double, argY As Double)

        ' Evaluate (e ^ X) * (e ^ Y) = e ^ (X + Y).
        Console.WriteLine( _
            vbCrLf & "Math.Exp({0}) * Math.Exp({1}) = {2:E16}" + _
            vbCrLf & "          Math.Exp({0} + {1}) = {3:E16}", _
            argX, argY, Math.Exp(argX) * Math.Exp(argY), _
            Math.Exp((argX + argY)))
          
        ' Evaluate (e ^ X) ^ Y = e ^ (X * Y).
        Console.WriteLine( _
            " Math.Pow(Math.Exp({0}), {1}) = {2:E16}" + _
            vbCrLf & "          Math.Exp({0} * {1}) = {3:E16}", _
            argX, argY, Math.Pow(Math.Exp(argX), argY), _
            Math.Exp((argX * argY)))
          
        ' Evaluate X ^ Y = e ^ (Y * ln(X)).
        Console.WriteLine( _
            "           Math.Pow({0}, {1}) = {2:E16}" + _
            vbCrLf & "Math.Exp({1} * Math.Log({0})) = {3:E16}", _
            argX, argY, Math.Pow(argX, argY), _
            Math.Exp((argY * Math.Log(argX))))

    End Sub 'UseTwoArgs
End Module 'ExpDemo

' This example of Math.Exp( Double ) generates the following output.
' 
' Evaluate [e ^ ln(X) == ln(e ^ X) == X] with selected values for X:
' 
'       Math.Exp(Math.Log(0.1)) = 1.0000000000000001E-001
'       Math.Log(Math.Exp(0.1)) = 1.0000000000000008E-001
' 
'       Math.Exp(Math.Log(1.2)) = 1.2000000000000000E+000
'       Math.Log(Math.Exp(1.2)) = 1.2000000000000000E+000
' 
'       Math.Exp(Math.Log(4.9)) = 4.9000000000000012E+000
'       Math.Log(Math.Exp(4.9)) = 4.9000000000000004E+000
' 
'       Math.Exp(Math.Log(9.9)) = 9.9000000000000004E+000
'       Math.Log(Math.Exp(9.9)) = 9.9000000000000004E+000
' 
' Evaluate these identities with selected values for X and Y:
'    (e ^ X) * (e ^ Y) = e ^ (X + Y)
'    (e ^ X) ^ Y = e ^ (X * Y)
'    X ^ Y = e ^ (Y * ln(X))
' 
' Math.Exp(0.1) * Math.Exp(1.2) = 3.6692966676192444E+000
'           Math.Exp(0.1 + 1.2) = 3.6692966676192444E+000
'  Math.Pow(Math.Exp(0.1), 1.2) = 1.1274968515793757E+000
'           Math.Exp(0.1 * 1.2) = 1.1274968515793757E+000
'            Math.Pow(0.1, 1.2) = 6.3095734448019331E-002
' Math.Exp(1.2 * Math.Log(0.1)) = 6.3095734448019344E-002
' 
' Math.Exp(1.2) * Math.Exp(4.9) = 4.4585777008251705E+002
'           Math.Exp(1.2 + 4.9) = 4.4585777008251716E+002
'  Math.Pow(Math.Exp(1.2), 4.9) = 3.5780924170885260E+002
'           Math.Exp(1.2 * 4.9) = 3.5780924170885277E+002
'            Math.Pow(1.2, 4.9) = 2.4433636334442981E+000
' Math.Exp(4.9 * Math.Log(1.2)) = 2.4433636334442981E+000
' 
' Math.Exp(4.9) * Math.Exp(9.9) = 2.6764450551890982E+006
'           Math.Exp(4.9 + 9.9) = 2.6764450551891015E+006
'  Math.Pow(Math.Exp(4.9), 9.9) = 1.1684908531676833E+021
'           Math.Exp(4.9 * 9.9) = 1.1684908531676829E+021
'            Math.Pow(4.9, 9.9) = 6.8067718210957060E+006
' Math.Exp(9.9 * Math.Log(4.9)) = 6.8067718210956985E+006
'</snippet1>
