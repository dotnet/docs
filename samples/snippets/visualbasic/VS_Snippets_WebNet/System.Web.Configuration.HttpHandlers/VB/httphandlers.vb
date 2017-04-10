Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
    ' Accesses the System.Web.Configuration.HttpHandlersSection
    ' members selected by the user.
    Class UsingHttpHandlersSection
        Public Sub UsingHttpHandlersSection()
            ' Process the
            ' System.Web.Configuration.HttpHandlersSectionobject.
            Try
' <Snippet1>
    ' Get the Web application configuration.
    Dim configuration As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest")
                
    ' Get the section.
    Dim httpHandlersSection As System.Web.Configuration.HttpHandlersSection = CType(configuration.GetSection("system.web/httphandlers"), System.Web.Configuration.HttpHandlersSection)

' </Snippet1>

' <Snippet2>

    'Get the handlers.
    Dim httpHandlers As System.Web.Configuration.HttpHandlerActionCollection  = httpHandlersSection.Handlers

' </Snippet2>

' <Snippet3>
' Add a new HttpHandlerAction to the Handlers property HttpHandlerAction collection.
httpHandlersSection.Handlers.Add(new HttpHandlerAction( _
    "Calculator.custom", _
    "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler", _
    "GET", _
    true))
' </Snippet3>

' <Snippet4>
' Get a HttpHandlerAction in the Handlers property HttpHandlerAction collection.
Dim httpHandler As HttpHandlerAction = httpHandlers(0)

' </Snippet4>

' <Snippet5>
' Change the Path for the HttpHandlerAction.
httpHandler.Path = "Calculator.custom"

' </Snippet5>

' <Snippet6>
' Change the Type for the HttpHandlerAction.
httpHandler.Type = _
    "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler"

' </Snippet6>

' <Snippet7>
' Change the Verb for the HttpHandlerAction.
httpHandler.Verb = "POST"

' </Snippet7>

' <Snippet8>
' Change the Validate for the HttpHandlerAction.
httpHandler.Validate = False

' </Snippet8>

' <Snippet9>

    'Get the specified handler's index.
    Dim httpHandler2 As System.Web.Configuration.HttpHandlerAction  = new HttpHandlerAction( _
    "Calculator.custom", _
    "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler", _
    "GET", _
    true)
    Dim handlerIndex As Integer = httpHandlers.IndexOf(httpHandler2)

'</Snippet9>

' <Snippet10>

' Remove a HttpHandlerAction object 
    Dim httpHandler3 As System.Web.Configuration.HttpHandlerAction  = new HttpHandlerAction( _
    "Calculator.custom", _
    "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler", _
    "GET", _
    true)
    httpHandlers.Remove(httpHandler3)

' </Snippet10>

' <Snippet11>

    ' Remove a HttpHandlerAction object with 0 index.
    httpHandlers.RemoveAt(0)

' </Snippet11>

' <Snippet12>

    ' Clear all CustomError objects from the Handlers property HttpHandlerAction collection.
    httpHandlers.Clear()

' </Snippet12>

' <Snippet13>

    'Remove the handler with the specified verb and path.
    httpHandlers.Remove("GET", "*.custom")

' </Snippet13>

Console.WriteLine("List the Errors collection:")
Dim handlerActionCtr As Integer = 0
For Each handlerAction As HttpHandlerAction In httpHandlersSection.Handlers

Dim path As String = handlerAction.Path

' <Snippet14>
Dim type As String = handlerAction.Type

' </Snippet14>

' <Snippet15>

Dim verb As String = handlerAction.Verb
' </Snippet15>

' <Snippet16>

Dim validation As Boolean = handlerAction.Validate
' </Snippet16>

    Dim message As String = "Path = '" & path & "', Type = '" & type & _
        "', Verb = '" & verb & "' Validation = '" & validation.ToString() + "'"
    handlerActionCtr = handlerActionCtr + 1
    Console.WriteLine("  {0}: message", handlerActionCtr)
Next
                
                ' Update if not locked.
                If Not httpHandlersSection.SectionInformation.IsLocked Then
                    configuration.Save()
                    Console.WriteLine("** Configuration updated.")
                Else
                    Console.WriteLine("** Could not update, section is locked.")
                End If
            Catch e As System.ArgumentException
                ' Unknown error.
                Console.WriteLine( _
                    "A invalid argument exception detected in UsingHttpHandlersSection Main. Check")
                Console.WriteLine("your command line for errors.")
            End Try
        End Sub
    End Class ' UsingHttpHandlersSection.
    
End Namespace ' Samples.Aspnet.SystemWebConfiguration

