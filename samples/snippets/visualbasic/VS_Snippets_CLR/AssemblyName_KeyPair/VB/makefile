all: assemblyname_keypair.exe KeyFileAttrib.exe

assemblyname_keypair.exe: assemblyname_keypair.vb
    vbc /target:exe assemblyname_keypair.vb

KeyFileAttrib.exe: keyfile.snk KeyFileAttrib.vb
    vbc /target:exe KeyFileAttrib.vb

keyfile.snk:
    sn -k keyfile.snk