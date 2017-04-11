all: source.dll source2.dll

source.dll: TestPublicKey.snk source.vb
   vbc /t:library source.vb

TestPublicKey.snk:
   sn -k TestPublicKey.snk

source2.dll: myKey.snk source2.vb
   vbc /t:library source2.vb

myKey.snk:
    sn -k myKey.snk

