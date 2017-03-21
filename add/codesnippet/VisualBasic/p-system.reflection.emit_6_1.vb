        ' Use the IsGenericMethod property to find out if a
        ' dynamic method is generic, and IsGenericMethodDefinition
        ' to find out if it defines a generic method.
        Console.WriteLine("Is DemoMethod generic? {0}", _
            demoMethod.IsGenericMethod)
        Console.WriteLine("Is DemoMethod a generic method definition? {0}", _
            demoMethod.IsGenericMethodDefinition)