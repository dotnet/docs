    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, true) == 0);
    }