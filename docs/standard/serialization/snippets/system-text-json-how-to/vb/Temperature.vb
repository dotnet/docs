Imports System.Text.Json.Serialization

Namespace SystemTextJsonSamples
    '<Obsolete("Ignore", False)>
    '<JsonConverter(GetType(TemperatureConverter))>
    Public Structure Temperature
        Public Sub New(degrees As Integer, celsius As Boolean)
            Me.Degrees = degrees
            IsCelsius = celsius
        End Sub

        Public ReadOnly Property Degrees As Integer
        Public ReadOnly Property IsCelsius As Boolean
        Public ReadOnly Property IsFahrenheit As Boolean
            Get
                Return Not IsCelsius
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return $"{Degrees}{(If(IsCelsius, "C", "F"))}"
        End Function

        Public Shared Function Parse(input As String) As Temperature
            Dim degrees As Integer = Integer.Parse(input.Substring(0, input.Length - 1))
            Dim celsius As Boolean = input.Substring(input.Length - 1) = "C"

            Return New Temperature(degrees, celsius)
        End Function
    End Structure
End Namespace
