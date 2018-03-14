'<Snippet1>

Imports System
Imports System.Configuration


Public Class UsingRsaProtectedConfigurationProvider
   
   
   ' Protect the connectionStrings section.
   Private Shared Sub ProtectConfiguration()
      
      ' Get the application configuration file.
        Dim config As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
      
      ' Define the Rsa provider name.
        Dim provider As String = _
        "RsaProtectedConfigurationProvider"
      
      ' Get the section to protect.
        Dim connStrings As ConfigurationSection = _
        config.ConnectionStrings
      
      If Not (connStrings Is Nothing) Then
         If Not connStrings.SectionInformation.IsProtected Then
            If Not connStrings.ElementInformation.IsLocked Then
                    ' Protect the section.

                    connStrings.SectionInformation.ProtectSection(provider)


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
        Dim config As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
      
      ' Get the section to unprotect.
        Dim connStrings As ConfigurationSection = _
        config.ConnectionStrings
      
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
            "Select protect or unprotect")
            Return
        End If

        selection = args(0).ToLower()

        Select Case selection
            Case "protect"
                ProtectConfiguration()

            Case "unprotect"
                UnProtectConfiguration()

            Case Else
                Console.WriteLine( _
                "Unknown selection")
        End Select

        Console.Read()
    End Sub 'Main

End Class 'UsingRsaProtectedConfigurationProvider

'</Snippet1>