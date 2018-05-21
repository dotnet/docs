            int? n = null;

            //int m1 = n;      // Will not compile.
            int m2 = (int)n;   // Compiles, but will create an exception if n is null.
            int m3 = n.Value;  // Compiles, but will create an exception if n is null.