# Build a library from the source file, and put it in the bin directory
# Set the source and language for the file to be compiled.

#LANG=CS
LANG=VB
DLL_NAME=Examples.WebNET.CreateUserWizardDesigner_$(LANG)


all:  bin\$(DLL_NAME).dll

bin\$(DLL_NAME).dll: createuser.vb createuserdesigner.vb
  IF NOT EXIST bin md bin
  vbc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /nologo /out:bin\$(DLL_NAME).dll createuser.vb createuserdesigner.vb
