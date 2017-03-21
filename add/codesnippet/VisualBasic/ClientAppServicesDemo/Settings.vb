'<snippet400>
Option Strict On
Option Explicit On

Imports System
Imports System.Configuration
Imports System.Web.ClientServices.Providers

Namespace My
    
    Friend NotInheritable Class MySettings
        Inherits ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType( _
            ApplicationSettingsBase.Synchronized(New MySettings),MySettings)
        
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                Return defaultInstance
            End Get
        End Property
        
        <UserScopedSettingAttribute(),  _
         SettingsProviderAttribute(GetType(ClientSettingsProvider)),  _
         DefaultSettingValueAttribute("DefaultText")>  _
        Public Property WebSettingsTestText() As String
            Get
                Return CType(Me("WebSettingsTestText"),String)
            End Get
            Set
                Me("WebSettingsTestText") = value
            End Set
        End Property

        <UserScopedSettingAttribute(), _
         SettingsProviderAttribute(GetType(ClientSettingsProvider)), _
         DefaultSettingValueAttribute("MySetting")> _
        Public Property MySetting() As String
            Get
                Return CType(Me("MySetting"), String)
            End Get
            Set(ByVal value As String)
                Me("MySetting") = value
            End Set
        End Property

    End Class

    Friend Module MySettingsProperty
        
        Friend ReadOnly Property Settings() As Global.ClientAppServicesDemo.My.MySettings
            Get
                Return Global.ClientAppServicesDemo.My.MySettings.Default
            End Get
        End Property

    End Module

End Namespace
'</snippet400>