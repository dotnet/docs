            // Get the ActivationArguments from the SetupInformation property of the domain.
            ActivationArguments activationArgs = AppDomain.CurrentDomain.SetupInformation.ActivationArguments;
            // Get the ActivationContext from the ActivationArguments.
            ActivationContext actContext = activationArgs.ActivationContext;
            Console.WriteLine("The ActivationContext.Form property value is: " +
                activationArgs.ActivationContext.Form);