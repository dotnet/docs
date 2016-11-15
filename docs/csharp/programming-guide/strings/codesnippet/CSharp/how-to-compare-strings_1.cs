
            // Internal strings that will never be localized.
            string root = @"C:\users";
            string root2 = @"C:\Users";

            // Use the overload of the Equals method that specifies a StringComparison.
            // Ordinal is the fastest way to compare two strings.
            bool result = root.Equals(root2, StringComparison.Ordinal);

            Console.WriteLine("Ordinal comparison: {0} and {1} are {2}", root, root2,
                                result ? "equal." : "not equal.");

            // To ignore case means "user" equals "User". This is the same as using
            // String.ToUpperInvariant on each string and then performing an ordinal comparison.
            result = root.Equals(root2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine("Ordinal ignore case: {0} and {1} are {2}", root, root2,
                                 result ? "equal." : "not equal.");

            // A static method is also available.
            bool areEqual = String.Equals(root, root2, StringComparison.Ordinal);


            // String interning. Are these really two distinct objects?
            string a = "The computer ate my source code.";
            string b = "The computer ate my source code.";

            // ReferenceEquals returns true if both objects
            // point to the same location in memory.
            if (String.ReferenceEquals(a, b))
                Console.WriteLine("a and b are interned.");
            else
                Console.WriteLine("a and b are not interned.");

            // Use String.Copy method to avoid interning.
            string c = String.Copy(a);

            if (String.ReferenceEquals(a, c))
                Console.WriteLine("a and c are interned.");
            else
                Console.WriteLine("a and c are not interned.");

            // Output:
            // Ordinal comparison: C:\users and C:\Users are not equal.
            // Ordinal ignore case: C:\users and C:\Users are equal.
            // a and b are interned.
            // a and c are not interned.