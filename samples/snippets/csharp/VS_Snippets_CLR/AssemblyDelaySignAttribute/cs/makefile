all: source.dll source2.dll

source.dll: TestPublicKey.snk source.cs
   csc /t:library source.cs

TestPublicKey.snk:
   sn -k TestPublicKey.snk

source2.dll: myKey.snk source2.cs
   csc /t:library source2.cs

myKey.snk:
    sn -k myKey.snk

