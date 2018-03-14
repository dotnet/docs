'<snippet1>
Imports System.Collections.Generic

Public Class Temperature
    Implements IComparable(Of Temperature)

    ' Implement the generic CompareTo method with the Temperature class 
    ' as the type parameter. 
    '
    Public Overloads Function CompareTo(ByVal other As Temperature) As Integer _
        Implements IComparable(Of Temperature).CompareTo

        ' If other is not a valid object reference, this instance is greater.
        If other Is Nothing Then Return 1
        
        ' The temperature comparison depends on the comparison of the
        ' the underlying Double values. 
        Return m_value.CompareTo(other.m_value)
    End Function
    
    ' Define the is greater than operator.
    Public Shared Operator >  (operand1 As Temperature, operand2 As Temperature) As Boolean
       Return operand1.CompareTo(operand2) = 1
    End Operator
    
    ' Define the is less than operator.
    Public Shared Operator <  (operand1 As Temperature, operand2 As Temperature) As Boolean
       Return operand1.CompareTo(operand2) = -1
    End Operator

    ' Define the is greater than or equal to operator.
    Public Shared Operator >=  (operand1 As Temperature, operand2 As Temperature) As Boolean
       Return operand1.CompareTo(operand2) >= 0
    End Operator
    
    ' Define the is less than operator.
    Public Shared Operator <=  (operand1 As Temperature, operand2 As Temperature) As Boolean
       Return operand1.CompareTo(operand2) <= 0
    End Operator

    ' The underlying temperature value.
    Protected m_value As Double = 0.0

    Public ReadOnly Property Celsius() As Double
        Get
            Return m_value - 273.15
        End Get
    End Property

    Public Property Kelvin() As Double
        Get
            Return m_value
        End Get
        Set(ByVal Value As Double)
            If value < 0.0 Then 
                Throw New ArgumentException("Temperature cannot be less than absolute zero.")
            Else
                m_value = Value
            End If
        End Set
    End Property

    Public Sub New(ByVal kelvins As Double)
        Me.Kelvin = kelvins 
    End Sub
End Class

Public Class Example
    Public Shared Sub Main()
        Dim temps As New SortedList(Of Temperature, String)

        ' Add entries to the sorted list, out of order.
        temps.Add(New Temperature(2017.15), "Boiling point of Lead")
        temps.Add(New Temperature(0), "Absolute zero")
        temps.Add(New Temperature(273.15), "Freezing point of water")
        temps.Add(New Temperature(5100.15), "Boiling point of Carbon")
        temps.Add(New Temperature(373.15), "Boiling point of water")
        temps.Add(New Temperature(600.65), "Melting point of Lead")

        For Each kvp As KeyValuePair(Of Temperature, String) In temps
            Console.WriteLine("{0} is {1} degrees Celsius.", kvp.Value, kvp.Key.Celsius)
        Next
    End Sub
End Class

' The example displays the following output:
'      Absolute zero is -273.15 degrees Celsius.
'      Freezing point of water is 0 degrees Celsius.
'      Boiling point of water is 100 degrees Celsius.
'      Melting point of Lead is 327.5 degrees Celsius.
'      Boiling point of Lead is 1744 degrees Celsius.
'      Boiling point of Carbon is 4827 degrees Celsius.
'
'</snippet1>
