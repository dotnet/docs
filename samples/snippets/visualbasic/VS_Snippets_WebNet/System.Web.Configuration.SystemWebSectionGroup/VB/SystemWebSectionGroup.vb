Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Text.RegularExpressions
Imports System.Web.Services.Configuration




Class UsingSystemWebSectionGroup
   
   Private Shared name, type, declared, msg As String
   Private Shared info As SectionInformation
   
   
    <STAThread()> _
    Public Overloads Shared Sub Main(ByVal args() As String)

        Dim inputStr As String = String.Empty
        Dim [option] As String = String.Empty

        ' Define a regular expression to allow only 
        ' alphanumeric inputs that are at most 20 character 
        ' long. For instance "/iii:".
        Dim rex As New Regex("[^\/w]{1,20}:")

        ' Parse the user's input.      
        If args.Length < 1 Then
            ' No option entered.
            Console.Write("Input parameter missing.")
            Return
        Else
            ' Get the user's option.
            inputStr = args(0).ToLower()
            If Not rex.Match(inputStr).Success Then
                ' Wrong option format used.
                Console.Write("Input parameter format not allowed.")
                Return
            End If
        End If

        ' <Snippet1>
        ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")

        ' Get the <system.web> group.
        Dim systemWeb As SystemWebSectionGroup = _
        CType(configuration.GetSectionGroup( _
        "system.web"), SystemWebSectionGroup)

        ' </Snippet1>

        Try

            Select Case inputStr

                Case "/anonymous:"
                    ' <Snippet2>
                    ' Get the anonymousIdentification section.
                    Dim anonymousIdentification _
                    As AnonymousIdentificationSection = _
                    systemWeb.AnonymousIdentification
                    ' Read section information.
                    info = anonymousIdentification.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet2>
                    Console.Write(msg)

                Case "/authentication:"

                    ' <Snippet3>
                    ' Get the authentication section.
                    Dim authentication _
                    As AuthenticationSection = _
                    systemWeb.Authentication
                    ' Read section information.
                    info = authentication.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet3>
                    Console.Write(msg)

                Case "/authorization:"

                    ' <Snippet4>
                    ' Get the authorization section.
                    Dim authorization _
                    As AuthorizationSection = _
                    systemWeb.Authorization
                    ' Read section information.
                    info = authorization.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet4>
                    Console.Write(msg)

                Case "/compilation:"

                    ' <Snippet5>
                    ' Get the compilation section.
                    Dim compilation _
                    As CompilationSection = systemWeb.Compilation
                    ' Read section information.
                    info = compilation.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet5>
                    Console.Write(msg)


                Case "/customerrors:"

                    ' <Snippet6>
                    ' Get the customerrors section.
                    Dim customerrors _
                    As CustomErrorsSection = _
                    systemWeb.CustomErrors
                    ' Read section information.
                    info = customerrors.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet6>
                    Console.Write(msg)

                Case "/globalization:"

                    ' <Snippet7>
                    ' Get the globalization section.
                    Dim globalization _
                    As GlobalizationSection = _
                    systemWeb.Globalization
                    ' Read section information.
                    info = globalization.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet7>
                    Console.Write(msg)

                Case "/httpcookies:"
                    ' <Snippet8>
                    ' Get the httpCookies section.
                    Dim httpCookies _
                    As HttpCookiesSection = _
                    systemWeb.HttpCookies
                    ' Read section information.
                    info = httpCookies.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet8>
                    Console.Write(msg)

                Case "/httphandlers:"

                    ' <Snippet9>
                    ' Get the httpHandlers section.
                    Dim httpHandlers _
                    As HttpHandlersSection = _
                    systemWeb.HttpHandlers
                    ' Read section information.
                    info = httpHandlers.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet9>
                    Console.Write(msg)

                Case "/httpmodules:"

                    ' <Snippet10>
                    ' Get the httpModules section.
                    Dim httpModules _
                    As HttpModulesSection = _
                    systemWeb.HttpModules
                    ' Read section information.
                    info = httpModules.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet10>
                    Console.Write(msg)

                Case "/httpruntime:"

                    ' <Snippet11>
                    ' Get the httpRuntime section.
                    Dim httpRuntime _
                    As HttpRuntimeSection = _
                    systemWeb.HttpRuntime
                    ' Read section information.
                    info = httpRuntime.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet11>
                    Console.Write(msg)

                Case "/identity:"

                    ' <Snippet12>
                    ' Get the identity section.
                    Dim identity As IdentitySection = _
                    systemWeb.Identity
                    ' Read section information.
                    info = identity.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet12>
                    Console.Write(msg)

                Case "/machinekey:"

                    ' <Snippet13>
                    ' Get the machineKey section.
                    Dim machineKey As MachineKeySection = _
                    systemWeb.MachineKey
                    ' Read section information.
                    info = machineKey.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet13>
                    Console.Write(msg)

                Case "/membership:"
                    ' <Snippet14>
                    ' Get the membership section.
                    Dim membership As MembershipSection = _
                    systemWeb.Membership
                    ' Read section information.
                    info = membership.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet14>
                    Console.Write(msg)

                Case "/pages:"
                    ' <Snippet15>
                    ' Get the pages section.
                    Dim pages As PagesSection = _
                    systemWeb.Pages
                    ' Read section information.
                    info = pages.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet15>
                    Console.Write(msg)

                Case "/processModel:"
                    ' <Snippet16>
                    ' Get the processModel section.
                    Dim processModel _
                    As ProcessModelSection = _
                    systemWeb.ProcessModel
                    ' Read section information.
                    info = processModel.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet16>
                    Console.Write(msg)

                Case "/profile:"
                    ' <Snippet17>
                    ' Get the profile section.
                    Dim profile As ProfileSection = _
                    systemWeb.Profile
                    ' Read section information.
                    info = profile.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet17>
                    Console.Write(msg)

                Case "/roleManager:"
                    ' <Snippet18>
                    ' Get the roleManager section.
                    Dim roleManager _
                    As RoleManagerSection = _
                    systemWeb.RoleManager
                    ' Read section information.
                    info = roleManager.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet18>
                    Console.Write(msg)

                Case "/securityPolicy:"
                    ' <Snippet19>
                    ' Get the securityPolicy section.
                    Dim securityPolicy _
                    As SecurityPolicySection = _
                    systemWeb.SecurityPolicy
                    ' Read section information.
                    info = securityPolicy.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet19>
                    Console.Write(msg)

                Case "/sessionState:"
                    ' <Snippet20>
                    ' Get the sessionState section.
                    Dim sessionState _
                    As SessionStateSection = _
                    systemWeb.SessionState
                    ' Read section information.
                    info = sessionState.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet20>
                    Console.Write(msg)

                Case "/sitemap:"
                    ' <Snippet21>
                    ' Get the siteMap section.
                    Dim siteMap As SiteMapSection = _
                    systemWeb.SiteMap
                    ' Read section information.
                    info = siteMap.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet21>
                    Console.Write(msg)

                Case "/trace:"
                    ' <Snippet22>
                    ' Get the trace section.
                    Dim trace As TraceSection = _
                    systemWeb.Trace
                    ' Read section information.
                    info = trace.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet22>
                    Console.Write(msg)

                Case "/trust:"
                    ' <Snippet23>
                    ' Get the trust section.
                    Dim trust As TrustSection = _
                    systemWeb.Trust
                    ' Read section information.
                    info = trust.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)

                    ' </Snippet23>
                    Console.Write(msg)


                Case "/browserCaps:"
                    ' <Snippet24>
                    ' Get the browserCaps section.
                    Dim browserCaps As DefaultSection = _
                    systemWeb.BrowserCaps
                    ' Read section information.
                    info = browserCaps.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
                    ' </Snippet24>
                    Console.Write(msg)

                Case "/clientTarget:"
                    ' <Snippet25>
                    ' Get the clientTarget section.
                    Dim clientTarget As ClientTargetSection = _
                    systemWeb.ClientTarget
                    ' Read section information.
                    info = clientTarget.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
                    ' </Snippet25>
                    Console.Write(msg)


                Case "/deployment:"
                    ' <Snippet26>
                    ' Get the deployment section.
                    Dim deployment As DeploymentSection = _
                    systemWeb.Deployment
                    ' Read section information.
                    info = deployment.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
                    ' </Snippet26>
                    Console.Write(msg)


                Case "/deviceFilters:"
                    ' <Snippet27>
                    ' Get the deviceFilters section.
                    Dim deviceFilters As DefaultSection = _
                    systemWeb.DeviceFilters
                    ' Read section information.
                    info = deviceFilters.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
                    ' </Snippet27>
                    Console.Write(msg)

                Case "/healthMonitoring:"
                    ' <Snippet28>
                    ' Get the healthMonitoring section.
                    Dim healthMonitoring _
                    As HealthMonitoringSection = _
                    systemWeb.HealthMonitoring
                    ' Read section information.
                    info = healthMonitoring.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
                    ' </Snippet28>
                    Console.Write(msg)

                Case "/hostingEnvironment:"
                    ' <Snippet29>
                    ' Get the hostingEnvironment section.
                    Dim hostingEnvironment _
                    As HostingEnvironmentSection = _
                    systemWeb.HostingEnvironment
                    ' Read section information.
                    info = hostingEnvironment.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
                    ' </Snippet29>
                    Console.Write(msg)

                Case "/mobileControls:"
                    ' <Snippet30>
                    ' Get the mobileControls section.
                    Dim mobileControls _
                    As ConfigurationSection = _
                    systemWeb.MobileControls
                    ' Read section information.
                    info = mobileControls.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
                    ' </Snippet30>
                    Console.Write(msg)

                Case "/protocols:"
                    ' <Snippet31>
                    ' Get the protocols section.
                    Dim protocols As DefaultSection = _
                    systemWeb.Protocols
                    ' Read section information.
                    info = protocols.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
                    ' </Snippet31>
                    Console.Write(msg)

                Case "/urlMappings:"
                    ' <Snippet32>
                    ' Get the urlMappings section.
                    Dim urlMappings _
                    As UrlMappingsSection = _
                    systemWeb.UrlMappings
                    ' Read section information.
                    info = urlMappings.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
                    ' </Snippet32>
                    Console.Write(msg)

                Case "/webControls:"
                    ' <Snippet33>
                    ' Get the webControls section.
                    Dim webControls _
                    As WebControlsSection = _
                    systemWeb.WebControls
                    ' Read section information.
                    info = webControls.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
                    ' </Snippet33>
                    Console.Write(msg)

                Case "/webParts:"
                    ' <Snippet34>
                    ' Get the webParts section.
                    Dim webParts _
                    As WebPartsSection = systemWeb.WebParts
                    ' Read section information.
                    info = webParts.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
                    ' </Snippet34>
                    Console.Write(msg)

                Case "/webServices:"
                    ' <Snippet35>
                    ' Get the webServices section.
                    Dim webServices _
                    As WebServicesSection = systemWeb.WebServices
                    ' Read section information.
                    info = webServices.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
                    ' </Snippet35>
                    Console.Write(msg)

                Case "/XhtmlConformance:"
                    ' <Snippet36>
                    ' Get the xhtmlConformance section.
                    Dim xhtmlConformance _
                    As XhtmlConformanceSection = _
                    systemWeb.XhtmlConformance
                    ' Read section information.
                    info = xhtmlConformance.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()

                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
                    ' </Snippet36>
                    Console.Write(msg)



                Case "/all:"
                    Dim allSections As New StringBuilder()
                    Dim systemWebGroup _
                    As ConfigurationSectionGroup = _
                    configuration.GetSectionGroup("system.web")
                    Dim i As Integer = 0
                    Dim section As ConfigurationSection
                    For Each section In systemWebGroup.Sections
                        i += 1
                        info = section.SectionInformation
                        name = info.SectionName
                        type = info.Type
                        declared = info.IsDeclared.ToString()
                        If i < 10 Then
                            msg = String.Format("{0})Name:   {1}" + _
                            ControlChars.Lf + "Declared: {2}" + _
                            ControlChars.Lf + "Type:     {3}" + _
                            ControlChars.Lf, i.ToString(), name, _
                            declared, type)
                        Else
                            msg = String.Format("{0})Name:  {1}" + _
                            ControlChars.Lf + "Declared: {2}" + _
                            ControlChars.Lf + "Type:     {3}" + _
                            ControlChars.Lf, i.ToString(), name, _
                            declared, type)
                        End If
                        allSections.AppendLine(msg)
                    Next section

                    ' Console.WriteLine(systemWebGroup.Name);
                    ' Console.WriteLine(systemWebGroup.SectionGroupName);
                    Console.Write(allSections.ToString())

                Case Else
                    ' Option is not allowed..
                    Console.Write("Input not allowed.")
            End Select
        Catch e As ArgumentException
            ' Never display this. Use it for 
            ' debugging purposes.
            msg = e.ToString()
        End Try
    End Sub 'Main 
End Class 'UsingSystemWebSectionGroup
