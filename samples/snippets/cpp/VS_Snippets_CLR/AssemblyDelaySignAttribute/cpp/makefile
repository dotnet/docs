all: source.dll source2.dll

source.dll: TestPublicKey.snk source.cpp
   cl /clr:pure /LD source.cpp

TestPublicKey.snk:
   sn -k TestPublicKey.snk

source2.dll: myKey.snk source2.cpp
   cl /clr:pure /LD source2.cpp

myKey.snk:
    sn -k myKey.snk

