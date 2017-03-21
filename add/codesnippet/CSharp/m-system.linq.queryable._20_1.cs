            // Create a list of MemberInfo objects.
            List<System.Reflection.MemberInfo> members = typeof(String).GetMembers().ToList();

            // Return only those items that can be cast to type PropertyInfo.
            IQueryable<System.Reflection.PropertyInfo> propertiesOnly =
                members.AsQueryable().OfType<System.Reflection.PropertyInfo>();

            Console.WriteLine("Members of type 'PropertyInfo' are:");
            foreach (System.Reflection.PropertyInfo pi in propertiesOnly)
                Console.WriteLine(pi.Name);

            /*
                This code produces the following output:
             
                Members of type 'PropertyInfo' are:
                Chars
                Length
            */
