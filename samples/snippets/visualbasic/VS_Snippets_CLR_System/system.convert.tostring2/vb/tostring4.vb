' <Snippet25>
Option Strict On

Imports System.Globalization

Public Class DummyProvider : Implements IFormatProvider
    ' Normally, GetFormat returns an object of the requested type
    ' (usually itself) if it is able; otherwise, it returns Nothing. 
    Public Function GetFormat(argType As Type) As Object _
        Implements IFormatProvider.GetFormat

        ' Display the type of argType and return Nothing.
        Console.Write( "{0,-25}", argType.Name)
        Return Nothing
    End Function 
End Class

Public Module Example
    Public Sub Main()
        ' Create an instance of the IFormatProvider.
        Dim provider  As New DummyProvider()

        ' Values to convert using DummyProvider
        Dim int32A As Integer  = -252645135   
        Dim doubleA As Double   = 61680.3855
        Dim objDouble As Object   = CObj(-98765.4321)
        Dim dayTimeA As DateTime = #9/11/2009 13:45#
        Dim boolA As Boolean = True
        Dim stringA As String = "Qwerty"
        Dim charA As Char = "$"c
        Dim tSpanA As New TimeSpan(0, 18, 0)
        Dim objOther As Object = provider

        Dim objects() As Object = { int32A, doubleA, objDouble, dayTimeA, _
                                    boolA, stringA, charA, tSpanA, objOther }
        
        ' Call Convert.ToString(Object, provider) method for each value.
        For Each value As Object In objects 
           Console.WriteLine("{0,-20}  -->  {1,20}", _
                             value, Convert.ToString(value, provider))    
        Next 
    End Sub
End Module
' The example displays the following output:
'    NumberFormatInfo         -252645135            -->            -252645135
'    NumberFormatInfo         61680.3855            -->            61680.3855
'    NumberFormatInfo         -98765.4321           -->           -98765.4321
'    DateTimeFormatInfo       9/11/2009 1:45:00 PM  -->  9/11/2009 1:45:00 PM
'    True                  -->                  True
'    Qwerty                -->                Qwerty
'    $                     -->                     $
'    00:18:00              -->              00:18:00
'    DummyProvider         -->         DummyProvider
' </Snippet25>
