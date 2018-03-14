'<snippet1>
' Example for the hyperbolic Math.Sinh( Double ) and Math.Cosh( Double ) methods.
Imports System
Imports Microsoft.VisualBasic

Module SinhCosh
   
    Sub Main()
        Console.WriteLine( _
            "This example of hyperbolic " & _
            "Math.Sinh( Double ) and Math.Cosh( Double )" & vbCrLf & _
            "generates the following output." & vbCrLf)
        Console.WriteLine( _
            "Evaluate these hyperbolic identities " & _
            "with selected values for X:")
        Console.WriteLine( _
            "   cosh^2(X) - sinh^2(X) = 1" & vbCrLf & _
            "   sinh(2 * X) = 2 * sinh(X) * cosh(X)")
        Console.WriteLine("   cosh(2 * X) = cosh^2(X) + sinh^2(X)")
          
        UseSinhCosh(0.1)
        UseSinhCosh(1.2)
        UseSinhCosh(4.9)
          
        Console.WriteLine( _
            vbCrLf & "Evaluate these hyperbolic " & _
            "identities with selected values for X and Y:")
        Console.WriteLine( _
            "   sinh(X + Y) = sinh(X) * cosh(Y) + cosh(X) * sinh(Y)")
        Console.WriteLine( _
            "   cosh(X + Y) = cosh(X) * cosh(Y) + sinh(X) * sinh(Y)")

        UseTwoArgs(0.1, 1.2)
        UseTwoArgs(1.2, 4.9)
    End Sub 'Main
      
    ' Evaluate hyperbolic identities with a given argument.
    Sub UseSinhCosh(arg As Double)
        Dim sinhArg As Double = Math.Sinh(arg)
        Dim coshArg As Double = Math.Cosh(arg)
          
        ' Evaluate cosh^2(X) - sinh^2(X) = 1.
        Console.WriteLine( _
            vbCrLf & "                         Math.Sinh({0}) = {1:E16}" + _
            vbCrLf & "                         Math.Cosh({0}) = {2:E16}", _
            arg, Math.Sinh(arg), Math.Cosh(arg))
        Console.WriteLine( _
            "(Math.Cosh({0}))^2 - (Math.Sinh({0}))^2 = {1:E16}", _
            arg, coshArg * coshArg - sinhArg * sinhArg)
          
        ' Evaluate sinh(2 * X) = 2 * sinh(X) * cosh(X).
        Console.WriteLine( _
            "                         Math.Sinh({0}) = {1:E16}", _
            2.0 * arg, Math.Sinh((2.0 * arg)))
        Console.WriteLine( _
            "    2 * Math.Sinh({0}) * Math.Cosh({0}) = {1:E16}", _
            arg, 2.0 * sinhArg * coshArg)
          
        ' Evaluate cosh(2 * X) = cosh^2(X) + sinh^2(X).
        Console.WriteLine( _
            "                         Math.Cosh({0}) = {1:E16}", _
            2.0 * arg, Math.Cosh((2.0 * arg)))
        Console.WriteLine( _
            "(Math.Cosh({0}))^2 + (Math.Sinh({0}))^2 = {1:E16}", _
            arg, coshArg * coshArg + sinhArg * sinhArg)

    End Sub 'UseSinhCosh
       
    ' Evaluate hyperbolic identities that are functions of two arguments.
    Sub UseTwoArgs(argX As Double, argY As Double)

        ' Evaluate sinh(X + Y) = sinh(X) * cosh(Y) + cosh(X) * sinh(Y).
        Console.WriteLine( _
            vbCrLf & "        Math.Sinh({0}) * Math.Cosh({1}) +" + _
            vbCrLf & "        Math.Cosh({0}) * Math.Sinh({1}) = {2:E16}", _
            argX, argY, Math.Sinh(argX) * Math.Cosh(argY) + _
            Math.Cosh(argX) * Math.Sinh(argY))
        Console.WriteLine( _
            "                         Math.Sinh({0}) = {1:E16}", _
            argX + argY, Math.Sinh((argX + argY)))
          
        ' Evaluate cosh(X + Y) = cosh(X) * cosh(Y) + sinh(X) * sinh(Y).
        Console.WriteLine( _
            "        Math.Cosh({0}) * Math.Cosh({1}) +" + _
            vbCrLf & "        Math.Sinh({0}) * Math.Sinh({1}) = {2:E16}", _
            argX, argY, Math.Cosh(argX) * Math.Cosh(argY) + _
            Math.Sinh(argX) * Math.Sinh(argY))
        Console.WriteLine( _
            "                         Math.Cosh({0}) = {1:E16}", _
            argX + argY, Math.Cosh((argX + argY)))

    End Sub 'UseTwoArgs
End Module 'SinhCosh

' This example of hyperbolic Math.Sinh( Double ) and Math.Cosh( Double )
' generates the following output.
' 
' Evaluate these hyperbolic identities with selected values for X:
'    cosh^2(X) - sinh^2(X) = 1
'    sinh(2 * X) = 2 * sinh(X) * cosh(X)
'    cosh(2 * X) = cosh^2(X) + sinh^2(X)
' 
'                          Math.Sinh(0.1) = 1.0016675001984403E-001
'                          Math.Cosh(0.1) = 1.0050041680558035E+000
' (Math.Cosh(0.1))^2 - (Math.Sinh(0.1))^2 = 9.9999999999999989E-001
'                          Math.Sinh(0.2) = 2.0133600254109399E-001
'     2 * Math.Sinh(0.1) * Math.Cosh(0.1) = 2.0133600254109396E-001
'                          Math.Cosh(0.2) = 1.0200667556190759E+000
' (Math.Cosh(0.1))^2 + (Math.Sinh(0.1))^2 = 1.0200667556190757E+000
' 
'                          Math.Sinh(1.2) = 1.5094613554121725E+000
'                          Math.Cosh(1.2) = 1.8106555673243747E+000
' (Math.Cosh(1.2))^2 - (Math.Sinh(1.2))^2 = 1.0000000000000000E+000
'                          Math.Sinh(2.4) = 5.4662292136760939E+000
'     2 * Math.Sinh(1.2) * Math.Cosh(1.2) = 5.4662292136760939E+000
'                          Math.Cosh(2.4) = 5.5569471669655064E+000
' (Math.Cosh(1.2))^2 + (Math.Sinh(1.2))^2 = 5.5569471669655064E+000
' 
'                          Math.Sinh(4.9) = 6.7141166550932297E+001
'                          Math.Cosh(4.9) = 6.7148613134003227E+001
' (Math.Cosh(4.9))^2 - (Math.Sinh(4.9))^2 = 1.0000000000000000E+000
'                          Math.Sinh(9.8) = 9.0168724361884615E+003
'     2 * Math.Sinh(4.9) * Math.Cosh(4.9) = 9.0168724361884615E+003
'                          Math.Cosh(9.8) = 9.0168724916400624E+003
' (Math.Cosh(4.9))^2 + (Math.Sinh(4.9))^2 = 9.0168724916400606E+003
' 
' Evaluate these hyperbolic identities with selected values for X and Y:
'    sinh(X + Y) = sinh(X) * cosh(Y) + cosh(X) * sinh(Y)
'    cosh(X + Y) = cosh(X) * cosh(Y) + sinh(X) * sinh(Y)
' 
'         Math.Sinh(0.1) * Math.Cosh(1.2) +
'         Math.Cosh(0.1) * Math.Sinh(1.2) = 1.6983824372926155E+000
'                          Math.Sinh(1.3) = 1.6983824372926160E+000
'         Math.Cosh(0.1) * Math.Cosh(1.2) +
'         Math.Sinh(0.1) * Math.Sinh(1.2) = 1.9709142303266281E+000
'                          Math.Cosh(1.3) = 1.9709142303266285E+000
' 
'         Math.Sinh(1.2) * Math.Cosh(4.9) +
'         Math.Cosh(1.2) * Math.Sinh(4.9) = 2.2292776360739879E+002
'                          Math.Sinh(6.1) = 2.2292776360739885E+002
'         Math.Cosh(1.2) * Math.Cosh(4.9) +
'         Math.Sinh(1.2) * Math.Sinh(4.9) = 2.2293000647511826E+002
'                          Math.Cosh(6.1) = 2.2293000647511832E+002
'</snippet1>
