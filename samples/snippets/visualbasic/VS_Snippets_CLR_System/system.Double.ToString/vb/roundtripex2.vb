﻿' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example
    Public Sub Main()
        Console.WriteLine("Attempting to round-trip a Double with 'R':")
        Dim initialValue As Double = 0.6822871999174
        Dim valueString As String = initialValue.ToString("R")
        Dim roundTripped As Double = Double.Parse(valueString)
        Console.WriteLine("{0:R} = {1:R}: {2}",
                          initialValue, roundTripped, initialValue.Equals(roundTripped))
        Console.WriteLine()

        Console.WriteLine("Attempting to round-trip a Double with 'G17':")
        Dim valueString17 As String = initialValue.ToString("G17")
        Dim roundTripped17 As Double = Double.Parse(valueString17)
        Console.WriteLine("{0:R} = {1:R}: {2}",
                          initialValue, roundTripped17, initialValue.Equals(roundTripped17))
    End Sub
End Module
' If compiled to an application that targets anycpu or x64 and run on an x64 system,
' the example displays the following output:
'       Attempting to round-trip a Double with 'R':
'       0.6822871999174 = 0.68228719991740006: False
'
'       Attempting to round-trip a Double with 'G17':
'       0.6822871999174 = 0.6822871999174: True
' </Snippet6>

