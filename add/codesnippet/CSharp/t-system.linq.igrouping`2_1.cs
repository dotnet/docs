            // Get an IGrouping object.
            IGrouping<System.Reflection.MemberTypes, System.Reflection.MemberInfo> group =
                typeof(String).GetMembers().
                GroupBy(member => member.MemberType).
                First();

            // Output the key of the IGrouping, then iterate
            // through each value in the sequence of values
            // of the IGrouping and output its Name property.
            Console.WriteLine("\nValues that have the key '{0}':", group.Key);
            foreach (System.Reflection.MemberInfo mi in group)
                Console.WriteLine(mi.Name);

            // The output is similar to:

            // Values that have the key 'Method':
            // get_Chars
            // get_Length
            // IndexOf
            // IndexOfAny
            // LastIndexOf
            // LastIndexOfAny
            // Insert
            // Replace
            // Replace
            // Remove
            // Join
            // Join
            // Equals
            // Equals
            // Equals
            // ...
