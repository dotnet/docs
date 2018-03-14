'<snippet1>
' Example for the trigonometric Math.Sin( Double ) and Math.Cos( Double ) methods.
Imports System
Imports Microsoft.VisualBasic

Module SinCos
   
    Sub Main()
        Console.WriteLine( _
            "This example of trigonometric " & _
            "Math.Sin( double ) and Math.Cos( double )" & vbCrLf & _
            "generates the following output." & vbCrLf)
        Console.WriteLine( _
            "Convert selected values for X to radians " & vbCrLf & _
            "and evaluate these trigonometric identities:")
        Console.WriteLine( _
            "   sin^2(X) + cos^2(X) = 1" & vbCrLf & _ 
            "   sin(2 * X) = 2 * sin(X) * cos(X)")
        Console.WriteLine("   cos(2 * X) = cos^2(X) - sin^2(X)")
          
        UseSineCosine(15.0)
        UseSineCosine(30.0)
        UseSineCosine(45.0)
          
        Console.WriteLine( _
            vbCrLf & "Convert selected values for X and Y to radians" & _ 
            vbCrLf & "and evaluate these trigonometric identities:")
        Console.WriteLine("   sin(X + Y) = sin(X) * cos(Y) + cos(X) * sin(Y)")
        Console.WriteLine("   cos(X + Y) = cos(X) * cos(Y) - sin(X) * sin(Y)")
          
        UseTwoAngles(15.0, 30.0)
        UseTwoAngles(30.0, 45.0)
    End Sub 'Main
      
    ' Evaluate trigonometric identities with a given angle.
    Sub UseSineCosine(degrees As Double)

        Dim angle As Double = Math.PI * degrees / 180.0
        Dim sinAngle As Double = Math.Sin(angle)
        Dim cosAngle As Double = Math.Cos(angle)
          
        ' Evaluate sin^2(X) + cos^2(X) = 1.
        Console.WriteLine( _
            vbCrLf & "                           Math.Sin({0} deg) = {1:E16}" & _ 
            vbCrLf & "                           Math.Cos({0} deg) = {2:E16}", _
            degrees, Math.Sin(angle), Math.Cos(angle))
        Console.WriteLine( _
            "(Math.Sin({0} deg))^2 + (Math.Cos({0} deg))^2 = {1:E16}", _ 
            degrees, sinAngle * sinAngle + cosAngle * cosAngle)
          
        ' Evaluate sin(2 * X) = 2 * sin(X) * cos(X).
        Console.WriteLine( _
            "                           Math.Sin({0} deg) = {1:E16}", _ 
            2.0 * degrees, Math.Sin(2.0 * angle))
        Console.WriteLine( _
            "    2 * Math.Sin({0} deg) * Math.Cos({0} deg) = {1:E16}", _ 
            degrees, 2.0 * sinAngle * cosAngle)
          
        ' Evaluate cos(2 * X) = cos^2(X) - sin^2(X).
        Console.WriteLine( _
            "                           Math.Cos({0} deg) = {1:E16}", _ 
            2.0 * degrees, Math.Cos(2.0 * angle))
        Console.WriteLine( _
            "(Math.Cos({0} deg))^2 - (Math.Sin({0} deg))^2 = {1:E16}", _ 
            degrees, cosAngle * cosAngle - sinAngle * sinAngle)

    End Sub 'UseSineCosine
       
    ' Evaluate trigonometric identities that are functions of two angles.
    Sub UseTwoAngles(degreesX As Double, degreesY As Double)

        Dim angleX As Double = Math.PI * degreesX / 180.0
        Dim angleY As Double = Math.PI * degreesY / 180.0
          
        ' Evaluate sin(X + Y) = sin(X) * cos(Y) + cos(X) * sin(Y).
        Console.WriteLine( _
            vbCrLf & "        Math.Sin({0} deg) * Math.Cos({1} deg) +" & _ 
            vbCrLf & "        Math.Cos({0} deg) * Math.Sin({1} deg) = {2:E16}", _
            degreesX, degreesY, Math.Sin(angleX) * Math.Cos(angleY) + _
            Math.Cos(angleX) * Math.Sin(angleY))
        Console.WriteLine( _
            "                           Math.Sin({0} deg) = {1:E16}", _
            degreesX + degreesY, Math.Sin(angleX + angleY))
          
        ' Evaluate cos(X + Y) = cos(X) * cos(Y) - sin(X) * sin(Y).
        Console.WriteLine( _
            "        Math.Cos({0} deg) * Math.Cos({1} deg) -" & vbCrLf & _ 
            "        Math.Sin({0} deg) * Math.Sin({1} deg) = {2:E16}", _
            degreesX, degreesY, Math.Cos(angleX) * Math.Cos(angleY) - _
            Math.Sin(angleX) * Math.Sin(angleY))
        Console.WriteLine( _
            "                           Math.Cos({0} deg) = {1:E16}", _
            degreesX + degreesY, Math.Cos(angleX + angleY))

    End Sub 'UseTwoAngles
End Module 'SinCos

' This example of trigonometric Math.Sin( double ) and Math.Cos( double )
' generates the following output.
' 
' Convert selected values for X to radians
' and evaluate these trigonometric identities:
'    sin^2(X) + cos^2(X) = 1
'    sin(2 * X) = 2 * sin(X) * cos(X)
'    cos(2 * X) = cos^2(X) - sin^2(X)
' 
'                            Math.Sin(15 deg) = 2.5881904510252074E-001
'                            Math.Cos(15 deg) = 9.6592582628906831E-001
' (Math.Sin(15 deg))^2 + (Math.Cos(15 deg))^2 = 1.0000000000000000E+000
'                            Math.Sin(30 deg) = 4.9999999999999994E-001
'     2 * Math.Sin(15 deg) * Math.Cos(15 deg) = 4.9999999999999994E-001
'                            Math.Cos(30 deg) = 8.6602540378443871E-001
' (Math.Cos(15 deg))^2 - (Math.Sin(15 deg))^2 = 8.6602540378443871E-001
' 
'                            Math.Sin(30 deg) = 4.9999999999999994E-001
'                            Math.Cos(30 deg) = 8.6602540378443871E-001
' (Math.Sin(30 deg))^2 + (Math.Cos(30 deg))^2 = 1.0000000000000000E+000
'                            Math.Sin(60 deg) = 8.6602540378443860E-001
'     2 * Math.Sin(30 deg) * Math.Cos(30 deg) = 8.6602540378443860E-001
'                            Math.Cos(60 deg) = 5.0000000000000011E-001
' (Math.Cos(30 deg))^2 - (Math.Sin(30 deg))^2 = 5.0000000000000022E-001
' 
'                            Math.Sin(45 deg) = 7.0710678118654746E-001
'                            Math.Cos(45 deg) = 7.0710678118654757E-001
' (Math.Sin(45 deg))^2 + (Math.Cos(45 deg))^2 = 1.0000000000000000E+000
'                            Math.Sin(90 deg) = 1.0000000000000000E+000
'     2 * Math.Sin(45 deg) * Math.Cos(45 deg) = 1.0000000000000000E+000
'                            Math.Cos(90 deg) = 6.1230317691118863E-017
' (Math.Cos(45 deg))^2 - (Math.Sin(45 deg))^2 = 2.2204460492503131E-016
' 
' Convert selected values for X and Y to radians
' and evaluate these trigonometric identities:
'    sin(X + Y) = sin(X) * cos(Y) + cos(X) * sin(Y)
'    cos(X + Y) = cos(X) * cos(Y) - sin(X) * sin(Y)
' 
'         Math.Sin(15 deg) * Math.Cos(30 deg) +
'         Math.Cos(15 deg) * Math.Sin(30 deg) = 7.0710678118654746E-001
'                            Math.Sin(45 deg) = 7.0710678118654746E-001
'         Math.Cos(15 deg) * Math.Cos(30 deg) -
'         Math.Sin(15 deg) * Math.Sin(30 deg) = 7.0710678118654757E-001
'                            Math.Cos(45 deg) = 7.0710678118654757E-001
' 
'         Math.Sin(30 deg) * Math.Cos(45 deg) +
'         Math.Cos(30 deg) * Math.Sin(45 deg) = 9.6592582628906831E-001
'                            Math.Sin(75 deg) = 9.6592582628906820E-001
'         Math.Cos(30 deg) * Math.Cos(45 deg) -
'         Math.Sin(30 deg) * Math.Sin(45 deg) = 2.5881904510252085E-001
'                            Math.Cos(75 deg) = 2.5881904510252096E-001
'</snippet1>