
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Globalization
Imports System.ComponentModel
Imports System.Collections.Specialized

'For Parsnip compilation sake.
NotInheritable Class CustomizedTimeSpanMinutesConverter
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



    Public Overrides Function CanConvertTo( _
    ByVal ctx As ITypeDescriptorContext, _
    ByVal type As Type) As Boolean
        Return (type.ToString() = GetType(String).ToString())

    End Function 'CanConvertTo


    Public Overrides Function CanConvertFrom( _
    ByVal ctx As ITypeDescriptorContext, _
    ByVal type As Type) As Boolean
        Return (type.ToString() = GetType(String).ToString())

    End Function 'CanConvertFrom


    Public Overrides Function ConvertTo( _
    ByVal ctx As ITypeDescriptorContext, _
    ByVal ci As CultureInfo, ByVal value As Object, _
    ByVal type As Type) As Object
        ValidateType(value, GetType(TimeSpan))

        Dim data As Long = _
        Fix(CType(value, TimeSpan).TotalMinutes)

        Return data.ToString(CultureInfo.InvariantCulture)

    End Function 'ConvertTo


    Public Overrides Function ConvertFrom( _
    ByVal ctx As ITypeDescriptorContext, _
    ByVal ci As CultureInfo, ByVal data As Object) As Object

        Dim min As Long = _
        Long.Parse(CStr(data), CultureInfo.InvariantCulture)

        Return TimeSpan.FromMinutes(System.Convert.ToDouble(min))

    End Function 'ConvertFrom


End Class 'CustomTimeSpanMinutesConverter 

'<Snippet1>
' Define a custom section.
NotInheritable Public Class CustomSection
    Inherits ConfigurationSection
    
    
    Public Sub New() 
    
    End Sub 'New
    
    
    '<Snippet0>
    
    <ConfigurationProperty("fileName", _
    DefaultValue:="   default.txt  "), _
    TypeConverter(GetType(WhiteSpaceTrimStringConverter))> _
    Public Property FileName() As String
        Get
            Return CStr(Me("fileName"))
        End Get
        Set(ByVal value As String)
            Me("fileName") = value
        End Set
    End Property
    '</Snippet0>

    '<Snippet2>
    
    <ConfigurationProperty("maxIdleTime"), _
    TypeConverter(GetType(CustomizedTimeSpanMinutesConverter))> _
    Public Property MaxIdleTime() As TimeSpan
        Get
            Return CType(Me("maxIdleTime"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            Me("maxIdleTime") = value
        End Set
    End Property
    '</Snippet2>
    '<Snippet3>
    
    <ConfigurationProperty("timeDelay", _
    DefaultValue:="infinite"), _
    TypeConverter(GetType(InfiniteTimeSpanConverter))> _
    Public Property TimeDelay() As TimeSpan
        Get
            Return CType(Me("timeDelay"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            Me("timeDelay") = Value
        End Set
    End Property
    '</Snippet3>
    '<Snippet4>
    
    <ConfigurationProperty("cdStr", _
    DefaultValue:="str0, str1", _
    IsRequired:=True), _
    TypeConverter(GetType(CommaDelimitedStringCollectionConverter))> _
    Public Property CdStr() As StringCollection
        Get
            Return CType(Me("cdStr"), StringCollection)
        End Get

        Set(ByVal value As StringCollection)
            Me("cdStr") = value
        End Set
    End Property
    '</Snippet4>
    
    '<Snippet5>
    
    Public Enum Permissions
        FullControl = 0
        Modify = 1
        ReadExecute = 2
        Read = 3
        Write = 4
        SpecialPermissions = 5
    End Enum 'Permissions
    
    
    <ConfigurationProperty("permission", _
    DefaultValue:=Permissions.Read)> _
    Public Property Permission() As Permissions
        Get
            Return CType(Me("permission"), Permissions)
        End Get

        Set(ByVal value As Permissions)
            Me("permission") = Value
        End Set
    End Property
    '</Snippet5>
    
    '<Snippet6>
    
    <ConfigurationProperty("maxUsers", _
    DefaultValue:="infinite"), _
    TypeConverter(GetType(InfiniteIntConverter))> _
    Public Property MaxUsers() As Integer
        Get
            Return Fix(Me("maxUsers"))
        End Get
        Set(ByVal value As Integer)
            Me("maxUsers") = Value
        End Set
    End Property
End Class 'CustomSection 
'</Snippet6>

'</Snippet1>