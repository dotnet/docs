all: AttributesDemoControl.dll form1.exe

AttributesDemoControl.dll: AttributesDemoControl.cs
   csc /target:library AttributesDemoControl.cs

Form1.exe: AttributesDemoControl.dll
   csc form1.cs /r:AttributesDemoControl.dll

clean:
   del *.exe *.dll *.bin *.obj