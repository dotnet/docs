            // Get a sequence of IGrouping objects.
            IEnumerable<IGrouping<System.Reflection.MemberTypes, System.Reflection.MemberInfo>> memberQuery =
                typeof(String).GetMembers().
                GroupBy(member => member.MemberType);

            // Output the key of each IGrouping object and the count of values.
            foreach (IGrouping<System.Reflection.MemberTypes, System.Reflection.MemberInfo> group in memberQuery)
                Console.WriteLine("(Key) {0} (Member count) {1}", group.Key, group.Count());

            // The output is similar to:
            // (Key) Method (Member count) 113
            // (Key) Constructor (Member count) 8
            // (Key) Property (Member count) 2
            // (Key) Field (Member count) 1
