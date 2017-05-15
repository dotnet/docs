 ' File name: AutomobileConverter.cs
' Allowed snippet tags range: [1 - 10].
' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.ComponentModel
Imports System.Globalization


' The AutomobileConverter converts between the Automobile
' object and its related configuration commute and
' dream attribute string values. 

NotInheritable Public Class AutomobileConverter
    Inherits ConfigurationConverterBase
    
    
    Friend Function ValidateType(ByVal value As Object, _
    ByVal expected As Type) As Boolean
        Dim result As Boolean

        If Not (value Is Nothing) _
        AndAlso value.GetType() IsNot expected Then
            result = False
        Else
            result = True
        End If
        Return result

    End Function 'ValidateType
    
    
    Public Overrides Function CanConvertTo(ByVal ctx _
    As ITypeDescriptorContext, ByVal type As Type) As Boolean
        Return type Is GetType(Automobile)

    End Function 'CanConvertTo
    
    
    
    Public Overrides Function CanConvertFrom(ByVal ctx _
    As ITypeDescriptorContext, ByVal type As Type) As Boolean
        Return type Is GetType(Automobile)

    End Function 'CanConvertFrom
    
    
    Public Overrides Function ConvertTo(ByVal ctx _
    As ITypeDescriptorContext, ByVal ci As CultureInfo, _
    ByVal value As Object, ByVal type As Type) As Object
        Dim data As String

        If ValidateType(value, GetType(Automobile)) Then
            Dim make As String = _
            CStr(CType(value, Automobile).Make)
            Dim color As String = _
            CStr(CType(value, Automobile).Color)
            Dim miles As String = _
            CStr(CType(value, Automobile).Miles.ToString())
            Dim year As String = _
            CStr(CType(value, Automobile).Year.ToString())

            data = "Make:" + make + " Color:" + color + _
            " Miles:" + miles + " Year:" + year

        Else
            data = "Invalid type"
        End If
        Return data

    End Function 'ConvertTo
    
    
    Public Overrides Function ConvertFrom(ByVal ctx _
    As ITypeDescriptorContext, ByVal ci As CultureInfo, _
    ByVal data As Object) As Object
        Dim selectedCar As New Automobile()

        Dim carInfo As String = CStr(data)

        Dim carSpecs As String() = carInfo.Split(New [Char]() {" "c})

        ' selectedCar.Make = carSpecs[0].ToString();
        ' selectedCar.Make = carSpecs[0].ToString();
        Dim make As String = _
        carSpecs(Fix(Automobile.specification.make)).ToString()
        Dim color As String = _
        carSpecs(Fix(Automobile.specification.color)).ToString()
        Dim miles As String = _
        carSpecs(Fix(Automobile.specification.miles)).ToString()
        Dim year As String = _
        carSpecs(Fix(Automobile.specification.year)).ToString()


        selectedCar.Make = _
        make.Substring(make.IndexOf(":") + 1)
        selectedCar.Color = _
        color.Substring(color.IndexOf(":") + 1)
        selectedCar.Miles = _
        Convert.ToInt32(miles.Substring(miles.IndexOf(":") + 1))
        selectedCar.Year = _
        Convert.ToInt32(year.Substring(year.IndexOf(":") + 1))

        Return selectedCar

    End Function 'ConvertFrom
End Class 'AutomobileConverter 

' </Snippet1>