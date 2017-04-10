
Imports System
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web
Imports System.Web.Configuration
Imports System.Xml
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions


' Exercises the HttpModulesSection members selected by the user. 

Class UsingHttpModulesSection


Public Sub New() 

' <Snippet1>
' Get the Web application configuration.
Dim configuration As System.Configuration.Configuration = WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

' Get the HttpModulesSection.
Dim httpModulesSection As HttpModulesSection = CType(configuration.GetSection("system.web/httpModules"), HttpModulesSection)

' </Snippet1>


' <Snippet2>
' Create a new HttpModulesSection object.
Dim newHttpModulesSection As New HttpModulesSection()

' </Snippet2>

' <Snippet3>
' Get the modules collection.
Dim httpModules As HttpModuleActionCollection = httpModulesSection.Modules

' Read the modules information.
Dim modulesInfo As New StringBuilder()
Dim i As Integer
For i = 0 To httpModules.Count
  modulesInfo.Append(String.Format("Name: {0}" + vbLf + "Type: {1}" + vbLf + vbLf, httpModules(i).Name, httpModules(i).Type))
Next i

' </Snippet3>

End Sub 'New
End Class 'UsingHttpModulesSection

' UsingHttpModulesSection class end.
' Samples.Aspnet.SystemWebManagement namespace end.