    Public Shared Sub Main() 
        ' Get base address from appsettings in configuration.
        Dim baseAddress As New Uri(ConfigurationManager.AppSettings("baseAddress"))
        
        ' Create a ServiceHost for the CalculatorService type 
        ' and provide the base address.
        Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)
        Try
            ' Create a new auditing behavior and set the log location.
            Dim newAudit As New ServiceSecurityAuditBehavior()
            newAudit.AuditLogLocation = AuditLogLocation.Application
            newAudit.MessageAuthenticationAuditLevel = _
                AuditLevel.SuccessOrFailure
            newAudit.ServiceAuthorizationAuditLevel = _
                AuditLevel.SuccessOrFailure
            newAudit.SuppressAuditFailure = False
            ' Remove the old behavior and add the new.
            serviceHost.Description.Behaviors.Remove(Of ServiceSecurityAuditBehavior)
            serviceHost.Description.Behaviors.Add(newAudit)
            ' Open the ServiceHostBase to create listeners 
            ' and start listening for messages.
            serviceHost.Open()
            
            ' The service can now be accessed.
            Console.WriteLine("The service is ready.")
            Console.WriteLine("Press <ENTER> to terminate service.")
            Console.WriteLine()
            Console.ReadLine()
            
            ' Close the ServiceHostBase to shutdown the service.
            serviceHost.Close()
        Finally
        End Try
    
    End Sub 