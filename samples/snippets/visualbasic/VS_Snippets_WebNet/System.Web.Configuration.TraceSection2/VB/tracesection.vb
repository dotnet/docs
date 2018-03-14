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
    ' Accesses the System.Web.Configuration.TraceSection members
    ' selected by the user.
    Class UsingTraceSection
        Public Shared Sub Main()
            ' Process the System.Web.Configuration.TraceSectionobject.
            Try
                ' Get the Web application configuration.
                Dim configuration As System.Configuration.Configuration = _
                    System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnet")

                ' Get the section.
                Dim traceSection As System.Web.Configuration.TraceSection = _
                    CType(configuration.GetSection("system.web/trace"), _
                    System.Web.Configuration.TraceSection)
                ' <Snippet2>

                ' Get the current PageOutput property value.
                Dim pageOutputValue As Boolean = traceSection.PageOutput

                ' Set the PageOutput property to true.
                traceSection.PageOutput = True

                ' </Snippet2>

                ' <Snippet3>

                ' Get the current WriteToDiagnosticsTrace property value.
                Dim writeToDiagnosticsTraceValue As Boolean = traceSection.WriteToDiagnosticsTrace

                ' Set the WriteToDiagnosticsTrace property to true.
                traceSection.WriteToDiagnosticsTrace = True

                ' </Snippet3>

                ' <Snippet4>

                ' Get the current MostRecent property value.
                Dim mostRecentValue As Boolean = traceSection.MostRecent

                ' Set the MostRecent property to true.
                traceSection.MostRecent = True

                ' </Snippet4>

                ' <Snippet5>

                ' Get the current RequestLimit property value.
                Dim requestLimitValue As Int32 = traceSection.RequestLimit

                ' Set the RequestLimit property to 256.
                traceSection.RequestLimit = 256

                ' </Snippet5>

                ' <Snippet6>

                ' Get the current LocalOnly property value.
                Dim localOnlyValue As Boolean = traceSection.LocalOnly

                ' Set the LocalOnly property to false.
                traceSection.LocalOnly = False

                ' </Snippet6>

                ' <Snippet7>

                ' Get the current Enabled property value.
                Dim enabledValue As Boolean = traceSection.Enabled

                ' Set the Enabled property to false.
                traceSection.Enabled = False

                ' </Snippet7>

                ' <Snippet8>

                ' Get the current Mode property value.
                'Dim modeValue As TraceDisplayMode = traceSection.TraceMode

                ' Set the Mode property to TraceDisplayMode.SortByTime.
                'traceSection.Mode = TraceDisplayMode.SortByTime

                ' </Snippet8>

                ' Update if not locked.
                If Not traceSection.SectionInformation.IsLocked Then
                    configuration.Save()
                    Console.WriteLine("** Configuration updated.")
                Else
                    Console.WriteLine("** Could not update, section is locked.")
                End If
            Catch e As System.ArgumentException
                ' Unknown error.
                Console.WriteLine( _
                    "A invalid argument exception detected in UsingTraceSection Main. Check your")
                Console.WriteLine("command line for errors.")
            End Try
        End Sub
    End Class ' UsingTraceSection.
    
End Namespace ' Samples.Aspnet.SystemWebConfiguration

' </Snippet1>
