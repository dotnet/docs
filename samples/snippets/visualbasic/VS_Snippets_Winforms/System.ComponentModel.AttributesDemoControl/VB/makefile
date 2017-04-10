all: AttributesDemoControl.dll form1.exe

AttributesDemoControl.dll: AttributesDemoControl.vb
   vbc /target:library AttributesDemoControl.vb

Form1.exe: AttributesDemoControl.dll
   vbc form1.vb /r:AttributesDemoControl.dll

clean:
   del *.exe *.dll *.bin *.obj