            Dim evalContext As ContextInformation = TryCast(config.EvaluationContext, ContextInformation)
            Console.WriteLine("Machine level: {0}", evalContext.IsMachineLevel.ToString())