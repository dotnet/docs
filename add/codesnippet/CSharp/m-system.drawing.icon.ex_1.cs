    private void ExtractAssociatedIconEx()
    {
        Icon ico =
            Icon.ExtractAssociatedIcon(@"C:\WINDOWS\system32\notepad.exe");
        this.Icon = ico;

    }