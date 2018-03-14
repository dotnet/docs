' <Snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  ' Accesses the System.Web.Configuration.WebPartsSection
  ' members selected by the user.
  Class UsingWebPartsSection
    Public Shared Sub Main()
      ' Process the System.Web.Configuration.WebPartsSectionobject.
      Try
        ' Get the Web application configuration.
                Dim configuration As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration("/aspnet")

        ' Get the section.
        Dim webPartsSection As WebPartsSection = _
         CType(configuration.Sections("system.web/webParts"), _
         WebPartsSection)

' <Snippet2>
' <Snippet5>
' Add a Transfomer Info Object to the collection using a constructor.
webPartsSection.Transformers.Add(New TransformerInfo( _
  "RowToFilterTransformer", _
  "MyCustomTransformers.RowToFilterTransformer"))

' </Snippet5>
' <Snippet6>
' Show all TransformerInfo objects in the collection.
Dim ti As Integer
For ti = 0 To webPartsSection.Personalization.Providers.Count - 1
  Console.WriteLine("  #{0} Name={1} Type={2}", ti, _
    webPartsSection.Transformers(ti).Name, _
    webPartsSection.Transformers(ti).Type)
Next

' </Snippet6>
' <Snippet7>
' Remove a TransformerInfo object by name.
webPartsSection.Transformers.Remove("RowToFilterTransformer")

' </Snippet7>
' <Snippet8>
' Remove a TransformerInfo object by index.
webPartsSection.Transformers.RemoveAt(0)

' </Snippet8>
' <Snippet9>
' Clear all TransformerInfo objects from the collection.
webPartsSection.Transformers.Clear()

' </Snippet9>
' </Snippet2>
' <Snippet3>
' <Snippet13>
' Get the current DefaultProvider property value.
Console.WriteLine( _
  "Current DefaultProvider value: '{0}'", _
  webPartsSection.Personalization.DefaultProvider)

' Set the DefaultProvider property.
webPartsSection.Personalization.DefaultProvider = _
  "ASPNetSQLPersonalizationProvider"
' </Snippet13>
' <Snippet14>
' Add a provider.
webPartsSection.Personalization.Providers.Add( _
  New ProviderSettings("CustomProvider", _
  "MyCustomProviders.Provider"))

' List current providers.
Dim pi As Integer
For pi = 0 To webPartsSection.Personalization.Providers.Count - 1
  Console.WriteLine("  #{0} Name={1} Type={2}", pi, _
    webPartsSection.Personalization.Providers(pi).Name, _
    webPartsSection.Personalization.Providers(pi).Type)
Next

' </Snippet14>
' <Snippet15>
' Add an authorization.
Dim ar As AuthorizationRule = _
  New AuthorizationRule(AuthorizationRuleAction.Allow)
ar.Verbs.Add("ModifyState")
ar.Users.Add("Admin")
webPartsSection.Personalization.Authorization.Rules.Add(ar)

' List current authorizations.
Dim ai As Integer
For ai = 0 To _
  webPartsSection.Personalization.Authorization.Rules.Count
	Console.WriteLine("  #{0}:", ai)
    Dim aRule As AuthorizationRule = _
      webPartsSection.Personalization.Authorization.Rules(ai)
    Console.WriteLine("  Verbs=")
    Dim verb As String
    For Each verb In aRule.Verbs
      Console.WriteLine("    * {0}", verb)
      Console.WriteLine("  Roles=")
    Next
    Dim role As String
	For Each role In aRule.Roles
      Console.WriteLine("    * {0}", role)
      Console.WriteLine("  Users=")
    Next
    Dim user As String
	For Each user In aRule.Users
      Console.WriteLine("    * {0}", user)
    Next
Next

                ' </Snippet15>
                ' </Snippet3>
                ' Update if not locked.
                If Not webPartsSection.IsReadOnly() Then
                    configuration.Save()
                    Console.WriteLine("** Configuration updated.")
                Else
                    Console.WriteLine("** Could not update, section is locked.")
                End If
            Catch e As System.ArgumentException
        ' Unknown error.
        Console.WriteLine( _
          "A invalid argument exception detected in UsingWebPartsSection Main. Check your")
        Console.WriteLine("command line for errors.")
      End Try
    End Sub
  End Class ' UsingWebPartsSection.
End Namespace ' Samples.Aspnet.SystemWebConfiguration

' </Snippet1>
