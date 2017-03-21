        // ReturnTypeCustomAttributes returns an ICustomeAttributeProvider
        // that can be used to enumerate the custom attributes of the
        // return value. At present, there is no way to set such custom
        // attributes, so the list is empty.
        if (hello.ReturnType == typeof(void))
        {
            Console.WriteLine("The method has no return type.");
        }
        else
        {
            ICustomAttributeProvider caProvider = hello.ReturnTypeCustomAttributes;
            object[] returnAttributes = caProvider.GetCustomAttributes(true);
            if (returnAttributes.Length == 0)
            {
                Console.WriteLine("\r\nThe return type has no custom attributes.");
            }
            else
            {
                Console.WriteLine("\r\nThe return type has the following custom attributes:");
                foreach( object attr in returnAttributes )
                {
                    Console.WriteLine("\t{0}", attr.ToString());
                }
            }
        }