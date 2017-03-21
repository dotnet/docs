    public static bool RemoveAllPrefixes(HttpListener listener)
    {
        // Get the prefixes that the Web server is listening to.
        HttpListenerPrefixCollection prefixes = listener.Prefixes;
        try 
        {
            prefixes.Clear();
        } 
        // If the operation failed, return false.
        catch
        {
            return false;
        }
        return true;
    }