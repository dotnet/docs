rem ECHO OFF
REM Generate the CS files for AdventureWorks:

REM "%windir%\Microsoft.NET\Framework\v3.5\edmgen.exe" /mode:EntityClassGeneration /incsdl:Northwind.csdl /outobjectlayer:.\Northwind.Objects.cs /language:CSharp 
 /namespace:NorthwindService
 "%windir%\Microsoft.NET\Framework\v3.5\edmgen.exe" /mode:EntityClassGeneration /incsdl:Northwind.csdl /outobjectlayer:.\Northwind.Objects.vb /language:VB
 /namespace:NorthwindService
pause