'<Snippet11>
Imports System
Imports System.Configuration

Namespace Samples.AspNet
    ' Show how to use a custom protected configuration
    ' provider.

    Public Class TestingProtectedConfigurationProvider


        ' Protect the connectionStrings section.
        Private Shared Sub ProtectConfiguration()

            ' Get the application configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            ' Define the provider name.
            Dim provider As String = _
            "TripleDESProtectedConfigurationProvider"

            ' Get the section to protect.
            Dim connStrings _
            As ConfigurationSection = config.ConnectionStrings

            If Not (connStrings Is Nothing) Then
                If Not connStrings.SectionInformation.IsProtected Then
                    If Not connStrings.ElementInformation.IsLocked Then
                        ' Protect the section.
                        connStrings.SectionInformation.ProtectSection( _
                        provider)

                        connStrings.SectionInformation.ForceSave = True
                        config.Save(ConfigurationSaveMode.Full)

                        Console.WriteLine( _
                        "Section {0} is now protected by {1}", _
                        connStrings.SectionInformation.Name, _
                        connStrings.SectionInformation.ProtectionProvider.Name)

                    Else
                        Console.WriteLine( _
                        "Can't protect, section {0} is locked", _
                        connStrings.SectionInformation.Name)
                    End If
                Else
                    Console.WriteLine( _
                    "Section {0} is already protected by {1}", _
                    connStrings.SectionInformation.Name, _
                    connStrings.SectionInformation.ProtectionProvider.Name)
                End If

            Else
                Console.WriteLine( _
                "Can't get the section {0}", _
                connStrings.SectionInformation.Name)
            End If
        End Sub 'ProtectConfiguration


        ' Unprotect the connectionStrings section.
        Private Shared Sub UnProtectConfiguration()

            ' Get the application configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            ' Get the section to unprotect.
            Dim connStrings _
            As ConfigurationSection = config.ConnectionStrings

            If Not (connStrings Is Nothing) Then
                If connStrings.SectionInformation.IsProtected Then
                    If Not connStrings.ElementInformation.IsLocked Then
                        ' Unprotect the section.
                        connStrings.SectionInformation.UnprotectSection()

                        connStrings.SectionInformation.ForceSave = True
                        config.Save(ConfigurationSaveMode.Full)

                        Console.WriteLine( _
                        "Section {0} is now unprotected.", _
                        connStrings.SectionInformation.Name)

                    Else
                        Console.WriteLine( _
                        "Can't unprotect, section {0} is locked", _
                        connStrings.SectionInformation.Name)
                    End If
                Else
                    Console.WriteLine( _
                    "Section {0} is already unprotected.", _
                    connStrings.SectionInformation.Name)
                End If

            Else
                Console.WriteLine( _
                "Can't get the section {0}", _
                connStrings.SectionInformation.Name)
            End If
        End Sub 'UnProtectConfiguration



        Public Shared Sub Main(ByVal args() As String)

            Dim selection As String = String.Empty

            If args.Length = 0 Then
                Console.WriteLine( _
                "Select createkey, protect or unprotect")
                Return
            End If

            selection = args(0).ToLower()

            Select Case selection

                ' Create the key to use during 
                ' encryption/decryption.
                Case "createkey"
                    Dim keyContainer As String = "pcKey.txt"

                    ' Instantiate the custom provider.
                    Dim provider _
                    As New TripleDESProtectedConfigurationProvider()

                    ' Create the encryption/decryption key.
                    provider.CreateKey(keyContainer)

                    Console.WriteLine( _
                    "New TripleDES key created in {0}", _
                    keyContainer)

                Case "protect"
                    ProtectConfiguration()

                Case "unprotect"
                    UnProtectConfiguration()

                Case Else
                    Console.WriteLine("Unknown selection")
            End Select

            Console.Read()
        End Sub 'Main 
    End Class 'TestingProtectedConfigurationProvider
End Namespace
'</Snippet11>
