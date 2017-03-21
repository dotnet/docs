Imports System
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel

' Define a custom section.
' Shows how to use the ConfigurationProperty
' class when defining a custom section.
Public NotInheritable Class CustomSection
    Inherits ConfigurationSection

    ' The collection (property bag) that contains 
    ' the section properties.
    Private Shared _Properties As ConfigurationPropertyCollection

    ' The FileName property.
    Private Shared _FileName As ConfigurationProperty

    ' The Alias property.
    Private Shared _Alias As ConfigurationProperty

    ' The MasUsers property.
    Private Shared _MaxUsers As ConfigurationProperty

    ' The MaxIdleTime property.
    Private Shared _MaxIdleTime As ConfigurationProperty

    ' CustomSection constructor.
    Shared Sub New()

        ' Initialize the _FileName property
        _FileName = New ConfigurationProperty( _
            "fileName", GetType(String), "default.txt")

        ' Initialize the _MaxUsers property
        _MaxUsers = New ConfigurationProperty( _
            "maxUsers", GetType(Long), 1000L, _
            ConfigurationPropertyOptions.None)

        ' Initialize the _MaxIdleTime property
        Dim minTime As TimeSpan = TimeSpan.FromSeconds(30)
        Dim maxTime As TimeSpan = TimeSpan.FromMinutes(5)
        Dim _TimeSpanValidator = _
            New TimeSpanValidator(minTime, maxTime, False)

        _MaxIdleTime = New ConfigurationProperty( _
            "maxIdleTime", GetType(TimeSpan), _
            TimeSpan.FromMinutes(5), _
            TypeDescriptor.GetConverter(GetType(TimeSpan)), _
            _TimeSpanValidator, _
            ConfigurationPropertyOptions.IsRequired, _
            "[Description:This is the max idle time.]")

        ' Initialize the _Alias property
        _Alias = New ConfigurationProperty( _
            "alias", GetType(String), "alias.txt")

        ' Property collection initialization.
        ' The collection (property bag) that contains 
        ' the properties is declared as:
        ' ConfigurationPropertyCollection _Properties;
        _Properties = New ConfigurationPropertyCollection()
        _Properties.Add(_FileName)
        _Properties.Add(_Alias)
        _Properties.Add(_MaxUsers)
        _Properties.Add(_MaxIdleTime)

    End Sub

    ' Return the initialized property bag
    ' for the configuration element.
    Protected Overrides ReadOnly Property Properties() _
    As ConfigurationPropertyCollection
        Get
            Return _Properties
        End Get
    End Property

    <StringValidator(InvalidCharacters:= _
    " ~!@#$%^&*()[]{}/;'""|\", MinLength:=1, _
    MaxLength:=60)> _
    Public Property FileName() As String
        Get
            Return CStr(Me("fileName"))
        End Get
        Set(ByVal value As String)
            Me("fileName") = value
        End Set
    End Property

    <StringValidator(InvalidCharacters:= _
    " ~!@#$%^&*()[]{}/;'""|\", MinLength:=1, _
    MaxLength:=60)> _
    Public Property [Alias]() As String
        Get
            Return CStr(Me("alias"))
        End Get
        Set(ByVal value As String)
            Me("alias") = value
        End Set
    End Property

    <LongValidator(MinValue:=1, _
    MaxValue:=1000000, ExcludeRange:=False)> _
    Public Property MaxUsers() As Long
        Get
            Return Fix(Me("maxUsers"))
        End Get
        Set(ByVal value As Long)
            Me("maxUsers") = value
        End Set
    End Property

    Public Property MaxIdleTime() As TimeSpan
        Get
            Return CType(Me("maxIdleTime"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            Me("maxIdleTime") = value
        End Set
    End Property
End Class