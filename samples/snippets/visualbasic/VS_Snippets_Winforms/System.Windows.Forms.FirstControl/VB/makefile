SimpleForm.exe:  SimpleForm.vb FirstControl.dll
   vbc /t:exe /r:FirstControl.dll,System.dll,System.Drawing.dll,System.Windows.Forms.dll /out:SimpleForm.exe SimpleForm.vb

FirstControl.dll: FirstControl.vb
   vbc /r:System.dll,System.Drawing.dll,System.Windows.Forms.dll /t:library /out:FirstControl.dll FirstControl.vb

clean:
   del *.exe *.dll *.bin