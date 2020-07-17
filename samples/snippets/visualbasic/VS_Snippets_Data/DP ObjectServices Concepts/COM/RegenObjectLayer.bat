rem ECHO OFF
REM Generate the CS files for AdventureWorks:

<snippetGenerateObjectsCs>
"%windir%\Microsoft.NET\Framework\v4.0\edmgen.exe" /mode:EntityClassGeneration 
/incsdl:.\AdventureWorks.csdl /outobjectlayer:.\AdventureWorks.Objects.cs /language:CSharp
</snippetGenerateObjectsCs>

REM Generate the VB files for AdventureWorks:

<snippetGenerateObjectsVb>
"%windir%\Microsoft.NET\Framework\v4.0\edmgen.exe" /mode:EntityClassGeneration 
/incsdl:.\AdventureWorks.csdl /outobjectlayer:.\AdventureWorks.Objects.vb /language:VB
</snippetGenerateObjectsVb>

pause