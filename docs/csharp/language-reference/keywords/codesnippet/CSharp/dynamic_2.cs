    class ExampleClass
    {
        // A dynamic field.
        static dynamic field;

        // A dynamic property.
        dynamic prop { get; set; }

        // A dynamic return type and a dynamic parameter type.
        public dynamic exampleMethod(dynamic d)
        {
            // A dynamic local variable.
            dynamic local = "Local variable";
            int two = 2;

            if (d is int)
            {
                return local;
            }
            else
            {
                return two;
            }
        }
    }