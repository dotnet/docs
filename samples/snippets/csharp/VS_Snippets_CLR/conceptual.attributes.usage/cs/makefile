all: source1.exe source2.dll source3.exe

source1.exe: source1.cs
    csc source1.cs

source2.dll: source2.cs
    csc /t:library source2.cs

source3.exe: source2.dll source3.cs
    csc /r:source2.dll source3.cs

