all: source.exe target.dll

target.dll: target.vb
   vbc /t:library target.vb

source.exe: source.cs target.dll
   csc /r:target.dll source.cs 
