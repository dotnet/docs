        // If this is a generic method, display its type arguments.
        //
        if (mi.IsGenericMethod)
        {
            Type[] typeArguments = mi.GetGenericArguments();

            Console.WriteLine("\tList type arguments ({0}):", 
                typeArguments.Length);

            foreach (Type tParam in typeArguments)
            {
                // IsGenericParameter is true only for generic type
                // parameters.
                //
                if (tParam.IsGenericParameter)
                {
                    Console.WriteLine("\t\t{0}  parameter position {1}" +
                        "\n\t\t   declaring method: {2}",
                        tParam,
                        tParam.GenericParameterPosition,
                        tParam.DeclaringMethod);
                }
                else
                {
                    Console.WriteLine("\t\t{0}", tParam);
                }
            }
        }