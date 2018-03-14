all: mydll.dll
mydll.dll: contosokeyedhash.vb  encodewithcontoso.vb
	vbc /t:library /out:mydll.dll /imports:system.windows.forms,system.drawing contosokeyedhash.vb  encodewithcontoso.vb