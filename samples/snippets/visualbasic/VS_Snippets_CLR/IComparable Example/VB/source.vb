' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections

Public Class Temperature
    Implements IComparable
    ' The temperature value
    Protected temperatureF As Double

    Public Overloads Function CompareTo(ByVal obj As Object) As Integer _
        Implements IComparable.CompareTo
        
        If obj Is Nothing Then Return 1

        Dim otherTemperature As Temperature = TryCast(obj, Temperature)
        If otherTemperature IsNot Nothing Then
            Return Me.temperatureF.CompareTo(otherTemperature.temperatureF)
        Else
           Throw New ArgumentException("Object is not a Temperature")
        End If   
    End Function

    Public Property Fahrenheit() As Double
        Get
            Return temperatureF
        End Get
        Set(ByVal Value As Double)
            Me.temperatureF = Value
        End Set
    End Property

    Public Property Celsius() As Double
        Get
            Return (temperatureF - 32) * (5/9)
        End Get
        Set(ByVal Value As Double)
            Me.temperatureF = (Value * 9/5) + 32
        End Set
    End Property
End Class

Public Module CompareTemperatures
   Public Sub Main()
      Dim temperatures As New ArrayList
      ' Initialize random number generator.
      Dim rnd As New Random()
      
      ' Generate 10 temperatures between 0 and 100 randomly.
      For ctr As Integer = 1 To 10
         Dim degrees As Integer = rnd.Next(0, 100)
         Dim temp As New Temperature
         temp.Fahrenheit = degrees
         temperatures.Add(temp)   
      Next

      ' Sort ArrayList.
      temperatures.Sort()
      
      For Each temp As Temperature In temperatures
         Console.WriteLine(temp.Fahrenheit)
      Next      
   End Sub
End Module
' The example displays the following output to the console (individual
' values may vary because they are randomly generated):
'       2
'       7
'       16
'       17
'       31
'       37
'       58
'       66
'       72
'       95
' </Snippet1>
