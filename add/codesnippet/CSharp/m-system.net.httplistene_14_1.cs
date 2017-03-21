    public static bool CheckForPrefix(HttpListener listener, string prefix)
    {
        // Get the prefixes that the Web server is listening to.
        HttpListenerPrefixCollection prefixes = listener.Prefixes;
        if (prefixes.Count == 0 || prefix == null)
        {
            return false;
        }
        return prefixes.Contains(prefix);
    }