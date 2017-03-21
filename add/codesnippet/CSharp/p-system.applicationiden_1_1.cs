            ActivationContext ac = AppDomain.CurrentDomain.ActivationContext;
            ApplicationIdentity ai = ac.Identity;
            Console.WriteLine("Full name = " + ai.FullName);
            Console.WriteLine("Code base = " + ai.CodeBase);