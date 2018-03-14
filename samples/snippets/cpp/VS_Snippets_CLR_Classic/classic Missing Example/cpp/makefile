all: source.exe target.dll

target.dll: target.vb
   vbc /t:library target.vb

source.exe: source.cpp target.dll
   cl /clr source.cpp 
