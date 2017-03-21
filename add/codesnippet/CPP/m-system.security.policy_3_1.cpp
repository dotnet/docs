

static CodeConnectAccess^ CreateHttpAndOriginPortAccess()
{
    return gcnew CodeConnectAccess(Uri::UriSchemeHttp, 
        CodeConnectAccess::OriginPort);
}