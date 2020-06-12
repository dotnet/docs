Option Explicit On
Option Strict On
Imports System.Configuration

Class Program
    Shared Sub Main()
    End Sub
    ' <Snippet1>
    Shared Sub ToggleConfigEncryption(ByVal exeConfigName As String)
        ' Takes the executable file name without the
        ' .config extension.
        Try
            ' Open the configuration file and retrieve 
            ' the connectionStrings section.
            Dim config As Configuration = ConfigurationManager. _
                OpenExeConfiguration(exeConfigName)

            Dim section As ConnectionStringsSection = DirectCast( _
                config.GetSection("connectionStrings"), _
                ConnectionStringsSection)

            If section.SectionInformation.IsProtected Then
                ' Remove encryption.
                section.SectionInformation.UnprotectSection()
            Else
                ' Encrypt the section.
                section.SectionInformation.ProtectSection( _
                  "DataProtectionConfigurationProvider")
            End If

            ' Save the current configuration.
            config.Save()

            Console.WriteLine("Protected={0}", _
            section.SectionInformation.IsProtected)

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    ' </Snippet1>
End Class

