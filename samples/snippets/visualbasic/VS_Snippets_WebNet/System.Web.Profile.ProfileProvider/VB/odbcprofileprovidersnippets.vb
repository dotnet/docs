Imports System
Imports System.Configuration
Imports System.Collections.Specialized
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.Profile
<AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal), _
 AspNetHostingPermission(SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal)> _
Public Class SnippetProfileProvider
  Inherits ProfileProvider



  '
  ' System.Configuration.Provider.ProviderBase.Initialize Method
  '

  Public Overrides Sub Initialize(ByVal name As String, ByVal config As NameValueCollection)
    MyBase.Initialize(name, config)
  End Sub


  '
  ' System.Configuration.SettingsProvider.ApplicationName
  '

  Private pApplicationName As String

  Public Overrides Property ApplicationName() As String
    Get
      Return pApplicationName
    End Get
    Set(ByVal value As String)
      pApplicationName = value
    End Set
  End Property



  '
  ' System.Configuration.SettingsProvider methods.
  '

  '
  ' SettingsProvider.GetPropertyValues
  '

  Public Overrides Function GetPropertyValues(ByVal context As SettingsContext, _
  ByVal ppc As SettingsPropertyCollection) As SettingsPropertyValueCollection

    Return New SettingsPropertyValueCollection()
  End Function



  '
  ' SettingsProvider.SetPropertyValues
  '

  Public Overrides Sub SetPropertyValues(ByVal context As SettingsContext, _
  ByVal ppvc As SettingsPropertyValueCollection)

  End Sub




  '
  ' ProfileProvider.DeleteProfiles(ProfileInfoCollection)
  '

  '<Snippet1>
  Public Overrides Function DeleteProfiles(ByVal profiles As ProfileInfoCollection) As Integer
    Return 0
  End Function
  '</Snippet1>

  '
  ' ProfileProvider.DeleteProfiles(string())
  '

  '<Snippet2>
  Public Overrides Function DeleteProfiles(ByVal usernames As String()) As Integer
    Return 0
  End Function
  '</Snippet2>


  '
  ' ProfileProvider.DeleteInactiveProfiles
  '

  '<Snippet3>
  Public Overrides Function DeleteInactiveProfiles( _
  ByVal authenticationOption As ProfileAuthenticationOption, _
  ByVal userInactiveSinceDate As DateTime) As Integer

    Return 0
  End Function
  '</Snippet3>


  '
  ' ProfileProvider.FindProfilesByUserName
  '

  '<Snippet4>
  Public Overrides Function FindProfilesByUserName( _
  ByVal authenticationOption As ProfileAuthenticationOption, _
  ByVal usernameToMatch As String, _
  ByVal pageIndex As Integer, _
  ByVal pageSize As Integer, _
   ByRef totalRecords As Integer) As ProfileInfoCollection

    totalRecords = 0

    Return New ProfileInfoCollection()
  End Function
  '</Snippet4>

  '
  ' ProfileProvider.FindInactiveProfilesByUserName
  '

  '<Snippet5>
  Public Overrides Function FindInactiveProfilesByUserName( _
  ByVal authenticationOption As ProfileAuthenticationOption, _
  ByVal usernameToMatch As String, _
  ByVal userInactiveSinceDate As DateTime, _
  ByVal pageIndex As Integer, _
  ByVal pageSize As Integer, _
   ByRef totalRecords As Integer) As ProfileInfoCollection

    totalRecords = 0

    Return New ProfileInfoCollection()
  End Function
  '</Snippet5>

  '
  ' ProfileProvider.GetAllProfiles
  '

  '<Snippet6>
  Public Overrides Function GetAllProfiles( _
  ByVal authenticationOption As ProfileAuthenticationOption, _
  ByVal pageIndex As Integer, _
  ByVal pageSize As Integer, _
   ByRef totalRecords As Integer) As ProfileInfoCollection

    totalRecords = 0

    Return New ProfileInfoCollection()
  End Function
  '</Snippet6>

  '
  ' ProfileProvider.GetAllInactiveProfiles
  '

  '<Snippet7>
  Public Overrides Function GetAllInactiveProfiles( _
  ByVal authenticationOption As ProfileAuthenticationOption, _
  ByVal userInactiveSinceDate As DateTime, _
  ByVal pageIndex As Integer, _
  ByVal pageSize As Integer, _
   ByRef totalRecords As Integer) As ProfileInfoCollection

    totalRecords = 0

    Return New ProfileInfoCollection()
  End Function
  '</Snippet7>

  '
  ' ProfileProvider.GetNumberOfInactiveProfiles
  '

  '<Snippet8>
  Public Overrides Function GetNumberOfInactiveProfiles( _
  ByVal authenticationOption As ProfileAuthenticationOption, _
  ByVal userInactiveSinceDate As DateTime) As Integer

    Return 0
  End Function
  '</Snippet8>
End Class