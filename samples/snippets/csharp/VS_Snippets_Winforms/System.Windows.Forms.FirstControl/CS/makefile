SimpleForm.exe:  SimpleForm.cs FirstControl.dll
   csc /r:FirstControl.dll /t:exe /out:SimpleForm.exe SimpleForm.cs

FirstControl.dll: FirstControl.cs
   csc /t:library /out:FirstControl.dll FirstControl.cs

clean:
   del *.exe *.dll *.bin