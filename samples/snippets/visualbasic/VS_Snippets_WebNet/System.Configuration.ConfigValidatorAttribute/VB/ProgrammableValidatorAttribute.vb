 ' File name: ProgrammableValidatorAttribute.cs
' Allowed snippet tags range: [31 - 40].
' <Snippet31>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration



' Show how to create a custom programmable 
' validator. That is a validator whose
' validation parameters can be passed when the
' validator is applied to a property.

Public Class ProgrammableValidator
    Inherits ConfigurationValidatorBase
    Private pmake As String
    Private pcolor As String
    Private pmaxMiles As Long
    Private pminYear As Integer
    
    
    Public Sub New(ByVal make As String, ByVal color As String, ByVal maxMiles As Long, ByVal minYear As Integer) 
        pmake = make
        pcolor = color
        pminYear = minYear
        pmaxMiles = maxMiles
    
    End Sub 'New
    
    
    Public Overrides Function CanValidate( _
    ByVal type As Type) As Boolean
        Return type Is GetType(Automobile)

    End Function 'CanValidate
    
    
    Public Overrides Sub Validate(ByVal value As Object) 
        
        Dim car As Automobile = CType(value, Automobile)
        
        Try
            
            ' Validate make
            If car.Make <> pmake Then
                Throw New ConfigurationErrorsException( _
                "I do not by cars made by " + car.Make)
            End If
            
            ' Validate color
            If car.Color <> pcolor Then
                Throw New ConfigurationErrorsException( _
                "My commute car must be " + pcolor)
            End If
            
            ' Validate year
            If car.Year < pminYear Then
                Throw New ConfigurationErrorsException( _
                "It's about time you get a new car.")
            End If
            
            ' Validate miles
            If car.Miles > pmaxMiles Then
                Throw New ConfigurationErrorsException( _
                "Don't take too long trips with that car.")
            End If
        
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    
    End Sub 'Validate
End Class 'ProgrammableValidator



Public Class ProgrammableValidatorAttribute
    Inherits ConfigurationValidatorAttribute
    Private pmake As String
    Private pcolor As String
    Private pminYear As Integer
    Private pmaxMiles As Long
    
    
    
    Public Property Make() As String 
        Get
            Return pmake
        End Get
        Set
            pmake = value
        End Set
    End Property 
    
    Public Property Color() As String 
        Get
            Return pcolor
        End Get
        Set
            pcolor = value
        End Set
    End Property 
    
    Public Property MinYear() As Integer 
        Get
            Return pminYear
        End Get
        Set
            pminYear = value
        End Set
    End Property
    
    Public Property MaxMiles() As Long 
        Get
            Return pmaxMiles
        End Get
        Set
            pmaxMiles = value
        End Set
    End Property
     
    Public Sub New(ByVal make As String, _
    ByVal color As String, ByVal miles As Long, _
    ByVal year As Integer)
        pmake = make
        pcolor = color
        pminYear = year
        pmaxMiles = miles

    End Sub 'New 
    

    Public Overrides ReadOnly Property ValidatorInstance() _
    As ConfigurationValidatorBase
        Get
            Return New ProgrammableValidator(pmake, _
            pcolor, pmaxMiles, pminYear)
        End Get
    End Property
End Class 'ProgrammableValidatorAttribute

' </Snippet31>