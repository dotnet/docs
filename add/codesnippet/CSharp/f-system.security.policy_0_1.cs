    public static CodeConnectAccess CreateFtpAndDefaultPortAccess()
    {
        return new CodeConnectAccess(Uri.UriSchemeFtp, CodeConnectAccess.DefaultPort);
    }