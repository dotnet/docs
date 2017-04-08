 '<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Globalization
Imports System.ComponentModel




NotInheritable Public Class CustomTimeSpanMinutesConverter
    Inherits ConfigurationConverterBase
    
    Friend Function ValidateType(ByVal value As Object, _
    ByVal expected As Type) As Boolean
        Dim result As Boolean

        If Not (value Is Nothing) _
        AndAlso value.ToString() <> expected.ToString() Then
            result = False
        Else
            result = True
        End If
        Return result

    End Function 'ValidateType
    
    
    '<Snippet2>
    Public Overrides Function CanConvertTo( _
    ByVal ctx As ITypeDescriptorContext, _
    ByVal type As Type) As Boolean
        Return (type.ToString() = GetType(String).ToString())

    End Function 'CanConvertTo
    
    '</Snippet2>
    '<Snippet3>
    Public Overrides Function CanConvertFrom( _
    ByVal ctx As ITypeDescriptorContext, _
    ByVal type As Type) As Boolean
        Return (type.ToString() = GetType(String).ToString())

    End Function 'CanConvertFrom
    
    '</Snippet3>
    '<Snippet4>
    Public Overrides Function ConvertTo( _
    ByVal ctx As ITypeDescriptorContext, _
    ByVal ci As CultureInfo, ByVal value As Object, _
    ByVal type As Type) As Object
        ValidateType(value, GetType(TimeSpan))

        Dim data As Long = _
        Fix(CType(value, TimeSpan).TotalMinutes)

        Return data.ToString(CultureInfo.InvariantCulture)

    End Function 'ConvertTo
    
    '</Snippet4>
    '<Snippet5>
    Public Overrides Function ConvertFrom( _
    ByVal ctx As ITypeDescriptorContext, _
    ByVal ci As CultureInfo, ByVal data As Object) As Object

        Dim min As Long = _
        Long.Parse(CStr(data), CultureInfo.InvariantCulture)

        Return TimeSpan.FromMinutes(System.Convert.ToDouble(min))

    End Function 'ConvertFrom
    '</Snippet5>

End Class 'CustomTimeSpanMinutesConverter 
'</Snippet1>