all: contosoformattervb.dll contosoformatter.exe
IMPORT_LIST=System,Microsoft.VisualBasic,System.Windows.Forms
contosoformattervb.dll: contosoformatter.vb
   vbc /t:library /out:contosoformattervb.dll /r:contosodeformattervb.dll contosoformatter.vb

contosoformatter.exe: contosoformatter.vb  contosoformattervb.dll 	
	vbc /t:winexe /import:$(IMPORT_LIST) /res:form1.resx /r:contosoformattervb.dll /r:contosodeformattervb.dll /nologo $(ASSEMBLY_LIST) /main:Form1 /out:customcryptoimplvb.exe form1.vb