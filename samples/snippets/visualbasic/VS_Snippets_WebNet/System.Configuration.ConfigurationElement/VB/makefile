.SUFFIXES : .cs .vb

ASSEMBLY_LIST = /r:System.dll /r:System.Configuration.dll /r:System.Data.dll
CFLAGS = /target:exe /nologo 
VB_DEBUGS = /define:DEBUGMODE=True


.vb.vbout:
  vbc $(CS_DEBUG) $(CFLAGS) $(ASSEMBLY_LIST) /out:ConfigurationElement.exe *.vb


.all: ConfigurationElement.vbout
