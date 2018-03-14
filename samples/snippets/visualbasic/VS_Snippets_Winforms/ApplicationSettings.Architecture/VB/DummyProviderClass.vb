'<SNIPPET1>
Imports System.Configuration

<SettingsProvider("SqlSettingsProvider")> _
Public Class CustomSettings
    Inherits ApplicationSettingsBase

    ' Implementation goes here.
End Class
'</SNIPPET1>

Public MustInherit Class DummyProviderBase
    Public MustOverride Property ApplicationName() As String
End Class

Public Class DummyProviderClass
    Inherits DummyProviderBase

    '<SNIPPET2>
    Public Overrides Property ApplicationName() As String
        Get
            ApplicationName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
        End Get
        Set(ByVal value As String)
            ' Do nothing.
        End Set
    End Property
    '</SNIPPET2>
End Class
