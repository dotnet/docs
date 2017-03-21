    public static void DisplayConnectionAccessRules(NetCodeGroup group)
    {
        System.Collections.DictionaryEntry[] rules = group.GetConnectAccessRules();
        foreach (System.Collections.DictionaryEntry o in rules)
        {
            string key = o.Key as string;
            CodeConnectAccess[] values = (CodeConnectAccess[]) o.Value;
            Console.WriteLine("Origin scheme: {0}", key);
            foreach (CodeConnectAccess c in values)
            {
                Console.WriteLine("Scheme {0} Port: {1}", c.Scheme, c.Port);
            }
            Console.WriteLine("__________________________");
        }
    }