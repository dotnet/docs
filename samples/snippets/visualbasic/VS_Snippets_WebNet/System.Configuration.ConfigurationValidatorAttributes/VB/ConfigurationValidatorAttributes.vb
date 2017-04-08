
Imports System
Imports System.Configuration


'<Snippet1>

Public Class SampleSection
    Inherits ConfigurationSection

    Public Sub New()
    End Sub 'New


    '<Snippet2>

    <ConfigurationProperty("fileName", _
    DefaultValue:="default.txt", _
    IsRequired:=True, _
    IsKey:=False), _
    StringValidator( _
    InvalidCharacters:=" ~!@#$%^&*()[]{}/;'""|\", _
    MinLength:=1, _
    MaxLength:=60)> _
    Public Property FileName() As String
        Get
            Return CStr(Me("fileName"))
        End Get
        Set(ByVal value As String)
            Me("fileName") = value
        End Set
    End Property
    '</Snippet2>

    '<Snippet3>
    <ConfigurationProperty("alias", _
    DefaultValue:="anotherName.txt", _
    IsRequired:=True, _
    IsKey:=False), _
    StringValidator()> _
    Public Property [Alias]() As String
        Get
            Return CStr(Me("alias"))
        End Get
        Set(ByVal value As String)
            Me("alias") = value
        End Set
    End Property
    '</Snippet3>

    '<Snippet4>
    <ConfigurationProperty("alias2", _
    DefaultValue:="alias.txt", _
    IsRequired:=True, _
    IsKey:=False), _
    RegexStringValidator("\w+\S*")> _
    Public Property Alias2() As String
        Get
            Return CStr(Me("alias2"))
        End Get
        Set(ByVal value As String)
            Me("alias2") = value
        End Set
    End Property
    '</Snippet4>

    '<Snippet5> 
    <ConfigurationProperty("maxSize", _
    DefaultValue:=1000, _
    IsRequired:=True), _
    IntegerValidator()> _
    Public Property MaxSize() As Integer
        Get
            Return Fix(Me("maxSize"))
        End Get
        Set(ByVal value As Integer)
            Me("maxSize") = value
        End Set
    End Property
    '</Snippet5>

    '<Snippet6> 
    <ConfigurationProperty("maxAttempts", _
    DefaultValue:=101, _
    IsRequired:=True), _
    IntegerValidator(MinValue:=1, _
    MaxValue:=100, _
    ExcludeRange:=True)> _
    Public Property MaxAttempts() As Integer
        Get
            Return Fix(Me("maxAttempts"))
        End Get
        Set(ByVal value As Integer)
            Me("maxAttempts") = value
        End Set
    End Property
    '</Snippet6>

    '<Snippet7> 
    <ConfigurationProperty("maxUsers", _
    DefaultValue:=10000, _
    IsRequired:=False), _
    LongValidator(MinValue:=1, _
    MaxValue:=10000000, _
    ExcludeRange:=False)> _
    Public Property MaxUsers() As Long
        Get
            Return Fix(Me("maxUsers"))
        End Get
        Set(ByVal value As Long)
            Me("maxUsers") = value
        End Set
    End Property
    '</Snippet7>

    '<Snippet8> 
    <ConfigurationProperty("maxIdleTime", _
    DefaultValue:="0:10:0", _
    IsRequired:=False), _
    TimeSpanValidator(MinValueString:="0:0:30", _
    MaxValueString:="5:00:0", _
    ExcludeRange:=False)> _
    Public Property MaxIdleTime() As TimeSpan
        Get
            Return CType(Me("maxIdleTime"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            Me("maxIdleTime") = value
        End Set
    End Property
    '</Snippet8>

    '<Snippet9> 
    <ConfigurationProperty("lastAccess", _
    DefaultValue:="00:00:00", _
    IsRequired:=False), _
    TimeSpanValidator()> _
    Public Property LastAccess() As TimeSpan
        Get
            Return CType(Me("lastAccess"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            Me("lastAccess") = value
        End Set
    End Property
    '</Snippet9>

    Public Shared Sub DisplayTimeSpanAbsoluteRange()
        '<Snippet10>
        Dim absoluteMax As String = _
        TimeSpanValidatorAttribute.TimeSpanMaxValue
        '</Snippet10>
        '<Snippet11>
        Dim absoluteMin As String = _
        TimeSpanValidatorAttribute.TimeSpanMinValue
        '</Snippet11>

        Console.WriteLine("  Absolute max: {0}", absoluteMax)
        Console.WriteLine("  Absolute max: {0}", absoluteMin)
    End Sub 'DisplayTimeSpanAbsoluteRange


    Public Shared Sub TimeStampValidatorInstance()
        '<Snippet12>
        Dim valBase As ConfigurationValidatorBase
        Dim tsValAttr As TimeSpanValidatorAttribute
        tsValAttr = New TimeSpanValidatorAttribute()

        Dim goodValue As TimeSpan = TimeSpan.FromMinutes(10)
        Dim badValue As Int16 = 10

        Try
            valBase = tsValAttr.ValidatorInstance
            valBase.Validate(goodValue)
            ' valBase.Validate(badValue);
        Catch e As ArgumentException
            ' Display error message.
            Dim msg As String = e.ToString()

#If DEBUG Then
            Console.WriteLine(msg)
#End If
        End Try '
        '</Snippet12>

    End Sub 'TimeStampValidatorInstance

    Public Shared Sub IntegerValidatorInstance()
        '<Snippet13>
        Dim valBase As ConfigurationValidatorBase
        Dim intValAttr As IntegerValidatorAttribute
        intValAttr = New IntegerValidatorAttribute()

        Dim badValue As Long = 10
        Dim goodValue As Integer = 10

        Try
            valBase = intValAttr.ValidatorInstance
            valBase.Validate(goodValue)
            ' valBase.Validate(badValue);
        Catch e As ArgumentException
            ' Display error message.
            Dim msg As String = e.ToString()
#If DEBUG Then
            Console.WriteLine(msg)
#End If
        End Try '
        '</Snippet13>

    End Sub 'IntegerValidatorInstance


    Public Shared Sub StringValidatorInstance()
        '<Snippet14>
        Dim valBase As ConfigurationValidatorBase
        Dim strValAttr As New StringValidatorAttribute()

        Dim badValue As Long = 10
        Dim goodValue As String = "10"

        Try
            valBase = strValAttr.ValidatorInstance
            valBase.Validate(goodValue)
            ' valBase.Validate(badValue);
        Catch e As ArgumentException
            ' Display error message.
            Dim msg As String = e.ToString()

#If DEBUG Then
            Console.WriteLine(msg)
#End If
        End Try '
        '</Snippet14>

    End Sub 'StringValidatorInstance


    Public Shared Sub RegexStringValidatorInstance()
        '<Snippet15>

        '<Snippet16>
        Dim valBase As _
        ConfigurationValidatorBase

        Dim rstrValAttr As _
        New RegexStringValidatorAttribute("\w+\S*")

        ' Get the regular expression string.
        Dim regex As String = _
        rstrValAttr.Regex
        Console.WriteLine( _
        "Regular expression: {0}", regex)
        '</Snippet16>

        Dim badValue As _
        String = "&%$bbb"
        Dim goodValue As _
        String = "filename.txt"

        Try
            valBase = rstrValAttr.ValidatorInstance
            valBase.Validate(goodValue)
            ' valBase.Validate(badValue);
        Catch e As ArgumentException
            ' Display error message.
            Dim msg As String = e.ToString()

#If DEBUG Then
            Console.WriteLine(msg)
#End If

        End Try '
        '</Snippet15>

    End Sub 'RegexStringValidatorInstance
End Class 'SampleSection 
'</Snippet1>

Class TestingSampleConfiguration


    Shared Sub ShowDefaults()
        Dim customSection As SampleSection = ConfigurationManager.GetSection("custom")

        If customSection Is Nothing Then
            Console.WriteLine("Failed to load SsmpleSection.")
        Else
            Console.WriteLine("Defaults:")
            Console.WriteLine("  File Name: {0}", customSection.FileName)
            Console.WriteLine("  Max Users: {0}", customSection.MaxUsers)
            Console.WriteLine("  Max Idle Time: {0}", customSection.MaxIdleTime)
            Console.WriteLine("  Last access: {0}", customSection.LastAccess)
            Console.WriteLine("  Alias 1: {0}", customSection.Alias)
            Console.WriteLine("  Alias 2: {0}", customSection.Alias2)
        End If
    End Sub 'ShowDefaults



    Shared Sub ShowSectionInfo()
        Dim customSection As SampleSection = ConfigurationManager.GetSection("custom")

        If customSection Is Nothing Then
            Console.WriteLine("Failed to load SampleSection.")
        Else
            Console.WriteLine("Section Information:")

            Console.WriteLine("  Name: {0}", customSection.SectionInformation.Name)

            Console.WriteLine("  SectionName: {0}", customSection.SectionInformation.SectionName)

            Console.WriteLine("  Type: {0}", customSection.SectionInformation.Type)

            Console.WriteLine("  AllowDefinition: {0}", customSection.SectionInformation.AllowDefinition)

            Console.WriteLine("  AllowExeDefinition: {0}", customSection.SectionInformation.AllowExeDefinition)
        End If
    End Sub 'ShowSectionInfo


    Public Overloads Shared Sub Main(ByVal args() As String)
        Console.WriteLine("[Current Defaults]")
        ShowDefaults()
        Console.WriteLine()
        'SampleSection.DisplayTimeSpanAbsoluteRange();
        'SampleSection.TimeStampValidatorInstance();
        'SampleSection.IntegerValidatorInstance();
        'SampleSection.StringValidatorInstance();
        SampleSection.RegexStringValidatorInstance()
        Console.ReadLine()
    End Sub 'Main
End Class 'TestingSampleConfiguration