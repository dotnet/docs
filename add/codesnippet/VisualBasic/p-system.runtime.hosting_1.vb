        Dim ac As ActivationContext = AppDomain.CurrentDomain.ActivationContext
        ' Get the ActivationArguments from the SetupInformation property of the domain.
        Dim activationArgs As ActivationArguments = AppDomain.CurrentDomain.SetupInformation.ActivationArguments
        ' Get the ActivationContext from the ActivationArguments.
        Dim actContext As ActivationContext = activationArgs.ActivationContext
        Console.WriteLine("The ActivationContext.Form property value is: " + _
         activationArgs.ActivationContext.Form.ToString())