Option Explicit On
Option Strict On
Imports System.Configuration
Imports System.Web.Configuration

Class Program
    Shared Sub Main()
    End Sub
    ' <Snippet1>
    Shared Sub ToggleWebEncrypt()
        ' Open the Web.config file.
        Dim config As Configuration = WebConfigurationManager. _
          OpenWebConfiguration("~")

        ' Get the connectionStrings section.
        Dim section As ConnectionStringsSection = DirectCast( _
            config.GetSection("connectionStrings"), _
            ConnectionStringsSection)

        ' Toggle encryption.
        If section.SectionInformation.IsProtected Then
            section.SectionInformation.UnprotectSection()
        Else
            section.SectionInformation.ProtectSection( _
              "DataProtectionConfigurationProvider")
        End If

        ' Save changes to the Web.config file.
        config.Save()
    End Sub
    ' </Snippet1>
End Class

