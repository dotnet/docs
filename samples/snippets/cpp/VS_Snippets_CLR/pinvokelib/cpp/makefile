OUTDIR=..\LIB
SAMPDIR=..\..\Conceptual.Interop.Marshaling\LIB

all: $(OUTDIR) $(OUTDIR)\PInvokeLib.dll

$(OUTDIR):
    if not exist $(OUTDIR) md $(OUTDIR)

$(OUTDIR)\PInvokeLib.dll: PInvokeLib.cpp PInvokeLib.h
    cl /LD /Fe$(OUTDIR)\PInvokeLib.dll PInvokeLib.cpp
    if exist $(SAMPDIR) copy /Y $(OUTDIR)\PInvokeLib.dll $(SAMPDIR)

