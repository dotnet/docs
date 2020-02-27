all: contosoformattercs.dll contosoformatter.exe

contosoformattercs.dll: contosoformatter.cs
   csc /t:library /out:contosoformattercs.dll /r:contosodeformattercs.dll contosoformatter.cs

contosoformatter.exe: contosoformatter.cs  contosoformattercs.dll 
	csc /t:library /r:contosoformattercs.dll /r:contosodeformattercs.dll /nologo ContosoEncryption.cs
  
