        Dim ac As ActivationContext = AppDomain.CurrentDomain.ActivationContext
        Dim ai As ApplicationIdentity = ac.Identity
        Console.WriteLine("Full name = " + ai.FullName)
        Console.WriteLine("Code base = " + ai.CodeBase)