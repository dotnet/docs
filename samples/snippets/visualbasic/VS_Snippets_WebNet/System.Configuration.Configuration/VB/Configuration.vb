'<Snippet31>
Imports System.Text
Imports System.Configuration
Imports System.Globalization
Imports System.ComponentModel
Imports System.Collections.Specialized

' Before compiling this application, 
' remember to reference the System.Configuration assembly in your project. 
#Region "CustomSection class"

'<Snippet1>
' Define a custom section. This class is used to
' populate the configuration file.
' It creates the following custom section:
'  <CustomSection name="Contoso" url="http://www.contoso.com" port="8080" />.
Public NotInheritable Class CustomSection
    Inherits ConfigurationSection

    Public Sub New()

    End Sub


    <ConfigurationProperty("name", DefaultValue:="Contoso", IsRequired:=True, IsKey:=True)> _
    Public Property Name() As String
        Get
            Return CStr(Me("name"))
        End Get
        Set(ByVal value As String)
            Me("name") = value
        End Set
    End Property

    <ConfigurationProperty("url", DefaultValue:="http://www.contoso.com", IsRequired:=True), RegexStringValidator("\w+:\/\/[\w.]+\S*")> _
    Public Property Url() As String
        Get
            Return CStr(Me("url"))
        End Get
        Set(ByVal value As String)
            Me("url") = value
        End Set
    End Property

    <ConfigurationProperty("port", DefaultValue:=CInt(8080), IsRequired:=False), IntegerValidator(MinValue:=0, MaxValue:=8080, ExcludeRange:=False)> _
    Public Property Port() As Integer
        Get
            Return CInt(Fix(Me("port")))
        End Get
        Set(ByVal value As Integer)
            Me("port") = value
        End Set
    End Property



End Class
'</Snippet1>

#End Region

#Region "Using Configuration Class"
Friend Class UsingConfigurationClass

    '<Snippet2>
    ' Show how to create an instance of the Configuration class
    ' that represents this application configuration file.  
    Public Shared Sub CreateConfigurationFile()
        Try

            ' Create a custom configuration section.
            Dim customSection As New CustomSection()

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            ' Create the section entry  
            ' in <configSections> and the 
            ' related target section in <configuration>.
            If config.Sections("CustomSection") Is Nothing Then
                config.Sections.Add("CustomSection", customSection)
            End If

            ' Create and add an entry to appSettings section.

            Dim conStringname As String = "LocalSqlServer"
            Dim conString As String = "data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|aspnetdb.mdf;User Instance=true"
            Dim providerName As String = "System.Data.SqlClient"

            Dim connStrSettings As New ConnectionStringSettings()
            connStrSettings.Name = conStringname
            connStrSettings.ConnectionString = conString
            connStrSettings.ProviderName = providerName

            config.ConnectionStrings.ConnectionStrings.Add(connStrSettings)

            ' Add an entry to appSettings section.
            Dim appStgCnt As Integer = ConfigurationManager.AppSettings.Count
            Dim newKey As String = "NewKey" & appStgCnt.ToString()

            Dim newValue As String = Date.Now.ToLongDateString() & " " & Date.Now.ToLongTimeString()

            config.AppSettings.Settings.Add(newKey, newValue)

            ' Save the configuration file.
            customSection.SectionInformation.ForceSave = True
            config.Save(ConfigurationSaveMode.Full)

            Console.WriteLine("Created configuration file: {0}", config.FilePath)

        Catch err As ConfigurationErrorsException
            Console.WriteLine("CreateConfigurationFile: {0}", err.ToString())
        End Try

    End Sub
    '</Snippet2>

    '<Snippet3>
    ' Show how to use the GetSection(string) method.
    Public Shared Sub GetCustomSection()
        Try

            Dim customSection As CustomSection

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)

            customSection = TryCast(config.GetSection("CustomSection"), CustomSection)

            Console.WriteLine("Section name: {0}", customSection.Name)
            Console.WriteLine("Url: {0}", customSection.Url)
            Console.WriteLine("Port: {0}", customSection.Port)

        Catch err As ConfigurationErrorsException
            Console.WriteLine("Using GetSection(string): {0}", err.ToString())
        End Try

    End Sub
    '</Snippet3>

    '<Snippet4>

    ' Show how to use different modalities to save 
    ' a configuration file.
    Public Shared Sub SaveConfigurationFile()
        Try

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)

            ' Save the full configuration file and force save even if the file was not modified.
            config.SaveAs("MyConfigFull.config", ConfigurationSaveMode.Full, True)
            Console.WriteLine("Saved config file as MyConfigFull.config using the mode: {0}", ConfigurationSaveMode.Full.ToString())

            config = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)

            ' Save only the part of the configuration file that was modified. 
            config.SaveAs("MyConfigModified.config", ConfigurationSaveMode.Modified, True)
            Console.WriteLine("Saved config file as MyConfigModified.config using the mode: {0}", ConfigurationSaveMode.Modified.ToString())

            config = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)

            ' Save the full configuration file.
            config.SaveAs("MyConfigMinimal.config")
            Console.WriteLine("Saved config file as MyConfigMinimal.config using the mode: {0}", ConfigurationSaveMode.Minimal.ToString())

        Catch err As ConfigurationErrorsException
            Console.WriteLine("SaveConfigurationFile: {0}", err.ToString())
        End Try

    End Sub
    '</Snippet4>


    ' Show how use the AppSettings and ConnectionStrings 
    ' properties.
    Public Shared Sub GetSections(ByVal section As String)
        Try

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)

            ' Get the selected section.
            Select Case section
                Case "appSettings"
                    '<Snippet5>
                    Try
                        Dim appSettings As AppSettingsSection = TryCast(config.AppSettings, AppSettingsSection)
                        Console.WriteLine("Section name: {0}", appSettings.SectionInformation.SectionName)

                        ' Get the AppSettings section elements.
                        Console.WriteLine()
                        Console.WriteLine("Using AppSettings property.")
                        Console.WriteLine("Application settings:")
                        ' Get the KeyValueConfigurationCollection 
                        ' from the configuration.
                        Dim settings As KeyValueConfigurationCollection = config.AppSettings.Settings

                        ' Display each KeyValueConfigurationElement.
                        For Each keyValueElement As KeyValueConfigurationElement In settings
                            Console.WriteLine("Key: {0}", keyValueElement.Key)
                            Console.WriteLine("Value: {0}", keyValueElement.Value)
                            Console.WriteLine()
                        Next keyValueElement
                    Catch e As ConfigurationErrorsException
                        Console.WriteLine("Using AppSettings property: {0}", e.ToString())
                    End Try
                    '</Snippet5>

                Case "connectionStrings"
                    '<Snippet6>
                    Dim conStrSection As ConnectionStringsSection = TryCast(config.ConnectionStrings, ConnectionStringsSection)
                    Console.WriteLine("Section name: {0}", conStrSection.SectionInformation.SectionName)

                    Try
                        If conStrSection.ConnectionStrings.Count <> 0 Then
                            Console.WriteLine()
                            Console.WriteLine("Using ConnectionStrings property.")
                            Console.WriteLine("Connection strings:")

                            ' Get the collection elements.
                            For Each connection As ConnectionStringSettings In conStrSection.ConnectionStrings
                                Dim name As String = connection.Name
                                Dim provider As String = connection.ProviderName
                                Dim connectionString As String = connection.ConnectionString

                                Console.WriteLine("Name:               {0}", name)
                                Console.WriteLine("Connection string:  {0}", connectionString)
                                Console.WriteLine("Provider:            {0}", provider)
                            Next connection
                        End If
                    Catch e As ConfigurationErrorsException
                        Console.WriteLine("Using ConnectionStrings property: {0}", e.ToString())
                    End Try
                    '</Snippet6>

                Case Else
                    Console.WriteLine("GetSections: Unknown section (0)", section)
            End Select

        Catch err As ConfigurationErrorsException
            Console.WriteLine("GetSections: (0)", err.ToString())
        End Try

    End Sub

    ' Show how to use the Configuration object properties 
    ' to obtain configuration file information.
    Public Shared Sub GetConfigurationInformation()
        Try

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)

            Console.WriteLine("Reading configuration information:")

            '<Snippet7>
            Dim evalContext As ContextInformation = TryCast(config.EvaluationContext, ContextInformation)
            Console.WriteLine("Machine level: {0}", evalContext.IsMachineLevel.ToString())
            '</Snippet7>

            '<Snippet8>
            Dim filePath As String = config.FilePath
            Console.WriteLine("File path: {0}", filePath)
            '</Snippet8>

            '<Snippet9>
            Dim hasFile As Boolean = config.HasFile
            Console.WriteLine("Has file: {0}", hasFile.ToString())
            '</Snippet9>


            '<Snippet10>
            Dim groups As ConfigurationSectionGroupCollection = config.SectionGroups
            Console.WriteLine("Groups: {0}", groups.Count.ToString())
            For Each group As ConfigurationSectionGroup In groups
                Console.WriteLine("Group Name: {0}", group.Name)
                ' Console.WriteLine("Group Type: {0}", group.Type);
            Next group
            '</Snippet10>


            '<Snippet11>
            Dim sections As ConfigurationSectionCollection = config.Sections
            Console.WriteLine("Sections: {0}", sections.Count.ToString())
            '</Snippet11>


        Catch err As ConfigurationErrorsException
            Console.WriteLine("GetConfigurationInformation: {0}", err.ToString())
        End Try

    End Sub
End Class

#End Region

#Region "Application Main"
'*** User Interaction Class ***//

' Obtain user's input and provide feedback.
' This class contains the application Main() function.
' It calls the ConfigurationManager methods based 
' on the user's selection.
Public Class ApplicationMain
    ' Display user's menu.
    Public Shared Sub UserMenu()
        Dim applicationName As String = Environment.GetCommandLineArgs()(0) & ".exe"
        Dim buffer As New StringBuilder()

        buffer.AppendLine("Application: " & applicationName)
        buffer.AppendLine("Please, make your selection.")
        buffer.AppendLine("?    -- Display help.")
        buffer.AppendLine("Q,q  -- Exit the application.")

        buffer.Append("1    -- Instantiate the")
        buffer.AppendLine(" Configuration class.")

        buffer.Append("2    -- Use GetSection(string) to read ")
        buffer.AppendLine(" a custom section.")

        buffer.Append("3    -- Use SaveAs methods")
        buffer.AppendLine(" to save the configuration file.")

        buffer.Append("4    -- Use AppSettings property to read")
        buffer.AppendLine(" the appSettings section.")
        buffer.Append("5    -- Use ConnectionStrings property to read")
        buffer.AppendLine(" the connectionStrings section.")

        buffer.Append("6    -- Use Configuration class properties")
        buffer.AppendLine(" to obtain configuration information.")

        Console.Write(buffer.ToString())
    End Sub

    ' Obtain user's input and provide
    ' feedback.
    Shared Sub Main(ByVal args() As String)
        ' Define user selection string.
        Dim selection As String

        ' Get the name of the application.
        Dim appName As String = Environment.GetCommandLineArgs()(0)


        ' Get user selection.
        Do

            UserMenu()
            Console.Write("> ")
            selection = Console.ReadLine()
            If selection <> String.Empty Then
                Exit Do
            End If
        Loop

        Do While selection.ToLower() <> "q"
            ' Process user's input.
            Select Case selection
                Case "1"
                    ' Show how to create an instance of the Configuration class.
                    UsingConfigurationClass.CreateConfigurationFile()

                Case "2"
                    ' Show how to use GetSection(string) method.
                    UsingConfigurationClass.GetCustomSection()

                Case "3"
                    ' Show how to use ConnectionStrings.
                    UsingConfigurationClass.SaveConfigurationFile()

                Case "4"
                    ' Show how to use the AppSettings property.
                    UsingConfigurationClass.GetSections("appSettings")

                Case "5"
                    ' Show how to use the ConnectionStrings property.
                    UsingConfigurationClass.GetSections("connectionStrings")

                Case "6"
                    ' Show how to obtain configuration file information.
                    UsingConfigurationClass.GetConfigurationInformation()


                Case Else
                    UserMenu()
            End Select
            Console.Write("> ")
            selection = Console.ReadLine()
        Loop
    End Sub
End Class
#End Region
'</Snippet31>