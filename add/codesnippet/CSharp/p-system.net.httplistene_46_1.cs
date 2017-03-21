    public static string[] CopyPrefixes (HttpListener listener)
    {
         HttpListenerPrefixCollection prefixes = listener.Prefixes;
         string[] prefixArray = new string[prefixes.Count];
         prefixes.CopyTo(prefixArray, 0);
         return prefixArray;
    }