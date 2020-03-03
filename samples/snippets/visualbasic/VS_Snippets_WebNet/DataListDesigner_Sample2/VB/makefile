# Build a library from the source file, and put it in the bin directory
# Set the source and language for the file to be compiled.

ASSEMBLY_LIST=/r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll

#LANG=CS
LANG=VB

OUTDLL=simpleControl_$(LANG).dll
SRC=simpledatalist.vb simpledatalistdesigner.vb

all: $(OUTDLL)

$(OUTDLL): $(SRC)
	vbc /target:library /nologo /out:$(OUTDLL) $(ASSEMBLY_LIST) $(SRC)
