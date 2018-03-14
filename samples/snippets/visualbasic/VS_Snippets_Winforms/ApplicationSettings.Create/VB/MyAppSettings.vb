'<SNIPPET1>
Imports System.Configuration

Public Class MyUserSettings
    Inherits ApplicationSettingsBase
    <UserScopedSetting()> _
    <DefaultSettingValue("white")> _
    Public Property BackgroundColor() As Color
        Get
            BackgroundColor = Me("BackgroundColor")
        End Get

        Set(ByVal value As Color)
            Me("BackgroundColor") = value
        End Set
    End Property
End Class
'</SNIPPET1>