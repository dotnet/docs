            ApplicationSecurityInfo asi = new ApplicationSecurityInfo(AppDomain.CurrentDomain.ActivationContext);

            Console.WriteLine("ApplicationId.Name property = " + asi.ApplicationId.Name);