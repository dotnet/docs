# Build a library from the source file, and put it in the bin directory
# Set the source and language for the file to be compiled.

SOURCE=SimpleControlWithFileName
LANG=CS
#LANG=VB


all:  bin\$(SOURCE)_$(LANG).dll

bin\$(SOURCE)_vb.dll: $(SOURCE).vb
  IF NOT EXIST bin md bin
  vbc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /nologo /out:bin\$(SOURCE)_vb.dll $(SOURCE).vb

bin\$(SOURCE)_cs.dll: $(SOURCE).cs
  IF NOT EXIST bin md bin
  csc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /nologo /out:bin\$(SOURCE)_cs.dll $(SOURCE).cs
