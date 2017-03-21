        Dim asi As New ApplicationSecurityInfo(AppDomain.CurrentDomain.ActivationContext)     
        Console.WriteLine("ApplicationId.Name property = " + asi.ApplicationId.Name)