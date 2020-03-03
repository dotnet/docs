.SUFFIXES : .vb

ASSEMBLY_LIST = /r:System.dll /r:System.Configuration.dll /r:System.Data.dll
CFLAGS = /target:library /nologo 
VB_DEBUGS = /define:DEBUGMODE=True

.vb.vbout:
  vbc $(VB_DEBUGs) $(CFLAGS) $(ASSEMBLY_LIST) /out:InfiniteTimeSpanConverter.dll *.vb


.all: InfiniteTimeSpanConverter.vbout 