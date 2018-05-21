            int i = 8;
            dynamic d;
            // With the is operator.
            // The dynamic type behaves like object. The following
            // expression returns true unless someVar has the value null.
            if (someVar is dynamic) { }

            // With the as operator.
            d = i as dynamic;

            // With typeof, as part of a constructed type.
            Console.WriteLine(typeof(List<dynamic>));

            // The following statement causes a compiler error.
            //Console.WriteLine(typeof(dynamic));