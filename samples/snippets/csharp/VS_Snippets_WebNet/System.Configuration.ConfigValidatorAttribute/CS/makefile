.SUFFIXES : .cs .vb

ASSEMBLY_LIST = /r:System.dll /r:System.Configuration.dll /r:System.Data.dll
CFLAGS = /target:exe /nologo 
CS_DEBUGS = /define:DEBUG 

.cs.csout:
  csc $(CS_DEBUG) $(CFLAGS) $(ASSEMBLY_LIST) /out:TestingConfigValidatorAttribute.exe *.cs


.all: TestingConfigValidatorAttribute.csout 
