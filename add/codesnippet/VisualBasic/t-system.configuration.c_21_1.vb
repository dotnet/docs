Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration


' Define a custom section.
' This class shows how to use the ConfigurationPropertyAttribute.
Public Class UrlsSection
    Inherits ConfigurationSection
    <ConfigurationProperty("name", DefaultValue:="Contoso", IsRequired:=True, IsKey:=True)>
    Public Property Name() As String
        Get
            Return CStr(Me("name"))
        End Get
        Set(ByVal value As String)
            Me("name") = value
        End Set
    End Property

    <ConfigurationProperty("url", DefaultValue:="http://www.contoso.com", IsRequired:=True), RegexStringValidator("\w+:\/\/[\w.]+\S*")>
    Public Property Url() As String
        Get
            Return CStr(Me("url"))
        End Get
        Set(ByVal value As String)
            Me("url") = value
        End Set
    End Property

    <ConfigurationProperty("port", DefaultValue:=0, IsRequired:=False), IntegerValidator(MinValue:=0, MaxValue:=8080, ExcludeRange:=False)>
    Public Property Port() As Integer
        Get
            Return CInt(Fix(Me("port")))
        End Get
        Set(ByVal value As Integer)
            Me("port") = value
        End Set
    End Property
End Class