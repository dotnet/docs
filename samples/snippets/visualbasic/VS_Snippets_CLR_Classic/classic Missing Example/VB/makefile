all: source.exe target.dll

target.dll: target.vb
   vbc /t:library target.vb

source.exe: source.vb target.dll
   vbc /r:target.dll source.vb 
