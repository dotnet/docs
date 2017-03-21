    public override Stream ChainStream( Stream stream ){
        oldStream = stream;
        newStream = new MemoryStream();
        return newStream;
    }