all: assemblyname_keypair.exe KeyFileAttrib.exe

assemblyname_keypair.exe: assemblyname_keypair.cpp
    cl /clr:pure assemblyname_keypair.cpp

KeyFileAttrib.exe: keyfile.snk KeyFileAttrib.cpp
    cl /clr:pure KeyFileAttrib.cpp

keyfile.snk:
    sn -k keyfile.snk