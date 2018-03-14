rem ECHO OFF
REM Generate the CS files for AdventureWorks:

 "%windir%\Microsoft.NET\Framework\v3.5\edmgen.exe" /mode:EntityClassGeneration /incsdl:Northwind.csdl /outobjectlayer:.\Northwind.Objects.cs /language:CSharp

pause