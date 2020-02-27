ECHO OFF

REM Validate the mapping files for AdventureWorks:
"C:\WINNT\Microsoft.NET\Framework\v3.5\edmgen.exe" /mode:ValidateArtifacts  /inssdl:.\CS\bin\debug\AdventureWorks.ssdl /inmsl:.\CS\bin\debug\AdventureWorks.msl /incsdl:.\CS\bin\debug\AdventureWorks.csdl

pause