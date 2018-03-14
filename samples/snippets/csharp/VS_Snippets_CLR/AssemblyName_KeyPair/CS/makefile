all: assemblyname_keypair.exe KeyFileAttrib.exe

assemblyname_keypair.exe: assemblyname_keypair.cs
    csc /target:exe assemblyname_keypair.cs

KeyFileAttrib.exe: keyfile.snk KeyFileAttrib.cs
    csc /target:exe KeyFileAttrib.cs

keyfile.snk:
    sn -k keyfile.snk