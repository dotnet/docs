
        public static CodeConnectAccess CreateHttpAndOriginPortAccess()
    {
        return new CodeConnectAccess(Uri.UriSchemeHttp, CodeConnectAccess.OriginPort);
    }