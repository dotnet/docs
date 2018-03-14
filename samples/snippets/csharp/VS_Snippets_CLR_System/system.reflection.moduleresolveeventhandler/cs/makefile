all: MySample.exe

MySample.exe: subfolder\Server1.netmodule MySample.cs
    csc /out:MySample.exe /t:exe /addmodule:subfolder\Server1.netmodule MySample.cs

subfolder\Server1.netmodule:
    @if not exist subfolder @md subfolder
    csc /out:subfolder\Server1.netmodule /t:module Server1.cs

