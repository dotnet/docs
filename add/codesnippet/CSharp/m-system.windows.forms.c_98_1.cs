    // Demonstrates SetFileDropList, ContainsFileDroList, and GetFileDropList
    public System.Collections.Specialized.StringCollection
        SwapClipboardFileDropList(
        System.Collections.Specialized.StringCollection replacementList)
    {
        System.Collections.Specialized.StringCollection returnList = null;
        if (Clipboard.ContainsFileDropList())
        {
            returnList = Clipboard.GetFileDropList();
            Clipboard.SetFileDropList(replacementList);
        }
        return returnList;
    }