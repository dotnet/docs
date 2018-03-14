' <Snippet1>
Imports System
Imports System.Configuration
Imports System.Collections




' Define a custom section programmatically.

Public NotInheritable Class CustomSection
    Inherits ConfigurationSection
    ' The collection (property bag) that contains 
    ' the section properties.
    Private Shared _Properties _
    As ConfigurationPropertyCollection


    ' The FileName property.
    Private Shared _FileName _
    As New ConfigurationProperty("fileName", _
    GetType(String), "default.txt", _
    ConfigurationPropertyOptions.IsRequired)

    ' The MasUsers property.
    Private Shared _MaxUsers _
    As New ConfigurationProperty("maxUsers", _
    GetType(Long), Fix(1000), _
    ConfigurationPropertyOptions.None)

    ' The MaxIdleTime property.
    Private Shared _MaxIdleTime _
    As New ConfigurationProperty("maxIdleTime", _
    GetType(TimeSpan), TimeSpan.FromMinutes(5), _
    ConfigurationPropertyOptions.IsRequired)


    ' CustomSection constructor.
    Public Sub New()
        ' Property initialization
        _Properties = _
        New ConfigurationPropertyCollection()

        _Properties.Add(_FileName)
        _Properties.Add(_MaxUsers)
        _Properties.Add(_MaxIdleTime)
    End Sub 'New


    ' This is a key customization. 
    ' It returns the initialized property bag.
    Protected Overrides ReadOnly Property Properties() _
    As ConfigurationPropertyCollection
        Get
            Return _Properties
        End Get
    End Property



    <StringValidator( _
    InvalidCharacters:=" ~!@#$%^&*()[]{}/;'""|\", _
    MinLength:=1, MaxLength:=60)> _
    Public Property FileName() As String
        Get
            Return CStr(Me("fileName"))
        End Get
        Set(ByVal value As String)

            Me("fileName") = value
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


    <TimeSpanValidator(MinValueString:="0:0:30", _
    MaxValueString:="5:00:0", ExcludeRange:=False)> _
    Public Property MaxIdleTime() As TimeSpan
        Get
            Return CType(Me("maxIdleTime"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            Me("maxIdleTime") = value
        End Set
    End Property
End Class 'CustomSection 




Class UsingCustomSectionCollection


    ' Create a custom section.
    Shared Sub CreateSection()
        Try

            Dim customSection As CustomSection

            ' Get the current configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            ' Create the section entry  
            ' in the <configSections> and the 
            ' related target section in <configuration>.
            If config.Sections("CustomSection") Is Nothing Then
                customSection = New CustomSection()
                config.Sections.Add("CustomSection", customSection)
                customSection.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)
            End If
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'CreateSection


    '<Snippet2>
    Shared Sub GetAllKeys()

        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)


            Dim sections _
            As ConfigurationSectionCollection = _
            config.Sections

            Dim key As String
            For Each key In sections.Keys
                Console.WriteLine("Key value: {0}", key)
            Next key


        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'GetAllKeys


    '</Snippet2>

    '<Snippet3>
    Shared Sub Clear()

        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            config.Sections.Clear()

            config.Save( _
            ConfigurationSaveMode.Full)
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'Clear


    '</Snippet3>
    '<Snippet4>
    Shared Sub GetSection()

        Try
            Dim customSection _
            As CustomSection = _
            ConfigurationManager.GetSection( _
            "CustomSection")

            If customSection Is Nothing Then
                Console.WriteLine("Failed to load CustomSection.")
            Else
                ' Display section information
                Console.WriteLine("Defaults:")
                Console.WriteLine("File Name:       {0}", _
                customSection.FileName)
                Console.WriteLine("Max Users:       {0}", _
                customSection.MaxUsers)
                Console.WriteLine("Max Idle Time:   {0}", _
                customSection.MaxIdleTime)
            End If


        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'GetSection

    '</Snippet4>
    '<Snippet5>
    Shared Sub GetEnumerator()

        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim sections _
            As ConfigurationSectionCollection = _
            config.Sections

            Dim secEnum _
            As IEnumerator = sections.GetEnumerator()

            '<Snippet6>
            Dim i As Integer = 0
            While secEnum.MoveNext()
                Dim setionName _
                As String = sections.GetKey(i)
                Console.WriteLine( _
                "Section name: {0}", setionName)
                i += 1
            End While
            '</Snippet6>
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'GetEnumerator

    '</Snippet5>

    '<Snippet7>
    Shared Sub GetKeys()

        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim sections _
            As ConfigurationSectionCollection = _
            config.Sections


            Dim key As String
            For Each key In sections.Keys


                Console.WriteLine("Key value: {0}", key)
            Next key


        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'GetKeys


    '</Snippet7>
    '<Snippet8>
    Shared Sub GetItems()

        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim sections _
            As ConfigurationSectionCollection = _
            config.Sections


            Dim section1 As ConfigurationSection = _
            sections.Item("runtime")

            Dim section2 As ConfigurationSection = _
            sections.Item(0)

            Console.WriteLine("Section1: {0}", _
            section1.SectionInformation.Name)

            Console.WriteLine("Section2: {0}", _
            section2.SectionInformation.Name)

        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'GetItems


    '</Snippet8>
    '<Snippet9>
    Shared Sub Remove()

        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim customSection As CustomSection = _
            config.GetSection("CustomSection")


            If Not (customSection Is Nothing) Then
                config.Sections.Remove("CustomSection")
                customSection.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)
            Else
                Console.WriteLine( _
                "CustomSection does not exists.")
            End If

        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'Remove

    '</Snippet9>

    '<Snippet10>
    Shared Sub AddSection()

        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim customSection _
            As New CustomSection()


            Dim index As String = _
            config.Sections.Count.ToString()

            customSection.FileName = _
            "newFile" + index + ".txt"

            Dim sectionName As String = _
            "CustomSection" + index

            Dim ts As New TimeSpan(0, 15, 0)
            customSection.MaxIdleTime = ts
            customSection.MaxUsers = 100

            config.Sections.Add(sectionName, customSection)
            customSection.SectionInformation.ForceSave = True
            config.Save(ConfigurationSaveMode.Full)
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'AddSection


    '</Snippet10>

    ' Exercise the collection.
    ' Uncomment the function you want to exercise.
    ' Start with CreateSection().
    Public Overloads Shared Sub Main(ByVal args() As String)
        CreateSection()
        ' AddSection()
        ' GetSection()
        ' GetEnumerator()
        ' GetAllKeys()
        ' GetKeys()
        GetItems()
        ' Clear()
        ' Remove()
    End Sub 'Main 

End Class 'UsingCustomSectionCollection 
' </Snippet1>




