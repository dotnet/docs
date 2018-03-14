Imports System.Web.Configuration
Imports System.Configuration
Imports System.Text


Namespace ConfigPlay
  Class Test
    Sub Main()
        '<snippet1>
        ' Obtains the machine configuration settings on the local machine.
        Dim machineConfig As System.Configuration.Configuration
        machineConfig = _
            System.Web.Configuration.WebConfigurationManager.OpenMachineConfiguration()
        machineConfig.SaveAs("c:\machineConfig.xml")
        '</snippet1>


        '<snippet2>
        ' Obtains the configuration settings for a Web application.
        Dim webConfig As System.Configuration.Configuration
        webConfig = _
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Temp")
        webConfig.SaveAs("c:\\webConfig.xml")
        '</snippet2>


        '<snippet3>
        ' Obtains the configuration settings for the <anonymousIdentification> section.
        Dim config As System.Configuration.Configuration
        config = _
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Temp")
        Dim systemWeb As System.Web.Configuration.SystemWebSectionGroup
        systemWeb = config.GetSectionGroup("system.web")
        Dim sectionConfig As System.Web.Configuration.AnonymousIdentificationSection
        sectionConfig = systemWeb.AnonymousIdentification
        Dim sb As New StringBuilder
        sb.AppendLine("<anonymousIdentification> attributes:")
        Dim props As System.Configuration.PropertyInformationCollection
        props = sectionConfig.ElementInformation.Properties
        For Each prop As System.Configuration.PropertyInformation In props
            sb.Append(prop.Name.ToString())
            sb.Append(" = ")
            sb.AppendLine(prop.Value.ToString())
        Next
        Console.WriteLine(sb.ToString())
        '</snippet3>


        '<snippet4>
        Dim userToken As IntPtr
        userToken = System.Security.Principal.WindowsIdentity.GetCurrent().Token

        ' Obtains the machine configuration settings on a remote machine.
        Dim remoteMachineConfig As System.Configuration.Configuration
        remoteMachineConfig = _
            System.Web.Configuration.WebConfigurationManager.OpenMachineConfiguration( _
            Nothing, "JanetFi2", userToken)
        remoteMachineConfig.SaveAs("c:\remoteMachineConfig.xml")

        ' Obtains the root Web configuration settings on a remote machine.
        Dim remoteRootConfig As System.Configuration.Configuration
        remoteRootConfig = _
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration( _
            Nothing, Nothing, Nothing, "JanetFi2", userToken)
        remoteRootConfig.SaveAs("c:\remoteRootConfig.xml")

        ' Obtains the configuration settings for the 
        ' W3SVC/1/Root/Temp application on a remote machine.
        Dim remoteWebConfig As System.Configuration.Configuration
        remoteWebConfig = _
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration( _
            "/Temp", "1", Nothing, "JanetFi2", userToken)
        remoteWebConfig.SaveAs("c:\\remoteWebConfig.xml")
        '</snippet4>


        '<snippet5>
        ' Updates the configuration settings for a Web application.
        Dim updateWebConfig As System.Configuration.Configuration
        updateWebConfig = _
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Temp")
        Dim compilation As System.Web.Configuration.CompilationSection
        compilation = _
            updateWebConfig.GetSection("system.web/compilation")
        Console.WriteLine("Current <compilation> debug = {0}", compilation.Debug)
        compilation.Debug = True
        If Not compilation.SectionInformation.IsLocked Then
            updateWebConfig.Save()
            Console.WriteLine("New <compilation> debug = {0}", compilation.Debug)
        Else
            Console.WriteLine("Could not save configuration.")
        End If
        '</snippet5>



        '<snippet6>
        Dim rootWebConfig As System.Configuration.Configuration
            rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot")
        Dim connString As System.Configuration.ConnectionStringSettings
        If (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0) Then
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings("NorthwindConnectionString")
            If Not (connString.ConnectionString = Nothing) Then
                Console.WriteLine("Northwind connection string = {0}", connString.ConnectionString)
            Else
                Console.WriteLine("No Northwind connection string")
            End If
        End If
        '</snippet6>


        '<snippet7>
        Dim rootWebConfig1 As System.Configuration.Configuration
        rootWebConfig1 = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(Nothing)
        If (rootWebConfig1.AppSettings.Settings.Count > 0) Then
            Dim customSetting As System.Configuration.KeyValueConfigurationElement
            customSetting = rootWebConfig1.AppSettings.Settings("customsetting1")
            If Not (customSetting.Value = Nothing) Then
                Console.WriteLine("customsetting1 application string = {0}", customSetting.Value)
            Else
                Console.WriteLine("No customsetting1 application string")
            End If
        End If
        '</snippet7>

    End Sub
  End Class
End Namespace
