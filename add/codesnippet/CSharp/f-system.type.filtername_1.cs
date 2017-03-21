 // Get the set of methods associated with the type
 MemberInfo[] mi = typeof(Application).FindMembers(MemberTypes.Constructor | 
     MemberTypes.Method, 
     BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic |
     BindingFlags.Instance | BindingFlags.DeclaredOnly,
     Type.FilterName, "*");
   Console.WriteLine("Number of methods (includes constructors): " + mi.Length);