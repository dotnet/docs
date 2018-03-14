
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Web.Configuration


' Accesses the System.Web.Configuration.IdentitySection
' members selected by the user.

Public Class UsingIdentitySection


Public Sub New() 

' Process the selection.
Try

' <Snippet1>
' Get the Web application configuration.
Dim configuration As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

' Get the section.
Dim identitySection As System.Web.Configuration.IdentitySection = CType(configuration.GetSection("system.web/identity"), System.Web.Configuration.IdentitySection)

' </Snippet1>

' <Snippet2>
' Create a new IdentitySection object.
Dim newidentitySection As New System.Web.Configuration.IdentitySection()
' </Snippet2>

' <Snippet3>
' Get the Password property value.
Dim currentPassword As String = identitySection.Password

' Set the Password property value.
identitySection.Password = "userPassword"
' </Snippet3>

' <Snippet4>
' Get the UserName property value.
Dim currentUserName As String = identitySection.UserName

' Set the UserName property value.
identitySection.UserName = "userName"
' </Snippet4>

' <Snippet5>
' Get the Impersonate property value.
Dim currentImpersonate As Boolean = identitySection.Impersonate

' Set the Impersonate property to true.
identitySection.Impersonate = True
' </Snippet5> 

Catch e As Exception
' Unknown error.
Console.WriteLine("Error" + e.ToString())
End Try

End Sub 'New
End Class 'UsingIdentitySection ' UsingIdentitySection class end.
' Samples.Aspnet.SystemWebConfiguration namespace end.