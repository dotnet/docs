all: source1.exe source2.dll source3.exe

source1.exe: source1.vb
    vbc source1.vb

source2.dll: source2.vb
    vbc /t:library source2.vb

source3.exe: source2.dll source3.vb
    vbc /r:source2.dll source3.vb

