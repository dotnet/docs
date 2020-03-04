.SUFFIXES : .cs

ASSEMBLY_LIST = /r:System.dll /r:System.Configuration.dll /r:System.Data.dll
CFLAGS = /target:library /nologo 
CS_DEBUGS = /define:DEBUG 

.cs.csout:
  csc $(CS_DEBUG) $(CFLAGS) $(ASSEMBLY_LIST) /out:ProtectedConfigurationProvider.dll *.cs


.all: ProtectedConfigurationProvider.csout 