' <Snippet1>
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

        ' <Snippet2>
        ' Initialize the _FileName property
        _FileName = New ConfigurationProperty( _
            "fileName", GetType(String), "default.txt")
        ' </Snippet2>

        ' <Snippet3>
        ' Initialize the _MaxUsers property
        _MaxUsers = New ConfigurationProperty( _
            "maxUsers", GetType(Long), 1000L, _
            ConfigurationPropertyOptions.None)
        ' </Snippet3>

        ' <Snippet4>
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
        ' </Snippet4>

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
' </Snippet1>

' More sample code
Public NotInheritable Class TestingCustomSection

    ' <Snippet30>
    ' Create a custom section.
    Shared Sub CreateSection()
        Try
            Dim customSection As CustomSection

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = _
                ConfigurationManager.OpenExeConfiguration( _
                ConfigurationUserLevel.None)

            ' Create the section entry  
            ' in the <configSections> and the 
            ' related target section in <configuration>.
            ' Since the config file already has "CustomSection",
            ' call this one "CustomSection2".
            If config.Sections("CustomSection") Is Nothing Then
                customSection = New CustomSection()
                config.Sections.Add("CustomSection", customSection)
                customSection.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)
            End If
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub
    ' </Snippet30>

    ' Get the property characteristics.
    ' Shows how to use an instance of ConfigurationProperty.
    Shared Sub GetPropertyCharacteristics()
        ' Initialize the _MaxIdleTime property
        Dim _MaxIdleTime As ConfigurationProperty
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

        ' <Snippet5>
        Dim converter As String = _MaxIdleTime.Converter.ToString()
        Console.WriteLine("MaxIdleTime coverter: {0}", converter)
        ' </Snippet5>

        ' <Snippet6>
        Dim defaultValue As String = _
            _MaxIdleTime.DefaultValue.ToString()
        Console.WriteLine( _
            "MaxIdleTime default value: {0}", defaultValue)
        ' </Snippet6>

        ' <Snippet7>
        Dim isKey As String = _
        _MaxIdleTime.IsKey.ToString()
        Console.WriteLine( _
        "MaxIdleTime is key: {0}", isKey)
        ' </Snippet7>

        ' <Snippet8>
        Dim isRequired As String = _MaxIdleTime.IsRequired.ToString()
        Console.WriteLine("MaxIdleTime is required: {0}", isRequired)
        ' </Snippet8>

        ' <Snippet9>
        Dim name As String = _MaxIdleTime.Name
        Console.WriteLine("MaxIdleTime name: {0}", name)
        ' </Snippet9>

        ' <Snippet10>
        Dim type As String = _MaxIdleTime.Type.ToString()
        Console.WriteLine("MaxIdleTime type: {0}", type)
        ' </Snippet10>

        ' <Snippet11>
        Dim description As String = _MaxIdleTime.Description
        Console.WriteLine("MaxIdleTime description: {0}", description)
        ' </Snippet11>

        ' <Snippet12>
        Dim validator As String = _MaxIdleTime.Validator.ToString()
        Console.WriteLine("MaxIdleTime validator: {0}", validator)
        ' </Snippet12>

    End Sub

    Public Overloads Shared Sub Main(ByVal args() As String)
        Console.WriteLine("[Create a custom section]")
        CreateSection()
        Console.WriteLine("[Get property characteristics]")
        GetPropertyCharacteristics()
        Console.ReadLine()
    End Sub
End Class
