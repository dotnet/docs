

static CodeConnectAccess^ CreateFtpAndDefaultPortAccess()
{
    return gcnew CodeConnectAccess(Uri::UriSchemeFtp, 
        CodeConnectAccess::DefaultPort);
}