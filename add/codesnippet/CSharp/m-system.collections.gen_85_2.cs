    // Defines a predicate delegate to use
    // for the SortedSet.RemoveWhere method.
    private static bool isDoc(string s)
    {
        if (s.ToLower().EndsWith(".txt") ||
            s.ToLower().EndsWith(".doc") ||
            s.ToLower().EndsWith(".xls") ||
            s.ToLower().EndsWith(".xlsx") ||
            s.ToLower().EndsWith(".pdf") ||
            s.ToLower().EndsWith(".doc") ||
            s.ToLower().EndsWith(".docx"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }