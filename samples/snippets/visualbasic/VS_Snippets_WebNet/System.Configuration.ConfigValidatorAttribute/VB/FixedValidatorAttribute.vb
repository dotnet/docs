 ' File name: FixedValidatorAttribute.cs
' Allowed snippet tags range: [21 - 30].
' <Snippet21>
Imports System
Imports System.Collections.Generic
Imports System.Collections
Imports System.Text
Imports System.Configuration


' Show how to create a custom fixed 
' validator. That is a validator whose
' validation parameters are hard code in this
' type.

Public Class FixedValidator
    Inherits ConfigurationValidatorBase
    
    
    Public Overrides Function CanValidate( _
    ByVal type As Type) As Boolean
        Return type Is GetType(Automobile)

    End Function 'CanValidate
    
    
    Public Overrides Sub Validate(ByVal value _
    As Object)

        Dim make As New ArrayList()

        make.Add("Ferrari")
        make.Add("Porsche")
        make.Add("Lamborghini")

        Dim minYear As Integer = 2004
        Dim maxMiles As Long = 100
        Dim color As String = "red"

        Dim car As Automobile = CType(value, Automobile)


        Try
            If Not make.Contains(car.Make) Then
                Throw New ConfigurationErrorsException( _
                "My dream car is not made by " + car.Make)
            End If

            ' Make sure the year is valid 
            If car.Year < minYear Then
                Throw New ConfigurationErrorsException( _
                "My dream car cannot be older than " + _
                minYear.ToString())
            End If


            ' Make sure the car can still run on its own
            If car.Miles > maxMiles Then
                Throw New ConfigurationErrorsException( _
                "My dream car drive odometer cannot read more than " + _
                maxMiles.ToString() + " miles")
            End If


            ' Validate color
            If car.Color.ToLower() <> color Then
                Throw New ConfigurationErrorsException( _
                "My dream car can oly be " + color)
            End If

        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try

    End Sub 'Validate
End Class 'FixedValidator 

' </Snippet21>