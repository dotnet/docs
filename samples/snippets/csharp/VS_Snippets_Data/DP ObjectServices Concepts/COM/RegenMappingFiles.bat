ECHO OFF

ECHO Warning there have been manual changes to the mapping files!

REM Generate the CS files for AdventureWorks:
REM"C:\WINNT\Microsoft.NET\Framework\v3.5.20323\edmgen.exe" /mode:fullgeneration /c:"Data Source=GLENGATEST2; Initial Catalog=AdventureWorks; Integrated Security=SSPI" /project:AdventureWorks /entitycontainer:AdventureWorksEntities /language:CSharp /namespace:AdventureWorksModel

REM Generate the VB files for AdventureWorks:
REM "C:\WINNT\Microsoft.NET\Framework\v3.5.20323\edmgen.exe" /mode:fullgeneration /c:"Data Source=GLENGATEST2; Initial Catalog=AdventureWorks; Integrated Security=SSPI" /project:AdventureWorks /entitycontainer:AdventureWorksEntities /language:VB /namespace:AdventureWorksModel

pause