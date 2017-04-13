Imports System
Imports System.Globalization
Imports System.Windows.Controls

    Public Class AgeRangeRule
        Inherits ValidationRule

        ' Methods
        Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As CultureInfo) As ValidationResult
            Dim num1 As Integer = 0
            Try 
                If (CStr(value).Length > 0) Then
                    num1 = Integer.Parse(CStr(value))
                End If
            Catch exception1 As  Exception
                Return New ValidationResult(False, ("Illegal characters or " & exception1.Message))
            End Try
            If ((num1 < Me.Min) OrElse (num1 > Me.Max)) Then
                Return New ValidationResult(False, String.Concat(New Object() {"Please enter an age in the range: ", Me.Min, " - ", Me.Max, "."}))
            End If
            Return New ValidationResult(True, Nothing)
        End Function


        ' Properties
        Public Property Max As Integer
            Get
                Return Me._max
            End Get
            Set(ByVal value As Integer)
                Me._max = value
            End Set
        End Property

        Public Property Min As Integer
            Get
                Return Me._min
            End Get
            Set(ByVal value As Integer)
                Me._min = value
            End Set
        End Property


        ' Fields
        Private _max As Integer
        Private _min As Integer
    End Class


