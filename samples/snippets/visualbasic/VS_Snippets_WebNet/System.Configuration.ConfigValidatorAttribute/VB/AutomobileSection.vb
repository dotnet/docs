 ' File name: AutomobileSection.cs
' Allowed snippet tags range: [11 - 20].
' <Snippet11>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.ComponentModel
Imports System.Globalization


' Define the distinctive 
' charecteristics of a car.

NotInheritable Public Class Automobile
    
    Public Enum specification
        make = 0
        color = 1
        miles = 2
        year = 3
        picture = 4
    End Enum 'specification

    Public Make As String
    Public Color As String
    Public Year As Integer
    Public Miles As Long
    Public Picture As String
End Class 'Automobile

' Define a custom section to select a car.
' This section contains two properties one
' to define a commute car the other 
' to define a dream car.
' This generates a configuration section such as:
' <Cars commute="Make:AlfaRomeo Color:Blue Miles:10000 Year:2002"
' dream="Make:Ferrari Color:Red Miles:10 Year:2005" />

NotInheritable Public Class SelectCar
    Inherits ConfigurationSection
    ' Define your commute car.
    ' The ProgrammableValidatorAttribute allows you to define the 
    ' chracteristics of your commute car by changing
    ' the values you pass to the next.
    ' See the ProgrammableValidatorAttribute for details.
    
    <ProgrammableValidator("AlfaRomeo", "Blue", 10000, 2002), _
    TypeConverter(GetType(AutomobileConverter)), _
    ConfigurationProperty("commute", _
    DefaultValue:="Make:AlfaRomeo Color:Blue Miles:10000 Year:2002")> _
    Public Property Commute() As Automobile

        ' The AutomobileConverter converts between the Automobile
        ' object and its related configuration commute attribute 
        ' string value. 
        ' Refer to AutomobileConverter for details.

        ' Define the name of the configuration attribute to associate
        ' with this property. Enter the default values.
        ' Remember these default values must reflect the parameters
        ' you entered in the ProgrammableValidator above.
        Get
            Return CType(Me("commute"), Automobile)
        End Get
        Set(ByVal value As Automobile)
            Me("commute") = value
        End Set
    End Property
    
    ' Apply the FixedValidatorAttribute. Here your choice 
    ' (dream) is predetermined by the values contained in the
    ' FixedValidatorAttribute. Being a dream, you would think 
    ' otherwise but that's not the case.
    ' See the FixedValidatorAttribute to choose your dream.
    
    <ConfigurationValidatorAttribute(GetType(FixedValidator)), _
    TypeConverter(GetType(AutomobileConverter)), _
    ConfigurationProperty("dream", _
    DefaultValue:="Make:Ferrari Color:Red Miles:10 Year:2005")> _
    Public Property Dream() As Automobile

        ' The AutomobileConverter converts between the Automobile
        ' object and its related configuration dream attribute 
        ' string value. 
        ' Refer to AutomobileConverter for details.

        Get
            Return CType(Me("dream"), Automobile)
        End Get
        Set(ByVal value As Automobile)
            Me("dream") = value
        End Set
    End Property
     
    
    Public Sub New() 
    
    End Sub 'New
End Class 'SelectCar ' Here you put your 
' initializations, if necessary.

' </Snippet11>