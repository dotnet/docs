    // Demonstrates SetData, ContainsData, and GetData.
    public Object SwapClipboardFormattedData(String format, Object data)
    {
        Object returnObject = null;
        if (Clipboard.ContainsData(format))
        {
            returnObject = Clipboard.GetData(format);
            Clipboard.SetData(format, data);
        }
        return returnObject;
    }